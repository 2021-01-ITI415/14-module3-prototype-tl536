using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{
    public float health = 100f;
    public float currHealth;
    public float maxHealth;
    public bool isDead = false;
    public TextMeshProUGUI HP;
    public TextMeshProUGUI showdeath;
    public GameObject myself;

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
        showdeath.SetText("Game Over");
        
        StartCoroutine(Restart());

    }
    private void Update()
    {

        HP.SetText(health.ToString());
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);



    }
}
