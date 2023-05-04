using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{



    [SerializeField] int ammoAmount = 10;
    [SerializeField] AmmoType ammoType;
    private AudioSource soundSource;


private void Start() {
    soundSource= GetComponent<AudioSource>();

}

 void collectSound(){
        soundSource.Play();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);
            collectSound();
            Debug.Log("AMMO");
        }
    }

    private void OnTriggerExit(Collider other) {
                if(other.gameObject.tag == "Player"){
                    Destroy(gameObject);
                }
    }
}
