using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    public Vector3 offset = new (0, 1, -10);
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = offset;
    }

    // LateUpdate is called once *at the end* of the  frame
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPosition = target.transform.position + offset;
            transform.position = newPosition;    
        }
        
    }
}
