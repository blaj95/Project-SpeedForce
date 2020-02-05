using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class Rotator : MonoBehaviour, IConvertGameObjectToEntity
{
    public float speed;
    private Unity.Mathematics.Random rand;
    
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        rand = new Unity.Mathematics.Random((uint)UnityEngine.Random.Range(-20000, 20000));
        EntityArchetype rotateArchetype = dstManager.CreateArchetype(new ComponentType[] {
            typeof(RotateYaw)
        });
        dstManager.AddComponentData(entity, new RotateYaw()
        {
            Speed = speed,
            StartLocation = new float3(rand.NextFloat(),rand.NextFloat(),rand.NextFloat())
        });
    }
}

