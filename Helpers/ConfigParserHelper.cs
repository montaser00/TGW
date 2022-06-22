using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGW_Mechanics___ConfigParser.Extensions;
using TGW_Mechanics___ConfigParser.Models;

namespace TGW_Mechanics___ConfigParser.Helpers
{
    public class ConfigParserHelper
    {
        #region Members
        public List<SimulationConfig> ConfigLayers { get; set; }
        public string Separator { get; set; } = ":";
        public string CommentSign { get; set; } = "//";
        public List<string> IgnoreConfigLinesSigns { get; set; } = new List<string> { "==="};
        public string HeaderSectionStart { get; set; } = "-";
        #endregion

        #region Public Methods
        public SimulationConfigViewModel LoadConfigLayer(string[] configLines)
        {
            string[] validConfigLines = IgnoreNonConfigLines(configLines);
            validConfigLines = IgnoreComments(validConfigLines);
            validConfigLines = IgnoreEmptyLines(validConfigLines);

            var simulationConfig = new SimulationConfigViewModel();

            var configProperties = ParseKeyValueConfig(validConfigLines);

            simulationConfig.AssignValuesToObject(configProperties);

            return simulationConfig;
        }

        public SimulationConfigViewModel LoadAllConfigLayers(List<string[]> configfiles)
        {
            var simConfig = new SimulationConfigViewModel();

            foreach(var configFile in configfiles)
            {
                var layer = LoadConfigLayer(configFile);
                simConfig = (SimulationConfigViewModel)simConfig.OverrideFrom(layer);
            }

            simConfig.Id = Guid.NewGuid().ToString();
            return simConfig;
        }
        #endregion

        #region Private Methods
        public string[] IgnoreNonConfigLines(string[] configLines)
        {
            return configLines.ToList().Where(configLine => 
            configLine.Contains(Separator) &&
            char.IsLetter(configLine[0])
            ).ToArray();
        }

        public string[] IgnoreComments(string[] configLines)
        {
            return configLines.ToList().Select(line =>
            {
                if (line.Contains(CommentSign))
                {
                    line = line.Substring(0, line.IndexOf(CommentSign) - 1);
                }
                return line;
            }).ToArray();
        }

        public string[] IgnoreEmptyLines(string[] configLines)
        {
            return configLines.ToList().Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
        }

        public List<KeyValuePair<string, string>> ParseKeyValueConfig(string[] lines)
        {
            var result = new List<KeyValuePair<string, string>>();

            Array.ForEach(lines, line =>
            {
                var config = line.Split(':');
                if(config.Length >= 2)
                {
                    var property = config[0].Trim();
                    property = Char.ToUpper(property[0]) + property.Substring(1, property.Length -1);
                    var value = Convert.ToInt32(config.Length > 2) switch
                    {
                        1 => GetTime(config),
                        0 => config[1]
                    };
                    result.Add(new KeyValuePair<string, string>(property, value));
                }
            });
            return result;
        }

        private string GetTime(string[] value)
        {
            string[] newValue = new string[value.Length - 1];
            for(int index = 0; index < newValue.Length; index++)
            {
                newValue[index] = value[index+1];
            }

            return string.Join(':', newValue);
        }

        private SimulationConfigViewModel Override(SimulationConfigViewModel vm, SimulationConfigViewModel newVM)
        {
            return (SimulationConfigViewModel)vm.OverrideFrom(newVM);
        }

        #endregion
    }
}
