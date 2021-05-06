using GarryBoats.Data;
using GarryBoats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarryBoats.Service
{
    public class RepairService
    {
        private readonly Guid _userId;
        public RepairService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRepair(RepairCreate model)
        {
            var entity = new Repair()
                {
                    RepairDescription = model.RepairDescription,
                    RepairDetails = model.RepairDetails,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                //ctx.Repairs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
