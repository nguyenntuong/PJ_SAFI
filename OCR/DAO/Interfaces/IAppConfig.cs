namespace OCR.DAO.Interfaces
{
    internal interface IAppConfig
    {
        T GetConfig<T>(string key);
        void SetConfig<T>(string key, T value);
    }
}
