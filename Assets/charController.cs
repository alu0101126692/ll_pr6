using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class charController : MonoBehaviour
{
    
    public Text locTexto;


    private float lastCompass;
    public float compassSmooth = 0.5f;

 


    public bool moveStopped = false;
    private Vector3 shakeAcc;

    public GameObject misil;
    private bool touchChanged = false;
    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start(0.1f, 0.1f);
        Input.compass.enabled = true;
        
    }

    // Update is called once per frame
    private void manageTouch() {
        if (Input.touchCount > 0 && !touchChanged) {
            if (moveStopped)
                moveStopped = false;
            else 
                moveStopped = true;
            touchChanged = true;

        } else if (Input.touchCount == 0){
            touchChanged = false;
        }
    }

    private void manageInteraction() {
        if (!moveStopped) {

            float currentMagneticHeading = (float)Math.Round(Input.compass.magneticHeading, 2);
            if (lastCompass < currentMagneticHeading - compassSmooth || lastCompass > currentMagneticHeading + compassSmooth) {
                lastCompass = currentMagneticHeading;
                transform.localRotation = Quaternion.Euler(0, lastCompass, 0);
            }

        } else {
            shakeAcc = Input.acceleration;
            if (shakeAcc.sqrMagnitude >= 5f) {
                Instantiate(misil, transform.position, transform.rotation);
            }
        }
    }
    void Update()
    {   
        
        
        
        manageTouch();
        locTexto.text = ("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude);

        manageInteraction();
        
        

        
    }
}
