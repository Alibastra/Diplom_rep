using System.Collections.Generic;

namespace Hotel.Models
{
    public interface ISupplyRepository
    {
        IEnumerable<Supply> Supplys { get; }
        void InsertSupply(Supply supply);
        void DeleteSupply(Supply supply);
        void UpdateSupply(Supply supply);
    }
}
