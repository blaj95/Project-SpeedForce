using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnRotatingCubes : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    public GameObject cubePrefab;
    
    private EntityManager manager;
    private Entity cubeEntity;
    
    // Start is called before the first frame update
    // void Update()
    // {
    //     Entity cube = manager.Instantiate(cubeEntityPrefab);
    //     
    //     float x = Random.Range(-10,10);
    //     float y = Random.Range(-10,10);
    //     float z = Random.Range(-10,10);
    //     
    //     manager.SetComponentData(cube,new Translation{Value = new float3(x,y,z)});
    //     manager.SetComponentData(cube, new Rotation{Value = quaternion.identity});
    // }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        cubeEntity = conversionSystem.GetPrimaryEntity(cubePrefab);
        dstManager.AddComponentData(entity, new EntityToSpawn()
        {
            Spawn = cubeEntity
        });
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(cubePrefab);
    }
}
