using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombParabola : Projectile
{
    private  float launchAngle =45; // in degrees

    private float time;


    public float ExplosionRadius;

    //public int radiusMultiplier = 1;

    public GameObject ExplosionEffect;

    public LayerMask enemylayerMask;

    public TrailRenderer trailRenderer;
    public override void Launch()
    {
        StartCoroutine(SimulateProjectile());

    }

    protected override void UpdatePosition()
    {
        return;
    }


    protected void Awake()
    {
        base.Awake();
        trailRenderer.widthMultiplier *= GameSettings.GetScaleMultiplier();

    }


/*    void CalculateLaunchParameters()
    {
        // Calculate initial velocity components
        float angleInRadians = launchAngle * Mathf.Deg2Rad;
        float distance = Vector3.Distance(initialPosition, _target.position);

        // Calculate horizontal and vertical components of initial velocity
        float v0x = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * angleInRadians));
        float v0y = v0x * Mathf.Sin(angleInRadians);

        // Set the initial velocity vector
        initialVelocity = _target.position - initialPosition;
        initialVelocity.Normalize(); // Normalize the direction vector
        initialVelocity *= v0x; // Scale the direction vector by horizontal component

        // Add vertical component to the initial velocity
        initialVelocity.y += v0y;
    }


    Vector3 CalculateProjectilePosition(float time)
    {
        float x = initialVelocity.x * time;
        float y = initialVelocity.y * time - 0.5f * Mathf.Abs(Physics.gravity.y) * time * time;

        return initialPosition + new Vector3(x, y, 0);
    }*/

    public override void CollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Destroy(gameObject);

            GameObject explosion = Instantiate(ExplosionEffect, collision.contacts[0].point, Quaternion.identity, GameSettings.BasePlane.transform);
            explosion.transform.localScale *=  GameSettings.GetScaleMultiplier();
            Destroy(explosion, 2f);


            // Perform the overlap sphere
            Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius * GameSettings.GetScaleMultiplier(), enemylayerMask);


            foreach (Collider collider in colliders)
            {
                collider.gameObject.GetComponent<Health>().TakeDamage(_ProjectileDamage);
            }


            return;
        }
    }


    /*  IEnumerator SimulateProjectile()
      {


          // Calculate distance to target
          float target_Distance = Vector3.Distance(transform.position, _target.position);

          // Calculate the velocity needed to throw the object to the target at specified angle.
          float projectile_Velocity = target_Distance / (Mathf.Sin(2 * launchAngle * Mathf.Deg2Rad) / 9.8f);

          // Extract the X  Y componenent of the velocity
          float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(launchAngle * Mathf.Deg2Rad);
          float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(launchAngle * Mathf.Deg2Rad);

          // Calculate flight time.
          float flightDuration = target_Distance / Vx;

          // Rotate projectile to face the target.
          transform.rotation = Quaternion.LookRotation(_target.position - transform.position);

          float elapse_time = 0;

          while (elapse_time < flightDuration)
          {
              transform.Translate(0, (Vy - (9.8f * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

              elapse_time += Time.deltaTime;

              yield return null;
          }
      }*/

    IEnumerator SimulateProjectile()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = _target.position;

        // Calculate the direction to the target
        Vector3 direction = (targetPosition - startPosition).normalized;

        // Calculate the total distance to the target
        float totalDistance = Vector3.Distance(startPosition, targetPosition);

        // Precompute values for the 45-degree angle parabola
        float height = totalDistance / 2f; // Max height at the midpoint
        float flightDuration = totalDistance / _speed;

        float elapsedTime = 0;

        while (elapsedTime < flightDuration)
        {
            float t = elapsedTime / flightDuration;

            // Calculate the new position along the linear path
            Vector3 newPosition = startPosition + direction * _speed * t * flightDuration;

            // Add the parabolic height offset
            float parabolaHeight = 4 * height * t * (1 - t);
            newPosition.y = startPosition.y + (direction.y * _speed * t * flightDuration) + parabolaHeight;

            // Move the projectile
            transform.position = newPosition;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the projectile reaches the exact target position
        transform.position = targetPosition;
    }
}
