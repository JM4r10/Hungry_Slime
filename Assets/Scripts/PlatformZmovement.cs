using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformZmovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float zUpperBoundary;    
    [SerializeField] float zLowerBoundary;

    private void Start()
    {
        
    }

    void LateUpdate()
    {
        var zPosition = NewZPosition();
        transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
    }
    //private float NewZPosition() => (zUpperBoundary - zLowerBoundary) * Mathf.Sin(Time.time * speed);
    private float NewZPosition() => (zUpperBoundary - zLowerBoundary) * (Mathf.Sin(Time.time * speed) / 2.0f + 0.5f) + zLowerBoundary;
}
