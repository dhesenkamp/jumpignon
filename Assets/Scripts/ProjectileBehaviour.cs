using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 5f;
    
    // Update is called once per frame
    void Update()
    {
          transform.Translate(projectileSpeed * Time.deltaTime * Vector3.up);

          if (transform.position.y > 10)
          {
              Destroy(this.gameObject);
          }
    }
}
