using System;
using System.Collections.Generic;
using System.Text;
using Travel.Entities.Contracts;

namespace Travel.Entities.Factories.Contracts
{
    interface IPassengerFactory
    {
        IPassenger CreatePassenger(string type);
    }
}
