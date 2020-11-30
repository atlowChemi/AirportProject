﻿using System;
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
        public const int MAXIMAL_FLIGHT_CREATION_DELAY = 16;
        public const int MINIMAL_STATION_DELAY = 5 * ONE_SECOND_IN_MS;
        public const int MAXIMAL_STATION_DELAY = 13 * ONE_SECOND_IN_MS;
        public const int ONE_SECOND_IN_MS = 1000;
        public static readonly IReadOnlyList<string> AVAILABLE_AIRPORTS = new string[] { "JFK", "IST", "SAW", "STN", "LTN", "ATH" };
        public const string DATABASE_NAME = "airport.db";
        public const string CORS_POLICY_NAME = "SignalRCorsPolicy";
    }
}