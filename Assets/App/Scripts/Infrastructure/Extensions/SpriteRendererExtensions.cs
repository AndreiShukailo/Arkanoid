using UnityEngine;

namespace App.Scripts.Infrastructure.Extensions
{
    public static class SpriteRendererExtensions
    {
        public static Rect GetRect(this SpriteRenderer spriteRenderer)
        {
            var bounds = spriteRenderer.bounds;
            return new Rect(bounds.min.x, bounds.min.y,
                bounds.size.x, bounds.size.y);
        }
    }
}