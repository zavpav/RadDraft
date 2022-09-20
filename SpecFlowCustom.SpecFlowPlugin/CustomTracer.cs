using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.Bindings.Reflection;
using TechTalk.SpecFlow.Tracing;

namespace SpecFlowCustom;

public class CustomTracer : ITestTracer
{
    private static int Level = 0;
    private static Regex ReUpLevel = new Regex(@"^Выполняем сценарий '[^']+'$");
    private static int Spaces = 5;

    private static ILoggerProxy Logger = new ILoggerProxy();


    [DebuggerStepThrough]
    public void TraceStep(StepInstance stepInstance, bool showAdditionalArguments)
    {
        Logger.Info(new string(' ', Spaces * Level) + (stepInstance.Keyword == "И " ? "    " : "") + "{Степ} [{Фича}: {Сценарий}]",
                            stepInstance.Keyword + " " + stepInstance.Text,
                            stepInstance.StepContext.FeatureTitle,
                            stepInstance.StepContext.ScenarioTitle);

        if (ReUpLevel.IsMatch(stepInstance.Text))
            Level++;
    }

    [DebuggerStepThrough]
    public void TraceWarning(string text)
    {
        if (text == "The previous ScenarioContext was not disposed.")
            return;

        Logger.Warn(text);
    }

    [DebuggerStepThrough]
    public void TraceStepDone(BindingMatch match, object[] arguments, TimeSpan duration)
    {
        if (match.StepBinding.Regex.ToString() == "^Выполняем сценарий '(.*)'$")
            Level--;

        Logger.Debug("                                                              Specflow " + new string(' ', Spaces * Level) + "Окончание выполнения " + match.StepBinding.Method.Name + " время " + duration);
    }

    [DebuggerStepThrough]
    public void TraceStepSkipped()
    {
        Logger.Warn("                                                      TraceStepSkipped");
    }

    [DebuggerStepThrough]
    public void TraceStepPending(BindingMatch match, object[] arguments)
    {
        Logger.Warn("                                                      TraceStepPending");
    }

    [DebuggerStepThrough]
    public void TraceBindingError(BindingException ex)
    {
        Logger.Fatal(ex, "Ошибка выполнения тестов TraceBindingError");
    }

    [DebuggerStepThrough]
    public void TraceError(Exception ex, TimeSpan duration)
    {
        Logger.Fatal(ex, "Ошибка выполнения тестов TraceError");
    }

    [DebuggerStepThrough]
    public void TraceNoMatchingStepDefinition(StepInstance stepInstance, ProgrammingLanguage targetLanguage, CultureInfo bindingCulture, List<BindingMatch> matchesWithoutScopeCheck)
    {
        Logger.Fatal("Ошибка-ошибка TraceNoMatchingStepDefinition");
    }

    [DebuggerStepThrough]
    public void TraceDuration(TimeSpan elapsed, IBindingMethod method, object[] arguments)
    {
        Logger.Debug("                                                              Specflow " + method.Name + " " + elapsed);
    }

    [DebuggerStepThrough]
    public void TraceDuration(TimeSpan elapsed, string text)
    {
        Logger.Debug("                                                              Specflow " + text + " " + elapsed);
    }

}