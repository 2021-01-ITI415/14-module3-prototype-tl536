using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterStats : MonoBehaviour
{
    public float health = 100f;
    public float currHealth;
    public float maxHealth;
    public bool isDead = false;
    public TextMeshProUGUI HP;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        
    }
    private void Update()
    {

        HP.SetText(health.ToString());
    }
}
