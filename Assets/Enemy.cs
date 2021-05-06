using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float damage;
    float lastAttackTime = 0;
    float attackCooldown = 1;
    private NavMeshAgent Mob;
    private Animation Anim;
    public GameObject Player;
    public float health = 50f;


    public float AtkDistance = 2.0f;
    bool isStopped;
    // Start is called before the first frame update
    private void Start()
    {
        Mob = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animation>();
        Mob.Warp(transform.position);
    }

    // Update is called once per frame
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if(distance < AtkDistance)
        {
            StopEnemy();
            if((Time.time - lastAttackTime) >= attackCooldown)
            {
                lastAttackTime = Time.time;
                Player.GetComponent<CharacterStats>().TakeDamage(damage);
                Anim.Play("attack");
                if (health <= 0f)
                {

                    Die();
                }

            }

        }
        else
        {
            if (health >= 0)
            {
                GoToTarget();
            }
            
            
        }
    }
    private void GoToTarget()
    {
        Mob.isStopped = false;
        Anim.Play("run");

        Mob.SetDestination(Player.transform.position);
    }
    private void StopEnemy()
    {

        Mob.isStopped = true;



    }
    public void TakeDamage(float amount)
    {
        Anim = GetComponent<Animation>();
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {

        StartCoroutine(Death());

    }
    IEnumerator Death()
    {
        Mob.Stop();
        Anim.Play("die");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);



    }

}
