using System;
using System.Collections;
using Infrastructure.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Service.LoadLevels
{
	public class UnitySceneLoadLevelService : ILoadLevelService
	{
		private readonly ICoroutineRunner _coroutineRunner;

		public UnitySceneLoadLevelService(ICoroutineRunner coroutineRunner)
		{
			_coroutineRunner = coroutineRunner;
		}
		
		public void Load(string name, Action onLoadLevel)
			=> _coroutineRunner.StartCoroutine(LoadScene(name, onLoadLevel));

		private IEnumerator LoadScene(string name, Action onLoadLevel)
		{
			//SteamVR_Fade.Start(Color.black, 1);
			if (SceneManager.GetActiveScene().name == name)
			{
				onLoadLevel?.Invoke();
				yield break;
			}
			
			var waitLoadScene = SceneManager.LoadSceneAsync(name);
			while (!waitLoadScene.isDone)
				yield return null;

			//SteamVR_Fade.View(Color.clear, 1);
			onLoadLevel?.Invoke();
		}
	}
}