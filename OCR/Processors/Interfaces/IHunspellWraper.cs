namespace OCR.Processors.Interfaces
{
    internal interface IHunspellWraper
    {
        string SpellCheck(string word);
        string SpellChecks(string words);
    }
}
