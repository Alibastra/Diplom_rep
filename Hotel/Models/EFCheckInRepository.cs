using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hotel.Models
{
    public class EFCheckInRepository: ICheckInRepository
    {
        private ApplicationDbContext context;
        public EFCheckInRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<CheckIn> CheckIns => context.CheckIns;

        public void InsertCheckIn (CheckIn checkIn)
        {
            context.AttachRange();
            context.CheckIns.Add(checkIn);
            context.SaveChanges();
        }

        public void DeleteCheckIn(CheckIn checkIn)
        {
            context.CheckIns.Remove(checkIn);
            context.SaveChanges();
        }
        public void UpdateCheckIn(CheckIn checkIn)
        {
            context.CheckIns.Update(checkIn);
            context.SaveChanges();
        }
    }
}
