using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hotel.Models
{
    public class EFServiceRepository: IServiceRepository
    {
        private ApplicationDbContext context;
        public EFServiceRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Service> Services => context.Services;

        public void InsertService (Service service)
        {
            context.AttachRange();
            context.Services.Add(service);
            context.SaveChanges();
        }

        public void DeleteService(Service service)
        {
            context.Services.Remove(service);
            context.SaveChanges();
        }
        public void UpdateService(Service service)
        {
            context.Services.Update(service);
            context.SaveChanges();
        }
    }
}
