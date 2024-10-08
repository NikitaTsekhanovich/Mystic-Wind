using UnityEngine;

namespace GameControllers.Components
{
    public struct ScoreComponent
    {
        [HideInInspector] public const float MaxScore = 30f;
        [HideInInspector] public float CurrentScore;
    }
}

