﻿namespace Travel.Entities
{
	using Airplanes.Contracts;
	using Contracts;

	/* 3/3
	 * I'll take a quiet life
	 * A handshake of carbon monoxide
	 * With no alarms and no surprises
	 */
	public class Trip : ITrip
	{
		private int id = 1;

		public Trip(string source, string destination, IAirplane airplane)
		{
			this.Source = source;
			this.Destination = destination;
			this.Airplane = airplane;

			this.Id = GenerateId(source, destination);
		}

		public string Id { get; }

		public string Source { get; }

		public string Destination { get; }

		public bool IsCompleted { get; private set; }

		public IAirplane Airplane { get; }

		public void Complete() => this.IsCompleted = true;

		private string GenerateId(string departure, string destination)
		{
			return $"{departure}{destination}{this.id++}";
		}
	}
}