using GameControllers.Components;
using GameControllers.DataGames;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.MonoBehHandlers.TriggerCheckers
{
    public class CollisionWithPlayerChecker : MonoBehaviour
    {
        [SerializeField] private string _playerTag = "Player";
        [SerializeField] private string _gameFieldTag = "GameField";
        [SerializeField] private InitializeEntityRequest _entityReference;
        [SerializeField] private TypeGameObject _typeGameObject;
        [SerializeField] private CircleCollider2D _circleCollider;
        private bool _onGameField;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(_playerTag))
            {
                if (_typeGameObject == TypeGameObject.Bubble && _onGameField)
                    _entityReference.EntityReference.Entity.Get<RotetableComponent>().Transform = collision.gameObject.GetComponent<Transform>();
                else if (_typeGameObject == TypeGameObject.Enemy)
                    _entityReference.EntityReference.Entity.Get<DamageComponent>().CanDealDamage = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_typeGameObject == TypeGameObject.Bubble && col.CompareTag(_gameFieldTag))
            {
                _circleCollider.excludeLayers = 0;
                _onGameField = true;
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (_typeGameObject == TypeGameObject.Bubble && col.CompareTag(_gameFieldTag))
            {
                _circleCollider.includeLayers = 0;
                _onGameField = false;
            }
        }
    }
}

