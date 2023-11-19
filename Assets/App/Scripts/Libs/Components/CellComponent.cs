using UnityEngine;

namespace App.Scripts.Libs.Components
{
    public class CellComponent : Component
    {
        public Vector2Int Position { get; private set; }

        public void Construct(Vector2Int position)
        {
            Position = position;
        }
    }
}