using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hotel.Models
{
    public class EFSupplyRepository: ISupplyRepository
    {
        private ApplicationDbContext context;
        public EFSupplyRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Supply> Supplys => context.Supplys;

        public void InsertSupply (Supply supply)
        {
            context.AttachRange();
            context.Supplys.Add(supply);
            context.SaveChanges();
        }

        public void DeleteSupply(Supply supply)
        {
            context.Supplys.Remove(supply);
            context.SaveChanges();
        }
        public void UpdateSupply(Supply supply)
        {
            context.Supplys.Update(supply);
            context.SaveChanges();
        }
    }
}
