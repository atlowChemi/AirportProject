using Common.Models;
using Common.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ControlTowerRepository : Repository<ControlTower>, IControlTowerRepository
    {
        public ControlTowerRepository(AirportContext context) : base(context) { }

        public override IQueryable<ControlTower> GetAll() =>
            AirportContext.ControlTowers
                .Include(ct => ct.FlightsWaiting)
                .Include(ct => ct.FirstStations);
                //.ThenInclude(sctr => sctr.Station)
                //.ThenInclude(s => s.ChildrenStations);

        public Task<ControlTower> GetControlTowerByIdAsync(Guid id)
        {
            return GetAll().FirstOrDefaultAsync(ct => ct.Id == id);
        }

        public Task<ControlTower> GetControlTowerByNameAsync(string name)
        {
            return GetAll().FirstOrDefaultAsync(ct => ct.Name == name);
        }
    }
}
