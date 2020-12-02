using Common.Models;
using System.Collections.Generic;

namespace Common.Constants
{
    /// <summary>
    /// Constant variable used through out the solution.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The name of control tower currently used.
        /// </summary>
        public const string CONTROL_TOWER_NAME = "TLV";
        /// <summary>
        /// The minimal amount of seconds to delay the <see cref="Flight.PlannedTime">flight planned time</see>.
        /// </summary>
        public const int MINIMAL_FLIGHT_DELAY = 15;
        /// <summary>
        ///  The maximal amount of seconds to delay the <see cref="Flight.PlannedTime">flight planned time</see>.
        /// </summary>
        public const int MAXIMAL_FLIGHT_DELAY = 35;
        /// <summary>
        /// The minimal delay between flight creation.
        /// </summary>
        public const int MINIMAL_FLIGHT_CREATION_DELAY = 8;
        /// <summary>
        /// The maximal delay between flight creation.
        /// </summary>
        public const int MAXIMAL_FLIGHT_CREATION_DELAY = 16;
        /// <summary>
        /// The amount of milliseconds one second has. Guess what, it's 1000!
        /// </summary>
        public const int ONE_SECOND_IN_MS = 1000;
        /// <summary>
        /// The minimal amount of seconds to <see cref="Station"/> will delay the <see cref="Flight">flights</see> who arrived to it.
        /// </summary>
        public const int MINIMAL_STATION_DELAY = 5 * ONE_SECOND_IN_MS;
        /// <summary>
        /// The maximal amount of seconds to <see cref="Station"/> will delay the <see cref="Flight">flights</see> who arrived to it.
        /// </summary>
        public const int MAXIMAL_STATION_DELAY = 13 * ONE_SECOND_IN_MS;
        /// <summary>
        /// List of available control towers a generated flight should pick from.
        /// </summary>
        public static readonly IReadOnlyList<string> AVAILABLE_AIRPORTS = new string[] { "JFK", "IST", "SAW", "STN", "LTN", "ATH" };
        /// <summary>
        /// The name of the SQLite db file.
        /// </summary>
        public const string DATABASE_NAME = "airport.db";
        /// <summary>
        /// The name used for the CORS policy.
        /// </summary>
        public const string CORS_POLICY_NAME = "SignalRCorsPolicy";
        /// <summary>
        /// The error message to show for a 500 error in server.
        /// </summary>
        public const string UNKNOWN_ERROR_MSG = "Some unknown error happened, please try again.";
        /// <summary>
        /// The response to use for a succesfull response.
        /// </summary>
        public const string RESPONSE_TYPE_SUCCESS = "Success";
        /// <summary>
        /// The response to use for a failure response.
        /// </summary>
        public const string RESPONSE_TYPE_FAILURE = "Failure";
    }
}
