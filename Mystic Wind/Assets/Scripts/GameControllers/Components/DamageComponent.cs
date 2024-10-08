using UnityEngine;
using System;

namespace GameControllers.Components
{
    [Serializable]
    public struct DamageComponent
    {
        [HideInInspector] public bool CanDealDamage;
    }
}

