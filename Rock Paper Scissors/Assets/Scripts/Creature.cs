using System;
using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEngine;
using Random = UnityEngine.Random;

public class Creature : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float speed;
    private Vector3 direction;
    void Start()
    {
        Setup();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleTrigger();
    }

    protected virtual void HandleTrigger()
    {
        Destroy(gameObject);
        // Debug.Log(gameObject.name);
    }

    private void Setup()
    {
        rb = GetComponent<Rigidbody>();
        speed = Random.Range(0.2f, 0.3f);
        direction = GetRandomDirection();
    }

    private void Move()
    {
        rb.MovePosition(transform.position + direction * speed);
    }

    private Vector3 GetRandomDirection()
    {
        return new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1)).normalized;
    }

    private void OnCollisionEnter(Collision other)
    {
        HandleCollision(other);
    }

    protected virtual void HandleCollision(Collision other)
    {
        if (other.gameObject.name.Equals("Ground")) return;
        Vector3 normal = other.contacts[0].normal;
        direction = Vector3.Reflect(direction, normal);
    }
    
    private protected void ReplaceTWithNewCreature<T>(Collision other, GameObject newCreature){
        if (other.gameObject.GetComponent<T>() != null)
        {
            Vector3 pos = other.gameObject.transform.position;
            Destroy(other.gameObject);
            Instantiate(newCreature, pos, Quaternion.identity);
        }
    }
}
