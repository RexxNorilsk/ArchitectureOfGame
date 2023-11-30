using Infrastructure.States;

namespace Infrastructure.StateMachines
{
	public interface IPayloadEnterStateMachine
	{
		public IState Enter<TState, TPayload>(TPayload payload)
			where TState : IEnterPayloadState<TPayload>;
	}
}