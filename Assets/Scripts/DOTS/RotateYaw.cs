using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
struct RotateYaw : IComponentData
{
    public float Speed;
    public float3 StartLocation;
}
