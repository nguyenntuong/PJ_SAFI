using System.Collections.Generic;
using OCR.Models.Locals;

namespace OCR.DAO.Interfaces
{
    internal interface IPaperResource
    {
        List<string> Profiles { get; }
        void AddOrUpdatePaperProfile(PaperProfile paperProfile);
        void DeletePaperProfile(PaperProfile paperProfile);
        void DeletePaperProfile(string paperProfileName);
        PaperProfile GetPaperProfile(string paperProfileName);
    }
}
