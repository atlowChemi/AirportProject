using Common.Enums;
using Common.Models;
using System;

namespace DAL.DummyData
{
    public static class PrePopulateData
    {
        public static readonly Airplane[] Airplanes =
        {
            new Airplane{ Id = 1, AirLine = "El Al" },
            new Airplane{ Id = 2, AirLine = "Lufthansa" },
            new Airplane{ Id = 3, AirLine = "United" },
            new Airplane{ Id = 4, AirLine = "Frontier" },
            new Airplane{ Id = 5, AirLine = "Ryan air" },
            new Airplane{ Id = 6, AirLine = "Blue air" },
            new Airplane{ Id = 7, AirLine = "Air France" },
            new Airplane{ Id = 8, AirLine = "SWISS" },
            new Airplane{ Id = 9, AirLine = "Turkish Airlines" },
        };

        private static readonly Guid[][] guids = {
            new Guid[]
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
            },
            new Guid[]
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
            },
            new Guid[]
            {
                Guid.NewGuid(),
            },
        };

        public static readonly Flight[] Flights =
        {
            new Flight { Id = guids[0][0], AirplaneId = 1, Direction = FlightDirection.Landing, From = "JFK", To = "TLV", PlannedTime = new DateTime(2020, 11, 15, 4, 18, 0), ControlTowerId = guids[2][0] },
            new Flight { Id = guids[0][1], AirplaneId = 2, Direction = FlightDirection.Landing, From = "IST", To = "TLV", PlannedTime = new DateTime(2020, 11, 15, 4, 24, 57), ControlTowerId = guids[2][0] },
            new Flight { Id = guids[0][2], AirplaneId = 3, Direction = FlightDirection.Landing, From = "SAW", To = "TLV", PlannedTime = new DateTime(2020, 11, 15, 4, 26, 18), ControlTowerId = guids[2][0] },
            new Flight { Id = guids[0][3], AirplaneId = 4, Direction = FlightDirection.Landing, From = "STN", To = "TLV", PlannedTime = new DateTime(2020, 11, 15, 4, 31, 6), ControlTowerId = guids[2][0] },
            new Flight { Id = guids[0][4], AirplaneId = 1, Direction = FlightDirection.Takeoff, From = "TLV", To = "ATH", PlannedTime = new DateTime(2020, 11, 15, 4, 17, 34), ControlTowerId = guids[2][0] },
            new Flight { Id = guids[0][5], AirplaneId = 2, Direction = FlightDirection.Takeoff, From = "TLV", To = "LTN", PlannedTime = new DateTime(2020, 11, 15, 4, 36, 29), ControlTowerId = guids[2][0] },
        };

        public static readonly Station[] Stations =
        {
            new Station { Id = guids[1][0], ControlTowerId = guids[2][0], Name = "Land port 1", CurrentFlightId = guids[0][2] }, // LandingStations = new List<Guid> { guids[1][1], guids[1][2], }
            new Station { Id = guids[1][1], ControlTowerId = guids[2][0], Name = "Drop passengers", }, // LandingStations = new List<Guid> { guids[1][3], }
            new Station { Id = guids[1][2], ControlTowerId = guids[2][0], Name = "Drop passengers", }, // LandingStations = new List<Guid> { guids[1][3], } 
            new Station { Id = guids[1][3], ControlTowerId = guids[2][0], Name = "Drop lugage",  }, // LandingStations = new List<Guid> { guids[1][4] }
            new Station { Id = guids[1][4], ControlTowerId = guids[2][0], Name = "Refuel",  }, // TakeoffStations = new List<Guid> { guids[1][6] }
            new Station { Id = guids[1][5], ControlTowerId = guids[2][0], Name = "Takeoff port 1", }, // TakeoffStations = new List<Guid> { guids[1][4] } 
            new Station { Id = guids[1][6], ControlTowerId = guids[2][0], Name = "Pick lugage",  }, // TakeoffStations = new List<Guid> { guids[1][7], guids[1][8], }, 
            new Station { Id = guids[1][7], ControlTowerId = guids[2][0], Name = "Pick passengers",  }, // TakeoffStations = new List<Guid> { guids[1][9] },
            new Station { Id = guids[1][8], ControlTowerId = guids[2][0], Name = "Pick passengers",  }, // TakeoffStations = new List<Guid> { guids[1][9] },
            new Station { Id = guids[1][9], ControlTowerId = guids[2][0], Name = "Takeoff", CurrentFlightId = guids[0][5] },
        };

        public static readonly StationRelation[] StationRelations =
        {
            new StationRelation { Direction = FlightDirection.Landing, StationFromId = guids[1][0], StationToId = guids[1][1] },
            new StationRelation { Direction = FlightDirection.Landing, StationFromId = guids[1][0], StationToId = guids[1][2] },
            new StationRelation { Direction = FlightDirection.Landing, StationFromId = guids[1][1], StationToId = guids[1][3] },
            new StationRelation { Direction = FlightDirection.Landing, StationFromId = guids[1][2], StationToId = guids[1][3] },
            new StationRelation { Direction = FlightDirection.Landing, StationFromId = guids[1][3], StationToId = guids[1][4] },
            new StationRelation { Direction = FlightDirection.Takeoff, StationFromId = guids[1][4], StationToId = guids[1][6] },
            new StationRelation { Direction = FlightDirection.Takeoff, StationFromId = guids[1][5], StationToId = guids[1][4] },
            new StationRelation { Direction = FlightDirection.Takeoff, StationFromId = guids[1][6], StationToId = guids[1][7] },
            new StationRelation { Direction = FlightDirection.Takeoff, StationFromId = guids[1][6], StationToId = guids[1][8] },
            new StationRelation { Direction = FlightDirection.Takeoff, StationFromId = guids[1][7], StationToId = guids[1][9] },
            new StationRelation { Direction = FlightDirection.Takeoff, StationFromId = guids[1][8], StationToId = guids[1][9] },
        };

        public static readonly FlightHistory[] FlightHistories =
        {

            #region Flight 0
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][0], StationId = guids[1][0], EnterStationTime = new DateTime(2020, 11, 15, 4, 18, 30), LeaveStationTime = new DateTime(2020, 11, 15, 4, 22, 14) },
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][0], StationId = guids[1][2], EnterStationTime = new DateTime(2020, 11, 15, 4, 22, 14), LeaveStationTime = new DateTime(2020, 11, 15, 4, 23, 07) },
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][0], StationId = guids[1][3], EnterStationTime = new DateTime(2020, 11, 15, 4, 23, 07), LeaveStationTime = new DateTime(2020, 11, 15, 4, 26, 38) },
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][0], StationId = guids[1][4], EnterStationTime = new DateTime(2020, 11, 15, 4, 26, 38), LeaveStationTime = new DateTime(2020, 11, 15, 4, 27, 20) },
            #endregion

            #region Flight 1
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][1], StationId = guids[1][0], EnterStationTime = new DateTime(2020, 11, 15, 4, 24, 48), LeaveStationTime = new DateTime(2020, 11, 15, 4, 25, 31) },
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][1], StationId = guids[1][1], EnterStationTime = new DateTime(2020, 11, 15, 4, 25, 31), LeaveStationTime = new DateTime(2020, 11, 15, 4, 30, 1) },
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][1], StationId = guids[1][3], EnterStationTime = new DateTime(2020, 11, 15, 4, 30, 1), LeaveStationTime = new DateTime(2020, 11, 15, 4, 34, 12) },
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][1], StationId = guids[1][4], EnterStationTime = new DateTime(2020, 11, 15, 4, 34, 12), LeaveStationTime = new DateTime(2020, 11, 15, 4, 38, 10) },
            #endregion

            #region Flight 2
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][2], StationId = guids[1][0], EnterStationTime = new DateTime(2020, 11, 15, 4, 26, 38), },
            #endregion

            #region Flight 4
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][4], StationId = guids[1][5], EnterStationTime = new DateTime(2020, 11, 15, 4, 18, 46), LeaveStationTime = new DateTime(2020, 11, 15, 4, 20, 20) },
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][4], StationId = guids[1][4], EnterStationTime = new DateTime(2020, 11, 15, 4, 20, 20), LeaveStationTime = new DateTime(2020, 11, 15, 4, 23, 21) },
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][4], StationId = guids[1][6], EnterStationTime = new DateTime(2020, 11, 15, 4, 23, 21), LeaveStationTime = new DateTime(2020, 11, 15, 4, 24, 19) },
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][4], StationId = guids[1][7], EnterStationTime = new DateTime(2020, 11, 15, 4, 24, 19), LeaveStationTime = new DateTime(2020, 11, 15, 4, 28, 39) },
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][4], StationId = guids[1][9], EnterStationTime = new DateTime(2020, 11, 15, 4, 28, 39), LeaveStationTime = new DateTime(2020, 11, 15, 4, 29, 3) },
            #endregion

            #region Flight 5
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][5], StationId = guids[1][5], EnterStationTime = new DateTime(2020, 11, 15, 5, 38, 16), LeaveStationTime = new DateTime(2020, 11, 15, 5, 40, 9) },
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][5], StationId = guids[1][4], EnterStationTime = new DateTime(2020, 11, 15, 5, 40, 9), LeaveStationTime = new DateTime(2020, 11, 15, 5, 42, 47) },
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][5], StationId = guids[1][6], EnterStationTime = new DateTime(2020, 11, 15, 5, 42, 47), LeaveStationTime = new DateTime(2020, 11, 15, 5, 44, 31) },
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][5], StationId = guids[1][8], EnterStationTime = new DateTime(2020, 11, 15, 5, 44, 31), LeaveStationTime = new DateTime(2020, 11, 15, 5, 48, 57) },
            new FlightHistory { Id = Guid.NewGuid(), FlightId = guids[0][5], StationId = guids[1][9], EnterStationTime = new DateTime(2020, 11, 15, 5, 48, 57) },
            #endregion

            
        };

        public static readonly ControlTower[] ControlTowers =
        {
            new ControlTower{ Id= guids[2][0], Name = "TLV" },
        };

        public static readonly StationControlTowerRelation[] StationControlTowerRelations =
        {
            new StationControlTowerRelation { Direction = FlightDirection.Landing, ControlTowerId = guids[2][0], StationToId = guids[1][0] },
            new StationControlTowerRelation { Direction = FlightDirection.Takeoff, ControlTowerId = guids[2][0], StationToId = guids[1][5], },
        };
    }
}
