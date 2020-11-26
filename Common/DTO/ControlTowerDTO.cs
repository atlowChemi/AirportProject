using Common.Models;
using System;

namespace Common.DTO
{
    public class ControlTowerDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }

        public static ControlTowerDTO FromDBModel(ControlTower controlTower)
        {
            return new(){ Id = controlTower.Id, Name = controlTower.Name };
        }
    }
}