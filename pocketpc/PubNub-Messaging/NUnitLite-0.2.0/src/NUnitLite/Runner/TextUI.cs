// *****************************************************
// Copyright 2007, Charlie Poole
//
// Licensed under the Open Software License version 3.0
// *****************************************************

using System;
using System.IO;
using System.Collections;
using System.Reflection;
using NUnit.Framework;

namespace NUnitLite.Runner
{
    /// <summary>
    /// A version of TextUI that outputs to the console.
    /// If you use it on a device without a console like
    /// PocketPC or SmartPhone you won't see anything!
    /// 
    /// Call it from your Main like this:
    ///   new ConsoleUI().Execute(args);
    /// </summary>
    public class ConsoleUI : TextUI
    {
#if NETCF_1_0
        public ConsoleUI() : base(ConsoleWriter.Out) { }
#else
        public ConsoleUI() : base(Console.Out) { }
#endif
    }

    /// <summary>
    /// A version of TextUI that displays to debug.
    /// 
    /// Call it from your Main like this:
    ///   new DebugUI().Execute(args);
    /// </summary>
    public class DebugUI : TextUI
    {
        public DebugUI() : base(DebugWriter.Out) { }
    }

    /// <summary>
    /// TextUI is a general purpose class that runs tests and
    /// outputs to a TextWriter.
    /// 
    /// Call it from your Main like this:
    ///   new TextUI(textWriter).Execute(args);
    /// </summary>
    public class TextUI
    {
        private CommandLineOptions options;
        private int reportCount = 0;

        private ArrayList assemblies = new ArrayList();

        private TextWriter writer;

        private TestRunner runner = new TestRunner();

        #region Constructors
        public TextUI(TextWriter writer)
        {
            this.writer = writer;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Execute a test run based on the aruments passed
        /// from Main.
        /// </summary>
        /// <param name="args">An array of arguments</param>
        public void Execute(string[] args)
        {
            // NOTE: This must be directly called from the
            // test assembly in order for the mechanism to work.
            Assembly callingAssembly = Assembly.GetCallingAssembly();

            this.options = ProcessArguments( args );

            if (!options.Help && !options.Error)
            {
                if (options.Wait && !(this is ConsoleUI))
                    writer.WriteLine("Ignoring /wait option - only valid for Console");

                try
                {
                    foreach (string name in options.Parameters)
                        assemblies.Add(Assembly.Load(name));

                    if (assemblies.Count == 0)
                        assemblies.Add(callingAssembly);

                    foreach (Assembly assembly in assemblies)
                        if (options.TestCount == 0)
                            Run(assembly);
                        else
                            Run(assembly, options.Tests);
                }
                catch (TestRunnerException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch (FileNotFoundException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.ToString());
                }
                finally
                {
                    if (options.Wait && this is ConsoleUI)
                    {
                        Console.WriteLine("Press Enter key to continue . . .");
                        Console.ReadLine();
                    }
                }
            }
        }

        public void Run(Assembly assembly)
        {
            ReportResults( runner.Run(assembly) );
        }

        public void Run(Assembly assembly, string[] tests)
        {
            ReportResults( runner.Run(assembly, tests) );
        }

        private void ReportResults( TestResult result )
        {
            ResultSummary summary = new ResultSummary(result);

            writer.WriteLine("{0} Tests : {1} Errors, {2} Failures, {3} Not Run",
                summary.TestCount, summary.ErrorCount, summary.FailureCount, summary.NotRunCount);

            if (summary.ErrorCount + summary.FailureCount > 0)
                PrintErrorReport(result);

            if (summary.NotRunCount > 0)
                PrintNotRunReport(result);
        }
        #endregion

        #region Helper Methods
        private CommandLineOptions ProcessArguments(string[] args)
        {
            this.options = new CommandLineOptions();
            options.Parse(args);

            if (!options.Nologo)
                WriteCopyright();

            if (options.Help)
                writer.Write(options.HelpText);
            else if (options.Error)
                writer.WriteLine(options.ErrorMessage);

            return options;
        }

        private void WriteCopyright()
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            System.Version version = executingAssembly.GetName().Version;

#if NETCF_1_0
            writer.WriteLine("NUnitLite version {0}", version.ToString() );
            writer.WriteLine("Copyright 2007, Charlie Poole");
#else
            object[] objectAttrs = executingAssembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            AssemblyProductAttribute productAttr = (AssemblyProductAttribute)objectAttrs[0];

            objectAttrs = executingAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            AssemblyCopyrightAttribute copyrightAttr = (AssemblyCopyrightAttribute)objectAttrs[0];

            writer.WriteLine(String.Format("{0} version {1}", productAttr.Product, version.ToString(3)));
            writer.WriteLine(copyrightAttr.Copyright);
#endif
            writer.WriteLine();

            string clrPlatform = Type.GetType("Mono.Runtime", false) == null ? ".NET" : "Mono";
            writer.WriteLine("Runtime Environment -");
            writer.WriteLine("    OS Version: {0}", Environment.OSVersion);
            writer.WriteLine("  {0} Version: {1}", clrPlatform, Environment.Version);
            writer.WriteLine();
        }

        private void PrintErrorReport(TestResult result)
        {
            reportCount = 0;
            writer.WriteLine();
            writer.WriteLine("Errors and Failures:");
            PrintErrorResults(result);
        }

        private void PrintErrorResults(TestResult result)
        {
            if (result.Results.Count > 0)
                foreach (TestResult r in result.Results)
                    PrintErrorResults(r);
            else if (result.IsError || result.IsFailure)
            {
                writer.WriteLine();
                writer.WriteLine("{0}) {1} ({2})", ++reportCount, result.Test.Name, result.Test.FullName);
                if (options.ListProperties)
                    PrintTestProperties(result.Test);
                writer.WriteLine(result.Message);
#if !NETCF_1_0
                writer.WriteLine(result.StackTrace);
#endif
            }
        }

        private void PrintNotRunReport(TestResult result)
        {
            reportCount = 0;
            writer.WriteLine();
            writer.WriteLine("Errors and Failures:");
            PrintNotRunResults(result);
        }

        private void PrintNotRunResults(TestResult result)
        {
            if (result.Results != null)
                foreach (TestResult r in result.Results)
                    PrintNotRunResults(r);
            else if (result.ResultState == ResultState.NotRun)
            {
                writer.WriteLine();
                writer.WriteLine("{0}) {1} ({2}) : {3}", ++reportCount, result.Test.Name, result.Test.FullName, result.Message);
                if (options.ListProperties)
                    PrintTestProperties(result.Test);
            }
        }

        private void PrintTestProperties(ITest test)
        {
            foreach (DictionaryEntry entry in test.Properties)
                writer.WriteLine("  {0}: {1}", entry.Key, entry.Value);            
        }
        #endregion
    }
}
