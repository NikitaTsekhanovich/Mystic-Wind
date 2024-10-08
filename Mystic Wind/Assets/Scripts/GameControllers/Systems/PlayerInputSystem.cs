using GameControllers.Components;
using GameControllers.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, DirectionComponent> _directionFilter = null;

        private bool _isClick;

        public void Run()
        {
            InputClick(); 

            foreach (var i in _directionFilter)
            {
                ref var directionComponent = ref _directionFilter.Get2(i);
                ref var isClick = ref directionComponent.IsClick;

                isClick = _isClick;
            }
        }

        private void InputClick()
        {
            if (Input.GetMouseButton(0))
                _isClick = true;
            else 
                _isClick = false;
        }
    }
}

