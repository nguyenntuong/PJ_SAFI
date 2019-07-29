using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCR.Models.Locals;

namespace OCR.DAO.Interfaces
{
    interface IROIProfilesResource
    {
        List<string> Profiles { get; }
        void AddOrUpdateRegionProfile(ROIProfile regionProfile);
        void DeleteRegionProfile(ROIProfile regionProfile);
        void DeleteRegionProfile(string regionProfileName);
        ROIProfile GetRegionProfile(string regionProfileName);
    }
}
