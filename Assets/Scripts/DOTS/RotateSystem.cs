using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class RotateSystem : ComponentSystem
{
    protected override void OnCreate()
    {
        base.OnCreate();
        Entities.ForEach((Entity e, ref RotateYaw rYaw, ref Translation translation) =>
            {
                translation.Value = rYaw.StartLocation;
            }); 
    }
    
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity e, ref RotateYaw rYaw, ref Rotation rotation) =>
        {
            // quaternion rot;
            // rot.value = rotation.Value.value;
            // rot.value = rot.value * new float4(0, rot.value.y * rYaw.Speed * Time.DeltaTime, 0, 0);
            // rotation.Value.value = rot.value;
        });
    }
}

struct RotateStateUpdate : IJobForEachWithEntity<RotateYaw,Rotation>
{
    public void Execute(Entity entity, int index, ref RotateYaw rYaw, ref Rotation rotation)
    {
        quaternion rot;
        rot.value = rotation.Value.value;
        rot.value = rot.value * new float4(0, 1* rYaw.Speed, 0, 1);
        rotation.Value.value = rot.value;
    }
}

public class RotateSystemJob : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        RotateStateUpdate rotateSystemJob = new RotateStateUpdate();
        rotateSystemJob.Schedule(this,inputDeps).Complete();
        return inputDeps;
    }
}
