using System.Collections.Generic;

namespace Hotel.Models
{
    public interface ICheckInRepository
    {
        IEnumerable<CheckIn> CheckIns { get; }
        void InsertCheckIn(CheckIn checkIn);
        void DeleteCheckIn(CheckIn checkIn);
        void UpdateCheckIn(CheckIn checkIn);
    }
}
