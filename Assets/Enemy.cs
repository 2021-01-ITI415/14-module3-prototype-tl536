using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float damage;
    float lastAttackTime = 0;
    float attackCooldown = 2;
    private NavMeshAgent Mob;
    private Animation Anim;
    public GameObject Player;
    public float MobDistanceRun = 10.0f;
    public float AtkDistance = 1.0f;
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
        if(distance < MobDistanceRun)
        {
            StopEnemy();
            if((Time.time - lastAttackTime) >= attackCooldown)
            {
                lastAttackTime = Time.time;
                Player.GetComponent<CharacterStats>().TakeDamage(damage);

            }

        }
        else
        {
            GoToTarget();
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
}
