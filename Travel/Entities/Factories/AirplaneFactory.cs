namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using System;
    using System.Reflection;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            return (IAirplane)Activator.CreateInstance(Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type));
        }
	}
}