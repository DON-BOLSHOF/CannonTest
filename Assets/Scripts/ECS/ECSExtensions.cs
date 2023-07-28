using Leopotam.Ecs;

namespace ECS
{
    public static class ECSExtensions
    {
        public static void SendMessage<T>(this EcsWorld world, in T message) where T : struct
        {
            world.NewEntity().Get<T>() = message;
        }
    }
}