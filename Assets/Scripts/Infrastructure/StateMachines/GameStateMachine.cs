using Infrastructure.Service;
using Infrastructure.Service.LoadLevels;
using Infrastructure.StateMachines;
using Infrastructure.States;
using Infrastructure.Utility;
using System;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

namespace Infrastructure
{
	public class GameStateMachine : IPayloadEnterStateMachine, IEnterStateMachine
	{
		private readonly Dictionary<Type, IState> _gameStates;

		private string consentIdentifier;
		private bool isOptInConsentRequired;

		private IState _currentState;

		public IState CurrentState
			=> _currentState;

		public GameStateMachine(ICoroutineRunner coroutineRunner, ControllerCollection controllerCollection, ServicesContainer servicesContainer)
		{

			_gameStates = new Dictionary<Type, IState>
			{
				{
					typeof(LoadSceneEnterPayloadState),
					new LoadSceneEnterPayloadState(coroutineRunner, this, servicesContainer)
				},
				//{
				//	typeof(MenuBootstrapState),
				//	new MenuBootstrapState(this)
				//},
				//{
				//	typeof(LevelBootstrapState),
				//	new LevelBootstrapState(this)
    //            }
			};
			//((MenuBootstrapState)_gameStates[typeof(MenuBootstrapState)]).NeedSet(controllerCollection);
			//((LevelBootstrapState)_gameStates[typeof(LevelBootstrapState)]).NeedSet(controllerCollection);
			

			//Enter<LoadSceneEnterPayloadState, SceneLoadInformation>
			//	(new SceneLoadInformation("Menu", () => Enter<MenuBootstrapState, MenuOptions>(null)));
		}


		public IState Enter<TState>()
			where TState : IEnterState
		{
			var enterState = (IEnterState)_gameStates[typeof(TState)];
			if (enterState == null)
			{
				Debug.LogError("Incorrect settings");
				return null;
			}
			enterState.Enter();
			_currentState = enterState;
			return enterState;
		}

		public IState Enter<TState, TPayload>(TPayload payload)
			where TState : IEnterPayloadState<TPayload>
		{
			var payloadState = (TState)_gameStates[typeof(TState)];
			if (payloadState == null)
			{
				Debug.LogError("Incorrect settings");
				return null;
			}
			payloadState.Enter(payload);
			_currentState = payloadState;
			return payloadState;
		}
	}
}