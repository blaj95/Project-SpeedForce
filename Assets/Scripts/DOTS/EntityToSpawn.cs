using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct EntityToSpawn : IComponentData
{
    public Entity Spawn;
}
