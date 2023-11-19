using Com.Shelinc.FullscreenCanvasController;
using Com.Shelinc.SceneTransitionEffects;
using Cysharp.Threading.Tasks;
using GameJamEntry.Gameplay.UI;
using UnityEngine;
using VContainer;

namespace GameJamEntry.Gameplay {
	public class GameplayCheats : MonoBehaviour {
		ScreenManager _screenManager;
		SceneLoader   _sceneLoader;

		bool _isOpened;
		
		[Inject]
		public void Init(ScreenManager screenManager, SceneLoader sceneLoader) {
			_screenManager = screenManager;
			_sceneLoader   = sceneLoader;
		}
		
		void OnGUI() {
			var style = new GUIStyle(GUI.skin.button) {
				fontSize = 60,	
			};
			if ( !_isOpened ) {
				if ( GUILayout.Button("show cheats", style) ) {
					_isOpened = true;
				}
			} else {
				if ( GUILayout.Button("close cheats", style) ) {
					_isOpened = false;
				}
				if ( GUILayout.Button("show win screen", style) ) {
					_screenManager.ShowScreen<EndGameScreen>(x => x.Init(true)).Forget();
				}
				if ( GUILayout.Button("show lose screen", style) ) {
					_screenManager.ShowScreen<EndGameScreen>(x => x.Init(false)).Forget();
				}
				if ( GUILayout.Button("return to main scene", style) ) {
					_sceneLoader.LoadScene(SceneLoader.MainMenuSceneName).Forget();
				}
			}
		}
	}
}