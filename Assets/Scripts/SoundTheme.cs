using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTheme : MonoBehaviour
{

    private bool playerDead;
    private int n=0;
    public AudioClip[] soundClips;
    private AudioSource soundSource;
    public GameObject player;





    // Start is called before the first frame update
    void Start()
    {
        soundSource= GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

    playerDead = player.GetComponent<PlayerHealth>().playerIsDead;

    if(playerDead){
        soundSource.Stop();
    }else if(!soundSource.isPlaying){
        startSound();
    }


        
    }



    void startSound(){
        n= UnityEngine.Random.Range(1, soundClips.Length);
        soundSource.clip= soundClips[n];
        soundSource.Play();
        Debug.Log("THEME ON");

            // to avoid repeating the sound
          soundClips[n]= soundClips[0];
         soundClips[0]= soundSource.clip;    }
}
