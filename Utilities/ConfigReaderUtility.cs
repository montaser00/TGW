using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGW_Mechanics___ConfigParser.Results;

namespace TGW_Mechanics___ConfigParser.Utilities
{
    public static class ConfigReaderUtility
    {
        #region Utility Methods
        public static Result<string[]> ReadConfigFile(string filePath)
        {
            var validationResult = ValidateFile(filePath);

            if (validationResult.Success)
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    return validationResult.WithData(lines).ToSucess();
                }
                catch(Exception ex)
                {
                    return validationResult.ToFail(ex.Message);
                }
            }
            else
            {
                return validationResult;
            }
        }

        public static Result<string[]> ValidateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new Result<string[]>().ToFail("File Does Not Exist!");
            }
            else
            {
                return new Result<string[]>().ToSucess();
            }
        }
        #endregion
    }
}
