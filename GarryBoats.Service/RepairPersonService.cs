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
                    RepairPersonId = _repairPersonId,
                    RepairPersonName = _repairPersonName,
                    RepairPersonLocation = _repairPersonLocation,
                    CreateUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.RepairPersons.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RepairPersonListItem> GetRepairPeople()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .RepairPeople
                        .Where(e => e.RepairPersonId == _repairPersonId)
                        .Select(
                            e => new RepairPersonListItem
                            {
                                RepairPersonId = e.RepairPersonId,
                                RepairPersonName = e.RepairPersonName,
                                CreatedUtc = e.CreatedUtc
                            }
                                );
                return query.ToArray();
            }
        }
    }
}
