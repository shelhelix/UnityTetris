using System.Collections.Generic;
using GameJamEntry._GameAssets.Scripts.Utils;
using UnityEngine;

namespace GameJamEntry.Gameplay {
	public class FallingTetromino {
		List<PlaygroundGrid> _forms = new();
		int                  _currentFormIndex;

		public Vector2Int     LeftTopCornerPosition { get; set; }
		public PlaygroundGrid CurrentForm           => _forms.GetOrDefault(_currentFormIndex);
		public PlaygroundGrid NextForm              => _forms.GetOrDefault(NextIndex);

		int NextIndex => (_currentFormIndex + 1) % _forms.Count;
		
		public void AddForm(PlaygroundGrid form) {
			_forms.Add(form);
		}

		public void Rotate() {
			_currentFormIndex = NextIndex;
		}
	}
}