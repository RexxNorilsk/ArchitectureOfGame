namespace Infrastructure.States
{
	public interface IState
	{
		void Exit();
	}

	public interface IEnterState : IState
	{
		void Enter();
	}

	public interface IEnterPayloadState<T> : IState
	{
		void Enter(T payloadData);
	}

}