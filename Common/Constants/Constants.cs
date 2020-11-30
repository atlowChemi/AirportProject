using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Constants
{
    public static class Constants
    {
        public const string CONTROL_TOWER_NAME = "TLV";
        public const int MINIMAL_FLIGHT_DELAY = 15;
        public const int MAXIMAL_FLIGHT_DELAY = 35;
        public const int MINIMAL_FLIGHT_CREATION_DELAY = 8;
        public const int MAXIMAL_FLIGHT_CREATION_DELAY = 22;
        public const int ONE_SECOND_IN_MS = 1000;
        public static readonly IReadOnlyList<string> AVAILABLE_AIRPORTS = new string[] { "JFK", "IST", "SAW", "STN", "LTN", "ATH" };
    }
}
