namespace Weapons
{
    public class DefaultWeapon : Weapon
    {
        public override void Shoot(int damage)
        {
            var projectile = Instantiate(projectilePrefab, shootPoint.position, transform.rotation);
            projectile.velocity = transform.up * projectileSpeed;
            if (projectile.TryGetComponent(out Projectile proj))
            {
                proj.damage = damage;
            }
        }
    }
}