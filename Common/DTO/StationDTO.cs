using Common.Models;
using System;

namespace Common.DTO
{
    public class StationDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public Guid ControlTowerId { get; init; }


        public static StationDTO FromDBModel(Station station)
        {
            return new()
            {
                Id = station.Id,
                Name = station.Name,
                ControlTowerId = station.ControlTowerId
            };
        }
    }
}