using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Header("General")]
	[Tooltip("In ms^-1")][SerializeField] float Speed = 10f;
	[Tooltip("In m")][SerializeField] float xRange = 4.3f;
	[Tooltip("In m")][SerializeField] float yRange = 3.5f;
    [SerializeField] GameObject[] guns;

    [Header("Screen-position based")]
	[SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control-throw based")]
	[SerializeField] float controlPitchFactor = -20f;
	[SerializeField] float controlRollFactor = -30f;


	float xThrow;
	float yThrow;

    bool isControlEnabled = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnPlayerDeath() //called by string reference
    {
        isControlEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isControlEnabled)
        {
             ProcessTranslation();
             ProcessRotation();
             ProceedFiring();
        }
    }

    void ProcessTranslation(){

    	xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * Speed * Time.deltaTime;
        float yOffset = yThrow * Speed * Time.deltaTime;

        float rawNewPosX = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewPosX, -xRange, xRange); //clamped the ship between the range

        float rawNewPosY = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawNewPosY, -yRange, yRange); //clamped the ship between the range 

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z); // dont change the y and z
    }

    void ProcessRotation(){
    	float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
    	float pitchDueToControlThrow = yThrow * controlPitchFactor;
    	float pitch = pitchDueToPosition + pitchDueToControlThrow;

    	float yaw = transform.localPosition.x * positionYawFactor;
    	float roll = xThrow * controlRollFactor;

    	transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }

    void ProceedFiring(){
        if(CrossPlatformInputManager.GetAxis("Fire")>0)
        {
            ActivateGuns();
        }else{
            DeactivateGuns();
        }
    }

    void ActivateGuns(){
        foreach(GameObject gun in guns){
            gun.SetActive(true);
        }
    }

    void DeactivateGuns(){
        foreach(GameObject gun in guns){
            gun.SetActive(false);
        }
    }
}
