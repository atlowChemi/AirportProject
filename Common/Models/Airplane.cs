using Common.Enums;
using Common.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Models
{
    class Airplane : IAirplane
    {
        public int Id { get; set; }
        public AirplaneDirection Direction { get; set; }
        [NotMapped]
        private readonly Random random;
        public event EventHandler ReadyToContinue;

        public Airplane()
        {
            random = new Random(DateTime.UtcNow.Millisecond);
        }

        public async void StartWaitingInStation()
        {
            await Task.Delay(random.Next(1000 * 5, 1000 * 60));
            ReadyToContinue?.Invoke(this, null);
        }
    }
}
