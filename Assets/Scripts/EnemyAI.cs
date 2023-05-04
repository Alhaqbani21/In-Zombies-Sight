using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class EnemyAI : MonoBehaviour
{
    
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    public AudioClip[] zombieSounds;
    private AudioSource soundSource;
    int n=0;
    


    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth health;
    Transform target;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
        soundSource= GetComponent<AudioSource>();

    }

    void startSound(){
        n= UnityEngine.Random.Range(1, zombieSounds.Length);
        soundSource.clip= zombieSounds[n];
        soundSource.PlayOneShot(soundSource.clip);

        zombieSounds[n]= zombieSounds[0];
        zombieSounds[0]= soundSource.clip;
            }

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead()) 
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked=true;

        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            
            AttackTarget();
        }
    }


    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
        startSound();


    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);


    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation , lookRotation,Time.deltaTime * turnSpeed);

    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }


}
