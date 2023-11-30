using System;

namespace Infrastructure.Service.LoadLevels
{
	public interface ILoadLevelService : IService
	{
		void Load(string name, Action onLoadLevel);
	}
}