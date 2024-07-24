using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected Transform _target;
    protected int _ProjectileDamage;
    protected float _speed;
    protected Vector3 _direction; // Add this to store the initial direction

    // Abstract method for updating the position of the projectile
    protected abstract void UpdatePosition();

    // Method for handling collision detection
    public virtual void CollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(_ProjectileDamage);
            Destroy(gameObject);
            return;
        }
    }

    public void SetTarget(Transform target, float speed, int damage)
    {
        _target = target;
        _ProjectileDamage = damage;
        _speed = speed;
    }

    // Set the initial direction for the projectile
    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
    }

    // Common method for launching the projectile
    public abstract void Launch(); // speed needs to be scaled before passing

    // Unity's Update method
    protected void Update()
    {
        UpdatePosition();
        //if enemy dies before
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }
    }

    // Unity's OnCollisionEnter method
    private void OnCollisionEnter(Collision collision)
    {
        CollisionEnter(collision);
    }

    protected void Awake()
    {
        transform.localScale *= GameSettings.GetScaleMultiplier();
    }
}
