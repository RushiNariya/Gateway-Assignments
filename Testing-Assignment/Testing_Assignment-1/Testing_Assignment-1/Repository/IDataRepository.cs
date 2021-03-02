using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing_Assignment_1.Models;

namespace Testing_Assignment_1.Repository
{
    public interface IDataRepository
    {
        Passenger AddPassenger(Passenger passenger);
        bool Delete(Guid Id);
        Passenger GetById(Guid id);
        IList<Passenger> getPassengersList();
        Passenger Update(Passenger passenger);
    }
}
