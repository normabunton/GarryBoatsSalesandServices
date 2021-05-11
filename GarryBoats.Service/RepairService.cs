using GarryBoats.Data;
using GarryBoats.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public IEnumerable<RepairListItem> GetRepairs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Repairs
                        .Where(e => e.UserId == _userId)
                        .Select(
                                e =>
                                    new RepairListItem
                                    {
                                        RepairId = e.RepairId,
                                        RepairDetails = e.RepairDetails,
                                        CreatedUtc = e.CreatedUtc
                                    }
                          );
                return query.ToArray();
            }
        }
        public RepairDetail GetRepairById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Repairs
                        .Single(e => e.RepairId == id);
                return
                    new RepairDetail
                    {
                        RepairID = entity.RepairId,
                        RepairName = entity.RepairDescription,
                        RepairLocation = entity.RepairDetails
                    };
            };
        }

        public bool UpdateRepair(RepairEdit Model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Repairs
                    .Single(e => e.UserId == _userId);
                entity.RepairDescription = Model.RepairDescription;
                entity.RepairDetails = Model.RepairDetails;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

        
    

