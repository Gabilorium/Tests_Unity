public class Functions
{

    public static void TakeDamage(GameObject target, float damage, float cooldown, ref float timer, ref float life)
    {
        if (timer <= 0)
        {
            life -= damage;

            if (life <= 0)
            {
                Destroy(target);
            }

            timer = cooldown;
        }
    }
}