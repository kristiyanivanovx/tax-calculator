using System;
using System.Collections.Generic;
using System.Text;

using TaxCalculator.Core.Contracts;
using TaxCalculator.Core.Providers;
using TaxCalculator.Models.Contracts;

namespace TaxCalculator.Core
{
    public class Engine : IEngine
    {
        private static IEngine instanceHolder;

        private const string TerminationCommand = "Exit";

        private Engine()
        {
            this.Reader = new ConsoleReader();
            this.Writer = new ConsoleWriter();
            this.Parser = new CommandParser();
        }

        public static IEngine Instance
        {
            get
            {
                if (instanceHolder == null)
                {
                    instanceHolder = new Engine();
                }

                return instanceHolder;
            }
        }

        public IReader Reader { get; set; }

        public IWriter Writer { get; set; }

        public IParser Parser { get; set; }

        public ITaxCalculator TaxCalculator { get; set; }

        public void Start()
        {
            while (true)
            {
                try
                {
                    string command = this.Reader.ReadLine();
            
                    if (command.ToLower() == TerminationCommand.ToLower())
                    {
                        break;
                    }
            
                    this.ProcessCommand(command);
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.Parser.ParseCommand(commandAsString);
            var parameters = this.Parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.Writer.WriteLine(executionResult);
        }
    }
}
