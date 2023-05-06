using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class KeyCollectables : MonoBehaviour
{
    




    // Public variable to hold references to the key images on the canvas
    [SerializeField] RawImage Key;
    [SerializeField] Image KeyNotFound;
    private AudioSource soundSource;
    bool KeyPressed = false;

    [SerializeField] TMP_Text Key_text;

    // Private variable to keep track of how many keys the player has collected
    private static int keysCollected = 0;


    private void OnTriggerEnter(Collider other) {

             if (other.gameObject.tag == "Player")
            {
                Key_text.enabled = true;
            }
    }


    // This function is called when the player object collides with the key object
    private void OnTriggerStay(Collider other)
    {


        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if the colliding object is the player object
            if (other.gameObject.tag == "Player")
            {

                collectSound();
                // Disable the key object
               // gameObject.SetActive(false);

                // Increment the number of keys collected
                keysCollected++;
                KeyPressed = true;


                // Show the collected key on the canvas
                KeyNotFound.gameObject.SetActive(false);
                Key.gameObject.SetActive(true);


                // Check if the player has collected all 3 keys
                if (keysCollected == 3)
                {
                    // Display a debug log message
                    Debug.Log("Player has collected all 3 keys!");
                    FindObjectOfType<WinHandler>().HandleWin();
                    keysCollected = 0;
                }

                 

            }
        }
       
    }

     private void OnTriggerExit(Collider other) {
        
                if(other.gameObject.tag == "Player"){

                    Key_text.enabled = false;

                    if(KeyPressed){
                        Destroy(gameObject);
                    }
                   
                

                }
    }

    void collectSound(){
        Debug.Log("KEY");
        soundSource.Play();
    }

    private void Start()
    {
        Key.gameObject.SetActive(false);
        KeyNotFound.gameObject.SetActive(true);
        soundSource= GetComponent<AudioSource>();
        Key_text.enabled = false;


    }

     

    // This function is called every frame
    private void Update()
    {
        
    }
}
