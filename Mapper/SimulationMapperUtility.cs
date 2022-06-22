using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGW_Mechanics___ConfigParser.Extensions;
using TGW_Mechanics___ConfigParser.Models;

namespace TGW_Mechanics___ConfigParser.Mapper
{
    public static class SimulationMapperUtility
    {
        #region MyRegion
        
        public static SimulationConfig MapToSimulationConfig(SimulationConfigViewModel vm)
        {
            var simConfig = new SimulationConfig();
            simConfig = (SimulationConfig)simConfig
                .AssignPropertyValue<int>("OrdersPerHour", vm.OrdersPerHour)
                .AssignPropertyValue<int>("OrderLinesPerOrder", vm.OrderLinesPerOrder)
                .AssignPropertyValue<string>("InboundStrategy", vm.InboundStrategy)
                .AssignPropertyValue<string>("PowerSupply", vm.PowerSupply)
                .AssignPropertyValue<string>("ResultStartTime", vm.ResultStartTime)
                .AssignPropertyValue<int>("ResultInterval", vm.ResultInterval)
                .AssignPropertyValue<int>("NumberOfAisles", vm.NumberOfAisles);

            return simConfig;
        } 

        #endregion
    }
}
