using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        transform.Rotate(speed * Time.deltaTime * Vector3.up, Space.World);
        
    }

}
