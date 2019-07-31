using System.Collections.Generic;
using DirectShowLib;

namespace OCR.Utils.Helpers.DriverControls
{
    internal static class CameraControl
    {
        public static List<string> GetCameraDevice()
        {
            DsDevice[] systemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            List<string> devices = new List<string>();
            for (int i = 0; i < systemCamereas.Length; i++)
            {
                DsDevice cam = systemCamereas[i];
                devices.Add(cam.Name);
            }
            return devices;
        }
    }
}
