using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private float fallingSpeed = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-1, 5), 7f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * fallingSpeed * Vector3.down);
        
        if (transform.position.y < -5)
        {
            transform.position = new Vector3(Random.Range(-1, 5), 7f, 0f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
