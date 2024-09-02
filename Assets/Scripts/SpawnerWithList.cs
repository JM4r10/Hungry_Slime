using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWithList : MonoBehaviour
{
    GameObject[] objectsToSpawn = new GameObject[5];
    
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] List<GameObject> pooledItems= new List<GameObject>();
    
    void Start()
    {
        
    }

    [ContextMenu("Start Pool")]

    private void InstancePool(int amount) { 
    

    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
