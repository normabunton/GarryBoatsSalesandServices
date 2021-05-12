using GarryBoats.Data;
using GarryBoats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarryBoats.Service
{
    public class RepairPersonService
    {
        private readonly Guid _userId;
        public RepairPersonService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateRepairPerson(RepairPersonCreate model)
        {
            var entity =
                new RepairPerson()
                {                  
                    
                    RepairPersonName = model.RepairPersonName,
                    RepairPersonLocation = model.RepairPersonLocation,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.RepairPersons.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RepairPersonList> GetRepairPersons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .RepairPersons
                       
                        .Select(
                            e => new RepairPersonList
                            {
                                RepairPersonId = e.RepairPersonId,
                                RepairPersonName = e.RepairPersonName,
                                RepairPersonLocation = e.RepairPersonLocation,
                                CreatedUtc = e.CreatedUtc
                            }
                                );
                return query.ToArray();
            }
        }
        public RepairPersonDetail GetRepairPersonById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RepairPersons
                        .Single(e => e.RepairPersonId == id);
                return
                    new RepairPersonDetail
                    {
                        RepairPersonID = entity.RepairPersonId,
                        RepairPersonName = entity.RepairPersonName,
                        RepairPersonLocation = entity.RepairPersonLocation
                    };
            };
        }
        public bool UpdateRepairPerson(RepairPersonEdit Model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .RepairPersons
                    .Single(e => e.RepairPersonId == Model.RepairPersonId);

                entity.RepairPersonName = Model.RepairPersonName;
                entity.RepairPersonLocation = Model.RepairPersonLocation;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRepairPerson(int repairPersonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RepairPersons
                        .Single(e => e.RepairPersonId == repairPersonId);

                ctx.RepairPersons.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
