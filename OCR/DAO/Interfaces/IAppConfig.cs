using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR.DAO.Interfaces
{
    interface IAppConfig
    {
        T GetConfig<T>(string key);
        void SetConfig<T>(string key, T value);
    }
}
