using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using OCR.DAO.Interfaces;
using OCR.DAO.Locals;
using WIA;

namespace OCR.Utils.Helpers.DriverControls
{
    internal static class WIAScannerControl
    {
        private const string wiaFormatBMP = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";

        private class WIA_DPS_DOCUMENT_HANDLING_SELECT
        {
            public const uint FEEDER = 0x00000001;
            public const uint FLATBED = 0x00000002;
        }

        private class WIA_DPS_DOCUMENT_HANDLING_STATUS
        {
            public const uint FEED_READY = 0x00000001;
        }

        private class WIA_PROPERTIES
        {
            public const uint WIA_RESERVED_FOR_NEW_PROPS = 1024;
            public const uint WIA_DIP_FIRST = 2;
            public const uint WIA_DPA_FIRST = WIA_DIP_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
            public const uint WIA_DPC_FIRST = WIA_DPA_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
            //
            // Scanner only device properties (DPS)
            //
            public const uint WIA_DPS_FIRST = WIA_DPC_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
            public const uint WIA_DPS_DOCUMENT_HANDLING_STATUS = WIA_DPS_FIRST + 13;
            public const uint WIA_DPS_DOCUMENT_HANDLING_SELECT = WIA_DPS_FIRST + 14;
        }
        public static Device SelectDevice()
        {
            WIA.ICommonDialog dialog = new WIA.CommonDialog();
            try
            {
                WIA.Device device = dialog.ShowSelectDevice
                    (WIA.WiaDeviceType.ScannerDeviceType, true, false);
                return device;
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Use scanner to scan an image (with user selecting the scanner from a dialog).
        /// </summary>
        /// <returns>Scanned images path.</returns>
        public static List<string> Scan(DoWorkEventArgs e)
        {
            Device device = SelectDevice();
            if (device != null)
            {
                return Scan(device.DeviceID, e);
            }

            return null;
        }
        /// <summary>
        /// Use scanner to scan an image (scanner is selected by its unique id).
        /// </summary>
        /// <param name="scannerName"></param>
        /// <returns>Scanned images path.</returns>
        public static List<string> Scan(string scannerId, DoWorkEventArgs e)
        {
            List<string> images = new List<string>();
            bool hasMorePages = true;
            ITempFilesResource<ImageFile> tempFiles = TempFilesScannerResource<ImageFile>.DefaultInstance();
            while (hasMorePages && !e.Cancel)
            {
                // select the correct scanner using the provided scannerId parameter
                WIA.DeviceManager manager = new WIA.DeviceManager();
                WIA.Device device = null;
                foreach (WIA.DeviceInfo info in manager.DeviceInfos)
                {
                    if (info.DeviceID == scannerId)
                    {
                        // connect to scanner
                        device = info.Connect();
                        break;
                    }
                }
                // device was not found
                if (device == null)
                {
                    // enumerate available devices
                    string availableDevices = "";
                    foreach (WIA.DeviceInfo info in manager.DeviceInfos)
                    {
                        availableDevices += info.DeviceID + "\n";
                    }
                    // show error with available devices
                    throw new Exception("The device with provided ID could not be found. Available Devices:\n" + availableDevices);
                }
                WIA.Item item = device.Items[1] as WIA.Item;
                try
                {
                    // scan image
                    WIA.ICommonDialog wiaCommonDialog = new WIA.CommonDialog();
                    WIA.ImageFile image = (WIA.ImageFile)wiaCommonDialog.ShowTransfer(item, wiaFormatBMP, false);
                    // save to temp file
                    string fileName = tempFiles.SaveFile(image);
                    image = null;
                    // add file to output list
                    images.Add(fileName);
                }
                catch (System.Runtime.InteropServices.COMException exc)
                {
                    Debug.WriteLine(exc.Message);
                }
                catch (Exception exc)
                {
                    Debug.WriteLine(exc.Message);
                }
                finally
                {
                    item = null;
                    //determine if there are any more pages waiting
                    WIA.Property documentHandlingSelect = null;
                    WIA.Property documentHandlingStatus = null;
                    foreach (WIA.Property prop in device.Properties)
                    {
                        if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_SELECT)
                        {
                            documentHandlingSelect = prop;
                        }

                        if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_STATUS)
                        {
                            documentHandlingStatus = prop;
                        }
                    }
                    // assume there are no more pages
                    hasMorePages = false;
                    // may not exist on flatbed scanner but required for feeder
                    if (documentHandlingSelect != null)
                    {
                        // check for document feeder
                        if ((Convert.ToUInt32(documentHandlingSelect.get_Value()) &
                        WIA_DPS_DOCUMENT_HANDLING_SELECT.FEEDER) != 0)
                        {
                            hasMorePages = ((Convert.ToUInt32(documentHandlingStatus.get_Value()) &
                            WIA_DPS_DOCUMENT_HANDLING_STATUS.FEED_READY) != 0);
                        }
                    }
                }
            }
            if (!e.Cancel)
                return images;
            else
            {
                foreach (var image in images)
                {
                    tempFiles.DeleteFile(image);
                }
                images.Clear();
                return images;
            }
        }
        /// <summary>
        /// Gets the list of available WIA devices.
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDevices()
        {
            List<string> devices = new List<string>();
            WIA.DeviceManager manager = new WIA.DeviceManager();
            foreach (WIA.DeviceInfo info in manager.DeviceInfos)
            {
                devices.Add(info.DeviceID);
            }
            return devices;
        }

        /// <summary>
        /// Gets the infor of WIA devices.
        /// </summary>
        /// <returns> Dictionary key and value of properties of wia device</returns>
        public static Dictionary<string, string> GetDevicesProperty(string deviceid)
        {
            WIA.DeviceManager manager = new WIA.DeviceManager();
            DeviceInfo device = null;
            foreach (WIA.DeviceInfo info in manager.DeviceInfos)
            {
                if (info.DeviceID == deviceid)
                {
                    device = info;
                    break;
                }
            }
            if (device != null)
            {
                Dictionary<string, string> properties = new Dictionary<string, string>
                {
                    { nameof(device.DeviceID), device.DeviceID },
                    { nameof(device.Type), device.Type.ToString() }
                };
                foreach (Property p in device.Properties)
                {
                    properties.Add(p.Name, p.get_Value());
                }
                return properties;
            }
            return null;
        }
    }
}
