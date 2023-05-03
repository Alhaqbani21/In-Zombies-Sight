using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .1f;
    [SerializeField] float angleDecay = .1f;
    [SerializeField] float minimumAngle = 40f;


    Light myLight;

    private void Start()
    {
        myLight= GetComponent<Light>();
    }

    private void Update()
    {
        DecreasLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }
    public void AddLightIntensity(float internsityAmount)
    {
        myLight.intensity += internsityAmount; 
    }

    private void DecreasLightAngle()
    {
        if (myLight.spotAngle <= minimumAngle)
        {
            return;
        }
        else
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }
        

    }
    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

}
