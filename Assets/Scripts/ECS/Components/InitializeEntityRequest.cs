using System;

namespace ECS.Components
{
    [Serializable]
    public struct InitializeEntityRequest
    {
        public EntityReference EntityReference;
    }
}