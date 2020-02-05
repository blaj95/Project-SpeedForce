using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpawnSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity e, ref EntityToSpawn spawnInfo) =>
        {
            EntityManager.Instantiate(spawnInfo.Spawn);
            
        });
    }
}
