namespace Travel.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	
	public class Airport : IAirport
	{
		private List<IBag> checkedInBags = new List<IBag>();
        private List<IBag> confiscatedBags = new List<IBag>();
		private List<ITrip> adventures = new List<ITrip>();
		private List<IPassenger> people = new List<IPassenger>();

        public IReadOnlyCollection<IBag> CheckedInBags => this.checkedInBags;

        public IReadOnlyCollection<IBag> ConfiscatedBags => this.confiscatedBags;

        public IReadOnlyCollection<IPassenger> Passengers => this.people;

        public IReadOnlyCollection<ITrip> Trips => this.adventures;

        public IPassenger GetPassenger(string username) => this.people.FirstOrDefault(p => p.Username == username);

		public ITrip GetTrip(string id) => this.adventures.FirstOrDefault(a => a.Id == id);

		public void AddPassenger(IPassenger passenger) => this.people.Add(passenger);

		public void AddTrip(ITrip trip) => this.adventures.Add(trip);

		public void AddCheckedBag(IBag bag) => this.checkedInBags.Add(bag);

		public void AddConfiscatedBag(IBag bag) => this.confiscatedBags.Add(bag);
	}
}