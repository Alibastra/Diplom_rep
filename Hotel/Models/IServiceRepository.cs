using System.Collections.Generic;

namespace Hotel.Models
{
    public interface IServiceRepository
    {
        IEnumerable<Service> Services { get; }
        void InsertService(Service service);
        void DeleteService(Service service);
        void UpdateService(Service service);
    }
}
