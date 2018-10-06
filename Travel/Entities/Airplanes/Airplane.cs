using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travel.Entities.Airplanes.Contracts;
using Travel.Entities.Contracts;

namespace Travel.Entities.Airplanes
{
    public abstract class Airplane : IAirplane
    {
        private List<IBag> baggageCompartment = new List<IBag>();

        private List<IPassenger> passengers = new List<IPassenger>();

        private int seats;

        private int baggageCompartments;

        protected Airplane(int seats, int baggageCompartments)
        {
            this.seats = seats;
            this.baggageCompartments = baggageCompartments;
        }

        public int BaggageCompartments => this.baggageCompartments;

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment;

        public bool IsOverbooked => this.Passengers.Count > this.Seats;

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers;

        public int Seats => this.seats;

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var bags = this.baggageCompartment.Where(a => a.Owner == passenger).ToList();
            this.baggageCompartment.RemoveAll(a => a.Owner == passenger);
            return bags;
        }

        public void LoadBag(IBag bag)
        {
            if (this.baggageCompartment.Count > this.BaggageCompartments)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");
            }
            this.baggageCompartment.Add(bag);
        }

        public IPassenger RemovePassenger(int seat)
        {
            var passenger = this.passengers[seat];
            this.passengers.Remove(passenger);
            return passenger;
        }
    }
}
