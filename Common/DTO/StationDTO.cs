using System;

namespace Common.DTO
{
    public class StationDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public Guid ControlTowerId { get; init; }
    }
}