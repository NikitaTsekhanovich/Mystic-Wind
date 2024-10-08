using UnityEngine;

namespace MonoBehHandlers
{
    public class SpawnerGameObjects : MonoBehaviour
    {
        public static GameObject GetInstatinateObject(GameObject gameObject, Transform spawnPosition, Quaternion rotation)
        {
            var newGameObject = Instantiate(gameObject, spawnPosition.localPosition, rotation);

            return newGameObject;
        }
    }
}

