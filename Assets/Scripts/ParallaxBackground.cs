/*using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform[] backgrounds;  // Array of background layers to parallax
    public float[] parallaxScales;  // The proportion of the camera's movement to move the backgrounds by

    private Transform cam;           // Reference to the main camera's transform
    private Vector3 previousCamPosition; // The position of the camera in the previous frame

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    private void Start()
    {
        previousCamPosition = cam.position;
    }

    private void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // Calculate the parallax position
            float parallaxX = (previousCamPosition.x - cam.position.x) * parallaxScales[i];
            float backgroundTargetPosX = backgrounds[i].position.x + parallaxX;

            // Create a target position for the background
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Smoothly move the background towards the target position
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, Time.deltaTime);
        }

        // Update the previousCamPosition
        previousCamPosition = cam.position;
    }
}*/

using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform[] backgrounds;  // Array of background layers to parallax
    public float[] parallaxScalesX; // The proportion of the camera's movement to move the backgrounds on the X-axis
    public float[] parallaxScalesY; // The proportion of the camera's movement to move the backgrounds on the Y-axis

    private Transform cam;           // Reference to the main camera's transform
    private Vector3 previousCamPosition; // The position of the camera in the previous frame

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    private void Start()
    {
        previousCamPosition = cam.position;
    }

    private void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // Calculate the parallax positions
            float parallaxX = (previousCamPosition.x - cam.position.x) * parallaxScalesX[i];
            float parallaxY = (previousCamPosition.y - cam.position.y) * parallaxScalesY[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallaxX;
            float backgroundTargetPosY = backgrounds[i].position.y + parallaxY;

            // Create a target position for the background
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgroundTargetPosY, backgrounds[i].position.z);

            // Smoothly move the background towards the target position
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, Time.deltaTime);
        }

        // Update the previousCamPosition
        previousCamPosition = cam.position;
    }
}

