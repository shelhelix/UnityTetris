using System.Collections.Generic;
using Com.Shelinc.FullscreenCanvasController;
using GameComponentAttributes.Attributes;
using GameJamEntry.Gameplay.UI;
using GameJamEntry.Global;
using UnityEngine;
using VContainer;

namespace GameJamEntry.Gameplay {
	public class GameplayStarter : MonoBehaviour {
		[NotNullReference] [SerializeField] List<AudioClip> Bgms;

		[Inject]
		public void Init(ScreenManager screenManager, BgmManager bgmManager) {
			screenManager.Init();
			screenManager.ShowScreen<GameplayScreen>().Forget();
			bgmManager.PlayBgms(Bgms);
		}
	}
}