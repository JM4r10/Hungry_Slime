using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject[] objectsToSpawn = new GameObject[5];
    public Transform[] pointsToSpawm;
    
    void Start()
    {
        for(int i = 0; i < objectsToSpawn.Length; i++)
        {
            objectsToSpawn[i] = gameObject;
        }

        foreach (var item in objectsToSpawn)
        {
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(objectsToSpawn[0], pointsToSpawm[0].position, Quaternion.Euler(0, 180, 0));
        }
    }
}
