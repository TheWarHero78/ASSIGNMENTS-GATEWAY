
using AarshModi_CLPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLPM.DAL.Repository.Interface
{
 public   interface IPassengerRepository
    {
        Passenger registerPassenger(Passenger model);
        Passenger updatePassengerDetails(Passenger model);
        Boolean deletePassengerDetails(String exID);
        IList<Passenger> getAllPassenger();
        Passenger getPassengerByexID(String exID);

    }
}
