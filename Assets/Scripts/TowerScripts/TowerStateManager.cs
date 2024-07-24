using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;


public class TowerStateManager : MonoBehaviour
{
    public TowerBaseState FloatingState { get; protected set; }
    public TowerBaseState GrabbedState { get; protected set; }
    public TowerBaseState IdleState { get; protected set; }
    public TowerBaseState SeekAndAttackState { get; protected set; }

    public TowerBaseState CurrentState { get; protected set; }

    [HideInInspector]
    public bool IsGrabbed { get; set; } // updated by the handgrab interaction component 
    [HideInInspector] public bool Isplaced { get; set; }




    [Header("Valid Poistion")]
    public LayerMask LayerMaskforrayCasting;
    [SerializeField] private LayerMask EnemyPath;
    [SerializeField] private LayerMask TowerLayer;
    public float raycastDistance; // Distance to cast the ray
    public float spherecastradius;
    public GameObject potentialTowerPrefab;
    public GameObject InvalidTowerPrefab;
    private GameObject potentialTower; // Instance of the potential tower
    private GameObject invalidTower;



    
    //transform of the enemy gameobject
   
    protected Transform target;
    [Header("Rotation and Range")]
    public float Range;
    public float RotateSpeed;
    public Transform PartToRotate;

    [Header("Damage and Firerate")]
    [Tooltip("No of bulltes per second")]
    public float fireRate;
    private float fireCountdown = 0f;
    public GameObject ProjectilePrefab;
    public Transform firePoint;
    public int Damage;
    public float ProjectileSpeed;
    public int BulletsPerShot { get; set; } = 1;
    protected virtual void Awake()
    {
        FloatingState = new FloatingState();
        GrabbedState = new GrabbedState();
        IdleState = new IdleState();
        SeekAndAttackState = new SeekAndAttackState();

        CurrentState = FloatingState;

    }

    protected virtual void Start()
    {
        //transform.parent = GameSettings.BasePlane.transform;
        CurrentState.EnterState(this);

        

    }

    protected virtual void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void TransitionToState(TowerBaseState newState)
    {
        CurrentState.ExitState(this);
        CurrentState = newState;
        CurrentState.EnterState(this);
    }







    public void CheckPlacement()
    {
        // Origin of the ray is the current position of the GameObject
        Vector3 rayOrigin = transform.position;

        // Direction of the ray is downwards along the Y-axis
        Vector3 rayDirection = Vector3.down;

        // Perform the raycast
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, raycastDistance * GameSettings.GetScaleMultiplier(), LayerMaskforrayCasting))
        {
            // If the ray hits something, you can handle the hit here
            Debug.DrawLine(rayOrigin, hit.point, Color.green);

            // Check if the surface is valid for tower placement
            // You can add additional checks here
            if (IsValidPlacement(hit.point))
            {




                Destroy(invalidTower);

                // If the potential tower doesn't exist, instantiate it
                if (potentialTower == null)
                {

                    potentialTower = Instantiate(potentialTowerPrefab, hit.point, Quaternion.identity);
                    potentialTower.transform.Translate(new Vector3(0f, Mathf.Abs(Vector3.Distance(potentialTower.transform.position, potentialTower.GetComponent<TowerData>().BottomPoint.position)), 0f));
                }
                else
                {
                    // Update potential tower position
                    potentialTower.transform.position = hit.point + new Vector3(0f, Mathf.Abs(Vector3.Distance(potentialTower.transform.position, potentialTower.GetComponent<TowerData>().BottomPoint.position)), 0f);


                }
            }
            else
            {


                // If the surface is not valid, destroy the potential tower
                Destroy(potentialTower);



                if (invalidTower == null)
                {

                    invalidTower = Instantiate(InvalidTowerPrefab, hit.point, Quaternion.identity);
                    invalidTower.transform.Translate(new Vector3(0f, Mathf.Abs(Vector3.Distance(invalidTower.transform.position, invalidTower.GetComponent<TowerData>().BottomPoint.position)), 0f));
                }
                else
                {
                    // Update invalid tower position
                    invalidTower.transform.position = hit.point + new Vector3(0f, Mathf.Abs(Vector3.Distance(invalidTower.transform.position, invalidTower.GetComponent<TowerData>().BottomPoint.position)), 0f);
                }

            }
        }
        else
        {
            // If no surface is hit, destroy the potential tower
            Destroy(potentialTower);
            Destroy(invalidTower);
        }
    }



    

    public void OnRelease()
    {

        if (potentialTower != null)
        { // Placed case
            
            //considering offset
            transform.position = potentialTower.transform.position;
            transform.rotation = Quaternion.identity;

            
            Isplaced = true;
            
        }

        Destroy(potentialTower);
        if (invalidTower != null)
        {
            Destroy(invalidTower);

         
            Isplaced = false;
            
        }
    }

    bool IsValidPlacement(Vector3 position)
    {
        // Cast a sphere around the position to check for nearby colliders
        Collider[] colliders = Physics.OverlapSphere(position, spherecastradius * GameSettings.GetScaleMultiplier());
        bool towerGroundFound = false;

        // Check each collider found in the sphere
        foreach (Collider collider in colliders)
        {
            // Check if the collider's layer is TowerGround
            if (collider.gameObject.layer != LayerMask.NameToLayer("Default"))
            {
                if (collider.gameObject.layer == LayerMask.NameToLayer("TowerGround"))
                {
                    towerGroundFound = true;
                }
                // If any other layer is found, return false

                else if (collider.gameObject.layer == EnemyPath || collider.gameObject.layer == TowerLayer)
                {
                    return false;
                }
            }

        }

        // If TowerGround layer is found and no other layers are present, return true
        return towerGroundFound;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spherecastradius * GameSettings.GetScaleMultiplier());
        Gizmos.DrawWireSphere(transform.position, Range * GameSettings.GetScaleMultiplier());

    }



    //Check for Enemy in Range
    public virtual bool EnemyInRange()
    {
        // Perform sphere cast
        Collider[] colliders = Physics.OverlapSphere(transform.position, Range);

        // Check each collider found
        foreach (Collider collider in colliders)
        {
            // Check if the collider's tag is "Enemy"
            if (collider.CompareTag("Enemy"))
            {
                // Enemy found, return true
                return true;
            }
        }

        // No enemy found within range
        return false;
    }


    public void GetTarget()
    {
        GetTargetByLast();
    }
    void GetTargetByLast()// i.e. Spawned the earliest
    {
        float earliestenemypos = Mathf.Infinity;
        GameObject foundenemy = null;
        // Get all colliders within the sphere around the current GameObject's position
        Collider[] colliders = Physics.OverlapSphere(transform.position, Range * GameSettings.GetScaleMultiplier());

        // Iterate through all colliders found
        foreach (Collider collider in colliders)
        {
            // Check if the collider has the specified tag
            if (collider.CompareTag("Enemy"))
            {

                GameObject enemy = collider.gameObject;

                if (enemy.GetComponent<EnemyData>().EnemyPos < earliestenemypos)
                {
                    earliestenemypos = enemy.GetComponent<EnemyData>().EnemyPos;
                    foundenemy = enemy;
                }

            }
        }

        if (foundenemy != null)
        {
            target = foundenemy.transform;
        }
        else
        {
            target = null;
        }
    }

    public void LockToTarget()
    {
        if (target == null)
        {
            return;
        }
        //Taregt Lock on
        Vector3 dir = target.position - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * RotateSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    public virtual void Fire()
    {
        if (target != null && fireCountdown <= 0f)
        {
            for (int i = 0; i < BulletsPerShot; i++)
            {
                FireProjectile(i);
            }
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    private void FireProjectile(int bulletIndex)
    {
        GameObject projGO = Instantiate(ProjectilePrefab, firePoint.position, firePoint.rotation);
        Projectile proj = projGO.GetComponent<Projectile>();

        // Apply spread based on bulletIndex if BulletsPerShot > 1
        if (BulletsPerShot > 1)
        {
            float spreadAngle = 5f; // Adjust spread angle as needed
            float angle = spreadAngle * (bulletIndex - (BulletsPerShot - 1) / 2f);
            projGO.transform.Rotate(0, angle, 0);
        }

        proj.SetTarget(target, ProjectileSpeed * GameSettings.GetScaleMultiplier(), Damage);
        proj.Launch();
    }
}