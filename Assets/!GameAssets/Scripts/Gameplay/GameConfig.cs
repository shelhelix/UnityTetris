using UnityEngine;

namespace GameJamEntry.Gameplay {
	[CreateAssetMenu(fileName = "GameConfig", menuName = "GameJamEntry/GameConfig")]
	public class GameConfig : ScriptableObject {
		public int BombExplosionSquareSideSize;
		public int ChanceForCustomCellInTetrominoPercent;
	}
}