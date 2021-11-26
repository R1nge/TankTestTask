public class DoubleWeapon : Weapon
{
    public override void Shoot(int damage)
    {
        for (int i = 0; i < 2; i++)
        {
            var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            projectile.velocity = (transform.up * projectileSpeed);
            projectile.transform.GetComponent<Projectile>().damage = damage;
            print(damage);
        }
    }
}