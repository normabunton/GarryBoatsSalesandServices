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
        public IEnumerable<RepairPersonList> GetRepairPerson()
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
    }
}
