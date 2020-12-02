using Common.Enums;
using Common.Models;
using System;

namespace Common.DTO
{
    /// <summary>
    /// A DTO for the <see cref="Flight"/> class.
    /// </summary>
    public class FlightDTO
    {
        /// <summary>
        /// The ID of the flight.
        /// </summary>
        public Guid Id { get; init; }
        /// <summary>
        /// Name of <see cref="ControlTower">control tower</see> flight is directed to.
        /// </summary>
        public string To { get; init; }
        /// <summary>
        /// Name of <see cref="ControlTower">control tower</see> flight departed from.
        /// </summary>
        public string From { get; init; }
        /// <summary>
        /// The planned takeoff/landing time at requested <see cref="ControlTower">Control Tower</see>.
        /// </summary>
        public DateTime PlannedTime { get; init; }
        /// <summary>
        /// The <see cref="FlightDirection">direction</see> this flight is moving to in relation to the given <see cref="Models.ControlTower">Control Tower</see>
        /// </summary>
        public FlightDirection Direction { get; init; }
        /// <summary>
        /// Id of the <see cref="Airplane" /> taking this flight.
        /// </summary>
        public int AirplaneId { get; init; }
        /// <summary>
        /// Id of the <see cref="ControlTower">Control Tower</see> this flight is related to.
        /// </summary>
        public Guid? ControlTowerId { get; init; }
        /// <summary>
        /// The <see cref="Station">Station</see> this flight is currently at.
        /// </summary>
        public Guid? StationId { get; init; }
        /// <summary>
        /// Is the flight currnetly in a station, or waiting to enter stations.
        /// </summary>
        public bool IsWaiting => !StationId.HasValue;



        /// <summary>
        /// Genrate DTO object from a DB model.
        /// </summary>
        /// <param name="flight">The <see cref="Flight"/> to generate a DTO of.</param>
        /// <returns>A new FlightDTO instance.</returns>
        public static FlightDTO FromDBModel(Flight flight)
        {
            return new()
            {
                Id = flight.Id,
                To = flight.To,
                From = flight.From,
                PlannedTime = flight.PlannedTime,
                Direction = flight.Direction,
                AirplaneId = flight.AirplaneId,
                ControlTowerId = flight.ControlTowerId,
                StationId = flight.StationId
            };
        }
        /// <summary>
        /// Genrate DM model object from a DTO object.
        /// </summary>
        /// <param name="flight">The <see cref="FlightDTO"/> to generate a DB model of.</param>
        /// <returns>A new Flight instance.</returns>
        public static Flight ToDBModel(FlightDTO flight)
        {
            return new()
            {
                Id = flight.Id,
                To = flight.To,
                From = flight.From,
                PlannedTime = flight.PlannedTime,
                Direction = flight.Direction,
                AirplaneId = flight.AirplaneId,
                ControlTowerId = flight.ControlTowerId,
                StationId = flight.StationId
            };
        }
    }
}