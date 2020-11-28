using Common.Models;

namespace Common.DTO
{
    public class AirplaneDTO
    {
        public int Id { get; init; }
        public string AirLine { get; init; }

        public static AirplaneDTO FromDBModel(Airplane airplane)
        {
            return new() { Id = airplane.Id, AirLine = airplane.AirLine };
        }
    }
}
