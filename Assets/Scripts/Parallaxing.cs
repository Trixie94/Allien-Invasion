using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

    public Transform[] backgrounds;         // Array of all back and foregrounds to be parallaxed.
    private float[] parallaxScales;         // The proportion of the camera's movement to move the backgrounds by.
    public float smoothing = 1f;                 // How smooth the parralax is going to be. Set this above 0 or else won't work.

    private Transform cam;                  // Reference to the main cameras transform.
    private Vector3 previousCamPos;         // The postion of the camera in the previous frame.


    void Awake()
    {
        cam = Camera.main.transform;
    }
    // Use this for initialization
    void Start () {
        // The previous frame had the current frame's camera postion.
        previousCamPos = cam.position;

        // Asigning coresponding parallaxScales
        parallaxScales = new float[backgrounds.Length];
        for(int i=0; i< backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0; i < backgrounds.Length; i++)
        {
            // The parallax is the opposite of the camera movement because the previous frame multiplied by the scale.
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            // Set a target x position which is the current position plus the parallax.
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // Create a target position which is the background's current position with it's target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Fade between current position and the target position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

        }

        // Set previousCamPos to the camera's position at the end of the frame.
        previousCamPos = cam.position;
	}
}
