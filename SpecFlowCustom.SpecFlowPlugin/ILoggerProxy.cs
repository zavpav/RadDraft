using TechTalk.SpecFlow;

namespace SpecFlowCustom
{
    /// <summary>
    /// stub-stub-stub
    /// </summary>
    internal class ILoggerProxy
    {
        internal void Info(string v1, string v2, string featureTitle, string scenarioTitle)
        {
            Console.WriteLine(featureTitle + " " + scenarioTitle);
        }

        internal void Warn(string text)
        {
            Console.WriteLine(text);
        }

        internal void Debug(string text)
        {
            Console.WriteLine(text);
        }

        internal void Fatal(Exception ex, string text)
        {
            Console.WriteLine(text);
        }

        internal void Fatal(string text)
        {
            Console.WriteLine(text);
        }
    }
}