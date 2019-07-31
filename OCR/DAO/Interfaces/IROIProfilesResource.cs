using System.Collections.Generic;
using OCR.Models.Locals;

namespace OCR.DAO.Interfaces
{
    internal interface IROIProfilesResource
    {
        List<string> Profiles { get; }
        void AddOrUpdateRegionProfile(ROIProfile regionProfile);
        void DeleteRegionProfile(ROIProfile regionProfile);
        void DeleteRegionProfile(string regionProfileName);
        ROIProfile GetRegionProfile(string regionProfileName);
    }
}
