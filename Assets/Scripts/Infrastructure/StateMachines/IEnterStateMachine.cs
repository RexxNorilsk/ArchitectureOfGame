using Infrastructure.States;

namespace Infrastructure.StateMachines
{
	public interface IEnterStateMachine
	{
		IState Enter<TState>() where TState : IEnterState;
	}
}