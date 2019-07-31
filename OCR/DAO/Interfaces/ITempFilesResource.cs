namespace OCR.DAO.Interfaces
{
    internal interface ITempFilesResource<T>
    {
        string SaveFile(T ob);
        string GetFullPath(string fileName);
        bool DeleteFile(string fileName);
    }
}
