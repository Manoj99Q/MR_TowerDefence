using UnityEngine;

public class Laser : MonoBehaviour
{
    protected LineRenderer linerenderer;
    protected float orglinemultiplier;
    public LayerMask enemyLayer; // Layer mask to specify which layers the raycast should hit

    private void Awake()
    {
        linerenderer = GetComponent<LineRenderer>();
        orglinemultiplier = linerenderer.widthMultiplier;
    }

    public virtual void FireLaser(Vector3 startPos, Vector3 endPos, float damagePerSec)
    {
        // Perform the raycast
        RaycastHit hit;
        Vector3 direction = (endPos - startPos).normalized;
        float distance = Vector3.Distance(startPos, endPos);

        // Raycast in the direction from startPos to endPos
        if (Physics.Raycast(startPos, direction, out hit, 2*distance, enemyLayer))
        {
            // Set the laser positions to the hit point
            linerenderer.SetPosition(0, startPos);
            linerenderer.SetPosition(1, hit.point);

            // Apply damage to the hit object
            Health health = hit.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damagePerSec * Time.deltaTime);
            }
        }
        else
        {
            // If no hit, draw the laser to the endPos
            linerenderer.SetPosition(0, startPos);
            linerenderer.SetPosition(1, endPos);
        }

        // Adjust laser width multiplier
        linerenderer.widthMultiplier = orglinemultiplier * GameSettings.GetScaleMultiplier();
    }

    public void DisableLaser()
    {
        Destroy(this.gameObject);
    }
}
