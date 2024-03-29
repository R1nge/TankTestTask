using UnityEngine;

namespace Weapons
{
    public class DoubleWeapon : Weapon
    {
        public override void Shoot(int damage)
        {
            for (int i = 0; i < 2; i++)
            {
                var projectile = Instantiate(
                    projectilePrefab,
                    shootPoint.position + new Vector3(i * .1f, i * .1f),
                    transform.rotation);
                projectile.velocity = (transform.up * projectileSpeed);
                if (projectile.TryGetComponent(out Projectile proj))
                {
                    proj.damage = damage;
                }
            }
        }
    }
}