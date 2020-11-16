using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    private float health;

    [SerializeField] int worth = 50;

    [SerializeField] GameObject deathEffect;

    [Header("Unity Stuff")]
    [SerializeField] Image healthBar;

    private bool isDead = false;    

    private void Start()
    {
        health = startHealth;
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct); ;

        if (health < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        waveSpawner.EnemiesAlive--;

        Destroy(gameObject);

    }
}
