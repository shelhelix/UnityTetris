using UnityEngine;

namespace GameJamEntry.Gameplay {
    public enum PullDirection {
        None,
        Left,
        Right,
    }
    
    public enum CellType {
        None,
        Simple,
        Pull,
        Bomb,
        ControlReverser,
    }
    
    public struct CellContainer {
        public CellType Type;
        public Color Color;
        public PullDirection PullDirection;
    }
    
    public class PlaygroundGrid {
        CellContainer[,] _grid;
        
        public PlaygroundGrid(Vector2Int size) {
            _grid = new CellContainer[size.x, size.y];
        }

        public Vector2Int Size => new(_grid.GetLength(0), _grid.GetLength(1));

        public bool IsCellEmpty(Vector2Int position) => IsCellExists(position) && (_grid[position.x, position.y].Type == CellType.None);
        
        public bool IsCellExists(Vector2Int position) => (position.x >= 0) 
                                                         && (position.x < _grid.GetLength(0)) 
                                                         && (position.y >= 0) 
                                                         && (position.y < _grid.GetLength(1));

        public void SetCell(Vector2Int position, CellContainer cellContainer) {
            if ( !IsCellExists(position) ) {
                Debug.LogError("Can't set cell at position " + position + " because it's out of grid bounds");
                return;
            }
            _grid[position.x, position.y] = cellContainer;
        }
        
        public CellContainer GetCell(Vector2Int position) {
            if ( IsCellExists(position) ) {
                return _grid[position.x, position.y];
            }
            Debug.LogError("Can't get cell at position " + position + " because it's out of grid bounds");
            return default;
        }
    }
}