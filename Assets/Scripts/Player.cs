using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
	[Tooltip("In ms^-1")][SerializeField] float Speed = 20f;
	[Tooltip("In m")][SerializeField] float xRange = 4.3f;
	[Tooltip("In m")][SerializeField] float yRange = 2.3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * Speed * Time.deltaTime;
        float yOffset = yThrow * Speed * Time.deltaTime;

        float rawNewPosX = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewPosX, -xRange, xRange); //clamped the ship between the range

        float rawNewPosY = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawNewPosY, -yRange, yRange); //clamped the ship between the range 

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z); // dont change the y and z

    }
}
