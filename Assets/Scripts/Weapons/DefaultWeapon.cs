public class DefaultWeapon : Weapon
{
    public override void Shoot(int damage)
    {
        var projectile = Instantiate(projectilePrefab, shootPoint.position, transform.rotation);
        projectile.velocity = (transform.up * projectileSpeed);
        projectile.transform.GetComponent<Projectile>().damage = damage;
        print(damage);
    }
}