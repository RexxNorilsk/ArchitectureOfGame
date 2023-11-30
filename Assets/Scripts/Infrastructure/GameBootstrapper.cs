using Infrastructure.Utility; 
using UnityEngine;

namespace Infrastructure
{
	public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
	{
		public void Awake()
		{
			var game = new Game(this, new ControllerCollection());			
			DontDestroyOnLoad(this);
		}
	}
}
