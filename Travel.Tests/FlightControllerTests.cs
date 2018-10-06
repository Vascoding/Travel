// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
	using NUnit.Framework;
    using System.Collections.Generic;
    using Travel.Core.Controllers;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Items;

    [TestFixture]
    public class FlightControllerTests
    {
        [Test]
        public void Test1()
        {
        }

        [Test]
	    public void Test2()
	    {
            var airport = new Airport();
            var airplane = new LightAirplane();
            var trip = new Trip("Peshtera", "Sofia", airplane);
            trip.Complete();
            airport.AddTrip(trip);
            var flightController = new FlightController(airport);

            var output = flightController.TakeOff();

            Assert.AreEqual("Confiscated bags: 0 (0 items) => $0", output);
	    }

        [Test]
        public void Test3()
        {
            var airport = new Airport();
            var airplane = new LightAirplane();
            var trip = new Trip("Peshtera", "Sofia", airplane);
            
            airport.AddTrip(trip);
            var flightController = new FlightController(airport);

            var output = flightController.TakeOff();

            Assert.AreEqual("PeshteraSofia1:\r\nSuccessfully transported 0 passengers from Peshtera to Sofia.\r\nConfiscated bags: 0 (0 items) => $0", output);
        }

        [Test]
        public void Test4()
        {
            var passenger1 = new Passenger("Pesho");
            var passenger2 = new Passenger("Gosho");
            var passenger3 = new Passenger("CHefo");
            var passenger4 = new Passenger("Aleksandar");
            var passenger5 = new Passenger("Vankata");
            var passenger6 = new Passenger("Niki");
            var airport = new Airport();
            var airplane = new LightAirplane();
            airplane.AddPassenger(passenger1);
            airplane.AddPassenger(passenger2);
            airplane.AddPassenger(passenger3);
            airplane.AddPassenger(passenger4);
            airplane.AddPassenger(passenger5);
            airplane.AddPassenger(passenger6);
            var trip = new Trip("Peshtera", "Sofia", airplane);
           
            airport.AddTrip(trip);
            var flightController = new FlightController(airport);

            var output = flightController.TakeOff();

            Assert.AreEqual("PeshteraSofia1:\r\nOverbooked! Ejected Gosho\r\nConfiscated 0 bags ($0)\r\nSuccessfully transported 5 passengers from Peshtera to Sofia.\r\nConfiscated bags: 0 (0 items) => $0", output);
        }

        [Test]
        public void Test5()
        {
            var passenger1 = new Passenger("Pesho");
            var passenger2 = new Passenger("Gosho");
            var passenger3 = new Passenger("CHefo");
            var passenger4 = new Passenger("Aleksandar");
            var passenger5 = new Passenger("Vankata");
            var passenger6 = new Passenger("Niki");
            var airport = new Airport();
            var airplane = new LightAirplane();
            airplane.AddPassenger(passenger1);
            airplane.AddPassenger(passenger2);
            airplane.AddPassenger(passenger3);
            airplane.AddPassenger(passenger4);
            airplane.AddPassenger(passenger5);
            airplane.AddPassenger(passenger6);
            var trip = new Trip("Peshtera", "Sofia", airplane);

            airport.AddTrip(trip);
            var flightController = new FlightController(airport);

            flightController.TakeOff();

            Assert.AreEqual(trip.IsCompleted, true);
        }

        [Test]
        public void Test6()
        {
            var passenger1 = new Passenger("Pesho");
            var passenger2 = new Passenger("Gosho");
            var passenger3 = new Passenger("CHefo");
            var passenger4 = new Passenger("Aleksandar");
            var passenger5 = new Passenger("Vankata");
            var passenger6 = new Passenger("Niki");
            var airport = new Airport();
            var airplane = new LightAirplane();
            airplane.AddPassenger(passenger1);
            airplane.AddPassenger(passenger2);
            airplane.AddPassenger(passenger3);
            airplane.AddPassenger(passenger4);
            airplane.AddPassenger(passenger5);
            airplane.AddPassenger(passenger6);
            var trip = new Trip("Peshtera", "Sofia", airplane);

            airport.AddTrip(trip);
            var flightController = new FlightController(airport);

            flightController.TakeOff();

            Assert.AreEqual(airplane.IsOverbooked, false);
        }

        [Test]
        public void Test7()
        {
            var passenger1 = new Passenger("Pesho");
            var passenger2 = new Passenger("Gosho");
            var passenger3 = new Passenger("CHefo");
            var passenger4 = new Passenger("Aleksandar");
            var passenger5 = new Passenger("Vankata");
            var airport = new Airport();
            var airplane = new LightAirplane();
            airplane.AddPassenger(passenger1);
            airplane.AddPassenger(passenger2);
            airplane.AddPassenger(passenger3);
            airplane.AddPassenger(passenger4);
            airplane.AddPassenger(passenger5);
            var item = new Jewelery();
            var items = new List<Item>();
            items.Add(item);
            var bag = new Bag(passenger1, items);
            passenger1.Bags.Add(bag);
            var trip = new Trip("Peshtera", "Sofia", airplane);

            airport.AddTrip(trip);
            var flightController = new FlightController(airport);

            flightController.TakeOff();

            Assert.AreEqual(airplane.BaggageCompartment.Count, 1);
        }

        [Test]
        public void Test8()
        {
            var passenger1 = new Passenger("Pesho");
            var passenger2 = new Passenger("Gosho");
            var passenger3 = new Passenger("CHefo");
            var passenger4 = new Passenger("Aleksandar");
            var passenger5 = new Passenger("Vankata");
            var passenger6 = new Passenger("Niki");
            var airport = new Airport();
            var airplane = new LightAirplane();
            airplane.AddPassenger(passenger1);
            airplane.AddPassenger(passenger2);
            airplane.AddPassenger(passenger3);
            airplane.AddPassenger(passenger4);
            airplane.AddPassenger(passenger5);
            airplane.AddPassenger(passenger6);
            var item = new Jewelery();
            var items = new List<Item>();
            items.Add(item);
            var bag = new Bag(passenger1, items);
            passenger1.Bags.Add(bag);
            airport.AddConfiscatedBag(bag);
            var trip = new Trip("Peshtera", "Sofia", airplane);

            airport.AddTrip(trip);
            var flightController = new FlightController(airport);

            flightController.TakeOff();

            Assert.AreEqual(airport.ConfiscatedBags.Count, 1);
        }
    }
}
