using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformYmovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float yUpperBoundary;
    [SerializeField] float yLowerBoundary;
    private float initialPos;

    private void Start()
    {
        //initialPos = transform.position.y;
    }
    void LateUpdate()
    {
        var yPosition = NewYPosition();
        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
    }
    private float NewYPosition() => ((yUpperBoundary - yLowerBoundary) * Mathf.Sin(Time.time * speed));    

}
