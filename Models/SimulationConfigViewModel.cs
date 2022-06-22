using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGW_Mechanics___ConfigParser.Models
{
    public class SimulationConfigViewModel: IViewModel
    {
        #region Members
        public string Id { get; set; }

        public string OrdersPerHour { get; set; }

        public string OrderLinesPerOrder { get; set; }

        public string InboundStrategy { get; set; }

        public string PowerSupply { get; set; }

        public string ResultStartTime { get; set; }

        public string ResultInterval { get; set; }

        public string NumberOfAisles { get; set; }
        #endregion
    }
}
