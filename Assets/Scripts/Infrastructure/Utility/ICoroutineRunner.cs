using System.Collections;
using UnityEngine;

namespace Infrastructure.Utility
{
	public interface ICoroutineRunner
	{
		Coroutine StartCoroutine(IEnumerator loadScene);
	}
}