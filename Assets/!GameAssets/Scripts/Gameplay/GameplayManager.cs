using UnityEngine;

namespace GameJamEntry.Gameplay {
	public class GameplayManager {
		FallingTetromino _tetromino;
		PlaygroundGrid   _grid = new(Vector2Int.zero);

		public Vector2Int CurrentGridSize => _grid.Size;

		public void Init(Vector2Int gridSize) {
			_grid = new PlaygroundGrid(gridSize);
		}

		public void MoveFallingTetromino(Vector2Int direction) {
			if ( _tetromino == null ) {
				return;
			}
			var newPosition = _tetromino.LeftTopCornerPosition + direction;
			if ( CanFitNewPositionInGrid(newPosition) ) {
				_tetromino.LeftTopCornerPosition = newPosition;
			}
		}

		public void Fall() {
			MoveFallingTetromino(Vector2Int.down);
			var nextFallPos = _tetromino.LeftTopCornerPosition + Vector2Int.down;
			if ( !CanFitNewPositionInGrid(nextFallPos) ) {
				//TODO: end fall and change tetromino
			}
		}

		bool CanFitNewPositionInGrid(Vector2Int newPosition) => (_tetromino != null) 
		                                                        && IsFitToOnGlobalGrid(_tetromino.CurrentForm, newPosition);

		bool CanFitNewFormInGrid() => (_tetromino != null) && IsFitToOnGlobalGrid(_tetromino.NextForm, _tetromino.LeftTopCornerPosition);

		bool IsFitToOnGlobalGrid(PlaygroundGrid form, Vector2Int topLeftPosition) {
			for ( var x = 0; x < form.Size.x; x++ ) {
				for ( var y = 0; y < form.Size.y; y++ ) {
					var localPosition  = new Vector2Int(x, y);
					var globalPosition = topLeftPosition + localPosition;
					if ( form.IsCellEmpty(localPosition) ) {
						// ignore empty cells in falling tetromino grid. Needed for easy cells offset from left top corner implementation.
						// Important for rotation
						continue;
					}
					if ( !_grid.IsCellEmpty(globalPosition) ) {
						return false;
					}
				}
			}
			return true;
		}
	}
}