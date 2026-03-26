using UnityEngine;
using System.Collections.Generic;

namespace VectorFlux
{
    public class SkateParkGenerator : MonoBehaviour
    {
        public GameObject rampPrefab;
        public GameObject railPrefab;
        public int obstacleCount = 20;
        public Vector2 areaSize = new Vector2(100, 100);

        [ContextMenu("Generate Park")]
        public void Generate()
        {
            Clear();
            for (int i = 0; i < obstacleCount; i++)
            {
                Vector3 pos = new Vector3(
                    Random.Range(-areaSize.x / 2, areaSize.x / 2),
                    0,
                    Random.Range(-areaSize.y / 2, areaSize.y / 2)
                );

                GameObject prefab = Random.value > 0.3f ? rampPrefab : railPrefab;
                if (prefab != null)
                {
                    GameObject obj = Instantiate(prefab, pos, Quaternion.Euler(0, Random.Range(0, 360), 0), transform);
                    obj.name = $"Obstacle_{i}";
                }
            }
        }

        public void Clear()
        {
            var children = new List<GameObject>();
            foreach (Transform child in transform) children.Add(child.gameObject);
            children.ForEach(child => DestroyImmediate(child));
        }
    }
}
