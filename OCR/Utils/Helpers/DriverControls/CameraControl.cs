using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectShowLib;

namespace OCR.Utils.Helpers.DriverControls
{
    static class CameraControl
    {
        public static List<string> GetCameraDevice()
        {
            DsDevice[] systemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            List<string> devices = new List<string>();
            for (int i = 0; i < systemCamereas.Length; i++)
            {
                var cam = systemCamereas[i];
                devices.Add(cam.Name);
            }
            return devices;
        }
    }
}
