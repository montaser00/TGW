using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGW_Mechanics___ConfigParser.Models;

namespace TGW_Mechanics___ConfigParser.Interfaces
{
    public interface IConfigService
    {
        #region Interface Members
        /// <summary>
        /// Files Paths For Config Layers Index Zero Contains The Base Config (Layer 1), Then (Layer2) ...
        /// </summary>
        /// <param name="filesPaths"></param>
        /// <returns></returns>
        Task<SimulationConfig> LoadSimulationConfig(string[] filesPaths);
        #endregion
    }
}
