using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Ecs
{
    public static class WorldExt
    {
        public static void SendMessage<T>(this EcsWorld world, in T message) 
            where T : struct
        {
            world.NewEntity().Get<T>() = message;
        }
    }
}

