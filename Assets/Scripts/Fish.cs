using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float speed = 60f;
    public string catTag = "Cat";
    public float lifeTime = 2f;

    private Rigidbody _rigidbody;
    private float _lifeTimeCounter = 0;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.forward * speed;
    }
    
    void Update()
    {
        _lifeTimeCounter += Time.deltaTime;
        if (_lifeTimeCounter > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(catTag))
        {
            var target = collision.collider.GetComponent<ReactiveTarget>();
            if (target != null)
            {
                target.ReactToHit();
                Destroy(gameObject); 
            }
        }
    }
}