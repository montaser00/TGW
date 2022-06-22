using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGW_Mechanics___ConfigParser.Models
{
    public class SimulationConfig: IBaseModel
    {
        #region Properties

        public Guid Id { get; } = Guid.NewGuid();

        public int? OrdersPerHour { get; set; }

        public int? OrderLinesPerOrder { get; set; }

        public string InboundStrategy { get; set; }

        public string PowerSupply { get; set; }

        public string ResultStartTime { get; set; }

        public int? ResultInterval { get; set; }

        public int? NumberOfAisles { get; set; }

        #endregion
    }
}
