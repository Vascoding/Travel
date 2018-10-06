using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Airplanes
{
    public class LightAirplane : Airplane
    {
        private const int DefaultSeats = 5;
        private const int DefaultBaggageCompartments = 8;

        public LightAirplane() 
            : base (DefaultSeats, DefaultBaggageCompartments)
        {
        }
    }
}
