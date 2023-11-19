﻿using Com.Shelinc.SceneTransitionEffects.Transitions;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Com.Shelinc.SceneTransitionEffects {
	public class SceneLoader {
		public const string MainMenuSceneName = "MainMenu";
		public const string GameplaySceneName = "Gameplay";
		
		readonly ISceneTransition _transition;

		public SceneLoader(ISceneTransition transition) => _transition = transition;

		public async UniTask LoadScene(string sceneName) {
			await _transition.HideScenes();
			await SceneManager.LoadSceneAsync(sceneName);
			await _transition.ShowScenes();
		}
	}
}