using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCR.Models.Locals;

namespace OCR.DAO.Interfaces
{
    interface IPaperResource
    {
        List<string> Profiles { get; }
        void AddOrUpdatePaperProfile(PaperProfile paperProfile);
        void DeletePaperProfile(PaperProfile paperProfile);
        void DeletePaperProfile(string paperProfileName);
        PaperProfile GetPaperProfile(string paperProfileName);
    }
}
