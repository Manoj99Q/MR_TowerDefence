using UnityEngine;

public class RotatingLaser : Laser
{
    public int numberOfLasers;
    public float distanceFromCenter;
    public float rotationSpeed;
    public Laser laserPrefab; // Reference to the Laser prefab

    private Laser[] laserInstances;

    private void Start()
    {
        laserInstances = new Laser[numberOfLasers];

        float angleStep = 360f / numberOfLasers;
        for (int i = 0; i < numberOfLasers; i++)
        {
            CreateLaserAtAngle(i * angleStep);
        }
    }

    private void CreateLaserAtAngle(float angle)
    {
        // Instantiate the laser from the prefab
        Laser laserInstance = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laserInstance.transform.parent = transform; // Make laser a child of this object
        laserInstance.enabled = true;

        // Position laser correctly relative to the parent
        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * distanceFromCenter;
        float z = Mathf.Sin(angle * Mathf.Deg2Rad) * distanceFromCenter;
        laserInstance.transform.localPosition = new Vector3(x, 0, z);

        // Save the laser instance
        laserInstances[(int)(angle / (360f / numberOfLasers))] = laserInstance;
    }

    private void RotateLasers(float _damagePerSecond, Vector3 firePoint)
    {
        // Rotate the entire parent object
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Fire each laser
        for (int i = 0; i < numberOfLasers; i++)
        {
            laserInstances[i].FireLaser(firePoint, laserInstances[i].transform.position, _damagePerSecond);
        }
    }

    public override void FireLaser(Vector3 startPos, Vector3 endPos, float damagePerSec)
    {
        RotateLasers(damagePerSec, startPos);
    }
}
