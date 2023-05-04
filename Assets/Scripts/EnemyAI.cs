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
    public AudioClip[] zombieAttackSounds;
    private AudioSource soundSource;
    int n=0;
    private bool soundActive; 
    


    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth health;
    Transform target;
    public GameObject player;
    bool playerDead;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
        soundSource= GetComponent<AudioSource>();

    }



    // Update is called once per frame
    void Update()
    {
        if (health.IsDead()) 
        {
            enabled = false;
            navMeshAgent.enabled = false;
            soundActive= false;
        }

        // Stop sound after killing the player      
        if(playerDead){
            soundSource.Stop();
        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked && !playerDead)
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

       
        if(gameObject.activeSelf && !soundSource.isPlaying){
            soundActive= true;
        startSoundChase();
        }


    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
        playerDead = player.GetComponent<PlayerHealth>().playerIsDead;

        Debug.Log(playerDead);
        

        if(gameObject.activeSelf && !soundSource.isPlaying && playerDead){
            soundActive= true;
            startSoundAttack();
        }

    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation , lookRotation,Time.deltaTime * turnSpeed);

    }

    
   void startSoundChase(){
        n= UnityEngine.Random.Range(1, zombieSounds.Length);
        soundSource.clip= zombieSounds[n];
        soundSource.Play();
        Debug.Log("CHASING");

            // to avoid repeating the sound
          zombieSounds[n]= zombieSounds[0];
         zombieSounds[0]= soundSource.clip;

    }

    void startSoundAttack(){
        n= UnityEngine.Random.Range(1, zombieAttackSounds.Length);
        soundSource.clip= zombieAttackSounds[n];
        soundSource.Play();
        Debug.Log("ATTACKING");

        // to avoid repeating the sound
          zombieAttackSounds[n]= zombieAttackSounds[0];
         zombieAttackSounds[0]= soundSource.clip;
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }


}
