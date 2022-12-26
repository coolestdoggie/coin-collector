using UnityEngine;

namespace CoinCollector.Utils
{
    public static class Utils
    {
        public static Vector2 GetXWorldBounds()
        {
            Vector2 worldBoundary = Camera.main.ScreenToWorldPoint( new Vector2( Screen.width, Screen.height ));
            
            return new Vector2(-worldBoundary.x, worldBoundary.x);
        }
        
        public static Vector2 GetYWorldBounds()
        {
            Vector2 worldBoundary = Camera.main.ScreenToWorldPoint( new Vector2( Screen.width, Screen.height ));

            return new Vector2(-worldBoundary.y, worldBoundary.y);
        }
   }
}