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
    public AudioClip zombieAttackSound;
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

    void startSoundChaseZ(){
        n= UnityEngine.Random.Range(1, zombieSounds.Length);
        soundSource.clip= zombieSounds[n];
        // soundSource.Play();
        soundSource.PlayOneShot(soundSource.clip);
        Debug.Log("CHASING");

        zombieSounds[n]= zombieSounds[0];
        zombieSounds[0]= soundSource.clip;
            }

   void startSoundChase(){
       soundSource.Play();
    }

    void startSoundAttack(){
        // n= UnityEngine.Random.Range(1, zombieSounds.Length);
        soundSource.clip= zombieAttackSound;
        soundSource.Play();
        Debug.Log("ATTACKING");

        // zombieSounds[n]= zombieSounds[0];
        // zombieSounds[0]= soundSource.clip;
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

       
        if(gameObject.activeSelf){
        startSoundChase();
        }


    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);


 if(gameObject.activeSelf){
        startSoundAttack();
        }

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
