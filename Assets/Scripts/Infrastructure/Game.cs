using Infrastructure.Service;
using Infrastructure.Utility; 

namespace Infrastructure
{
	public class Game
	{
		public GameStateMachine StateMachine;

		public Game( ICoroutineRunner coroutineRunner, ControllerCollection controllerCollection)
		{
			StateMachine = new GameStateMachine(coroutineRunner, controllerCollection, new ServicesContainer());
			StateMachine.CurrentState.Exit();
		}
	}
}