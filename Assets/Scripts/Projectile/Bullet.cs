using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    [SerializeField] private TrailRenderer trailRenderer;

    public override void Launch()
    {
        // Set the Rigidbody's velocity to move in the specified direction at the specified speed
        GetComponent<Rigidbody>().velocity = _direction * _speed;
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
