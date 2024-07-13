using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{

    [SerializeField] private TrailRenderer trailRenderer;
    public override void Launch()
    {
        
        if (_target != null)
        {
            // Calculate the direction to the target
            Vector3 direction = (_target.position - transform.position).normalized;


            // Set the Rigidbody's velocity to move towards the target at the specified speed
            GetComponent<Rigidbody>().velocity = direction * _speed;
        }
    }

    protected override void UpdatePosition()
    {
        //nothing
        return;
    }

    private void Awake()
    {
        base.Awake();
        trailRenderer.widthMultiplier *= GameSettings.GetScaleMultiplier();
    }
}
