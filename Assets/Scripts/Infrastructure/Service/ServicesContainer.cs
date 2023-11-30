using System;
using System.Collections.Generic;

namespace Infrastructure.Service
{
	public class ServicesContainer
	{
		private readonly Dictionary<Type, IService> _services;

		public ServicesContainer()
		{
			_services = new Dictionary<Type, IService>();
		}

		public bool Has<T>() where T : IService
		{
			return _services.ContainsKey(typeof(T));
		}

		public void Add<T>(T service) where T : IService
		{
			_services.Add(typeof(T), service);
		}

		public T Get<T>()
			where T : IService
		{
			return (T)_services[typeof(T)];
		}
	}
}