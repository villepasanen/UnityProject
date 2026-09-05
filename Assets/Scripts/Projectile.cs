using System;
using UnityEngine;
using UnityEngine.WSA;

public class Projectile : MonoBehaviour
{
 [SerializeField] float _travelSpeed;
    [SerializeField] float _damage;
    [SerializeField] ParticleSystem _hitParticles;
    [SerializeField] Rigidbody2D _rb;

    public void InitializeProjectile(Vector2 direction)
    {
        Launch(direction);
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.gameObject.CompareTag("Terrain"))
        {
            DestroyProjectile();
        }   
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    void DestroyProjectile()
    {
        ParticleSystem hitparticles = Instantiate(_hitParticles, transform.position, Quaternion.identity);
        Destroy(hitparticles.gameObject, 1f);
        Destroy(gameObject);
    }
    void Launch(Vector2 direction)
    {
        Vector2 movement = direction.normalized * _travelSpeed;
        _rb.linearVelocity = movement;
    }
}
