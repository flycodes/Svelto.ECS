﻿using Svelto.ECS.Internal;

#if ENGINE_PROFILER_ENABLED && UNITY_EDITOR
using Svelto.ECS.Profiler;
#endif

namespace Svelto.ECS
{
    public partial class EnginesRoot
    {
        class GenericEntityFactory : IEntityFactory
        {
            readonly DataStructures.WeakReference<EnginesRoot> _weakEngine;

            public GenericEntityFactory(DataStructures.WeakReference<EnginesRoot> weakReference)
            {
                _weakEngine = weakReference;
            }

            public void BuildEntity<T>(int entityID, object[] implementors) where T : IEntityDescriptor, new()
            {
                _weakEngine.Target.BuildEntity<T>(new EGID(entityID), implementors);
            }

            public void BuildEntity(int entityID, EntityDescriptorInfo entityDescriptor, object[] implementors = null)
            {
                _weakEngine.Target.BuildEntity(new EGID(entityID), entityDescriptor, implementors);
            }

            public void BuildEntity<T>(int entityID, int groupID, object[] implementors)
                where T : IEntityDescriptor, new()
            {
                _weakEngine.Target.BuildEntity<T>(new EGID(entityID, groupID), implementors);
            }

            public void BuildEntity(int entityID, int groupID, EntityDescriptorInfo entityDescriptor,
                                           object[] implementors)
            {
                _weakEngine.Target.BuildEntity(new EGID(entityID, groupID), entityDescriptor, implementors);
            }

            public void PreallocateEntitySpace<T>(int size) where T : IEntityDescriptor, new()
            {
                _weakEngine.Target.Preallocate<T>(ExclusiveGroups.StandardEntity, size);
            }
            
            public void PreallocateEntitySpace<T>(int groupID, int size) where T : IEntityDescriptor, new()
            {
                _weakEngine.Target.Preallocate<T>(groupID, size);
            }
        }
    }
}