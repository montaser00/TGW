using System;
using System.Collections.Generic;
using TGW_Mechanics___ConfigParser.Extensions;
using TGW_Mechanics___ConfigParser.Helpers;
using TGW_Mechanics___ConfigParser.Mapper;
using TGW_Mechanics___ConfigParser.Utilities;

namespace TGW_Mechanics___ConfigParser
{
    class Program
    {
        public static Action<string> Print = text => Console.WriteLine(text);

        static void Main(string[] args)
        {
            var files = new string[]
            {
                "Contents/Base_Config.txt",
                "Contents/Project_Config.txt"
            };

            //TestFunctionalities(files);
            FinalTest(files);
        }

        public static void FinalTest(string[] files)
        {
            // Now For Override.
            var configParserHelper = new ConfigParserHelper();

            int index = 0;
            List<string[]> linesBulk = new List<string[]>();
            while (index < files.Length)
            {
                string[] lines = ConfigReaderUtility.ReadConfigFile(files[index]).Data;
                linesBulk.Add(lines);
                index++;
            }

            var simulationConfiViewModel = configParserHelper.LoadAllConfigLayers(linesBulk);

            Print("--- Simulation Config:");
            Print(string.Empty);
            Print(simulationConfiViewModel.ToStringProperties("Error").ToJointString());

            // this is the model with correct data types.
            var simulationConfigModel = SimulationMapperUtility.MapToSimulationConfig(simulationConfiViewModel);

            Print(string.Empty);
            Print("--- Simulation Cofig After Convert to Model");
            Print(simulationConfigModel.ToStringProperties("Error").ToJointString());
        }
    }
}
