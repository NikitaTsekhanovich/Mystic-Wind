using System;
using UnityEngine;

namespace GameControllers.Components
{
    [Serializable]
    public struct RotetableComponent
    {
        [HideInInspector] public Transform Transform;

        public RotetableComponent(Transform transform)
        {
            Transform = transform;
        }
    }
}

