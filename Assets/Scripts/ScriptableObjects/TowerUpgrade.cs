using UnityEngine;

[CreateAssetMenu(fileName = "TowerUpgrade", menuName = "TowerDefense/TowerUpgrade", order = 1)]
public class TowerUpgrade : ScriptableObject
{
    public string upgradeName;
    public string description;
    public int cost;
    public float newFireRate;
    public int newDamage;
    public float newProjectileSpeed;
    public float newExplosionRadius;
    public int bulletsPerShot; // For spread shot
    public Laser newLaser; // For laser tower
    public float damagePerSecond; // For DOT tower
    // Method to apply the upgrade to a tower
    public void ApplyUpgrade(TowerStateManager tower)
    {
        if (newFireRate > 0)
        {
            tower.fireRate = newFireRate;
        }

        if (newDamage > 0)
        {
            tower.Damage = newDamage;
        }

        if (newProjectileSpeed > 0)
        {
            tower.ProjectileSpeed = newProjectileSpeed;
        }

        if (newExplosionRadius > 0)
        {
            // Assuming Projectile has an explosion radius property
            BombParabola bombProjectile = tower.ProjectilePrefab.GetComponent<BombParabola>();
            if (bombProjectile != null)
            {
                bombProjectile.ExplosionRadius = newExplosionRadius;
            }
        }

        if (bulletsPerShot > 0)
        {
            tower.BulletsPerShot = bulletsPerShot;
        }

        if(newLaser != null)
        {
            LaserTowerStateManager laserTower = tower as LaserTowerStateManager;
            if (laserTower != null)
            {
               laserTower.UpgradeLaser(newLaser);
            }
        }

        if(damagePerSecond > 0)
        {
            LaserTowerStateManager dotTower = tower as LaserTowerStateManager;
            if (dotTower != null)
            {
                dotTower.DamagePerSecond = damagePerSecond;
            }
        }
    }
}
