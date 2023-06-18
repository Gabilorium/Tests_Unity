public static class Functions
{
    public static void TakeDamage(float life, float timer, float damage, float cooldown)
    {
        if (timer <= 0)
        {
            life -= damage;

            if (data.life <= 0)
            {
                Destroy(gameObject);
            }

            timer = cooldown;
        }
    }
}