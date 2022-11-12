namespace KTPO4311.Yablonskas.Lib.src.LogAn
{
    public interface ILogAnalyzer
    {
        event LogAnalyzerAction Analyzed;

        void Analyze(string filename);
        bool IsValidLogFileName(string filename);
    }
}