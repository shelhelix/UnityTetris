using Com.Shelinc.FullscreenCanvasController;
using Com.Shelinc.SceneTransitionEffects;
using Com.Shelinc.SceneTransitionEffects.Transitions;
using Com.Shelinc.SceneTransitionEffects.Transitions.Implementations;
using GameComponentAttributes.Attributes;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameJamEntry.Gameplay {
	public class GameplayScope : LifetimeScope {
		[NotNullReference] [SerializeField] ScreenManager ScreenManager;
		[NotNullReference] [SerializeField] GameConfig    Config;
		
		protected override void Configure(IContainerBuilder builder) {
			base.Configure(builder);
			builder.RegisterInstance(Config);
			builder.RegisterInstance(ScreenManager);
			builder.RegisterInstance<ISceneTransition>(FadeSceneTransition.Instance);
			builder.Register<SceneLoader>(Lifetime.Scoped);
			builder.RegisterEntryPoint<GameplayStarter>();
		}
	}
}