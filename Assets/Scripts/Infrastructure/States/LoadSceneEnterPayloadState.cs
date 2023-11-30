using System;
using System.ComponentModel.Design;
using Infrastructure.Service;
using Infrastructure.Service.LoadLevels;
using Infrastructure.StateMachines;
using Infrastructure.Utility;


namespace Infrastructure.States
{
	public class LoadSceneEnterPayloadState : IEnterPayloadState<SceneLoadInformation>
	{
		private readonly UnitySceneLoadLevelService _loadLevelService;
		private readonly IEnterStateMachine _enterStateMachine;

		public LoadSceneEnterPayloadState(
			ICoroutineRunner coroutineRunner,
			IEnterStateMachine enterStateMachine,
			ServicesContainer servicesContainer)
		{
			_loadLevelService = new UnitySceneLoadLevelService(coroutineRunner);
			servicesContainer.Add<ILoadLevelService>(_loadLevelService);
			_enterStateMachine = enterStateMachine;
		}

		public void Enter(SceneLoadInformation payloadData)
		{
			_loadLevelService.Load(payloadData.SceneName, payloadData.OnLoadScene);
		}

		public void Exit()
		{
		}
	}
}