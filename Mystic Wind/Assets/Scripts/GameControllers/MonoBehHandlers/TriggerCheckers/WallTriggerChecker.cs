using GameControllers.Components;
using GameControllers.Ecs;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.MonoBehHandlers.TriggerCheckers
{
    public class WallTriggerChecker : MonoBehaviour
    {
        [SerializeField] private string _targetTag = "Enemy";

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(_targetTag))
            {
                other.gameObject.GetComponent<EntityReference>()
                    .Entity
                    .Get<DestroyableComponent>();
            }
        }
    }
}
