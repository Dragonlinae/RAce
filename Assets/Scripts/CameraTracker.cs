using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public GameObject car;
    public GameObject povcamera;
    public GameObject minimap;
    public GameObject minimapcamera;
    public float CarX;
    public float CarY;
    public float CarZ;
    public float speed;
    public bool topDownCamera = false;
    public float cameraFollowMultiplier;
    public float acceleration;
    public UnityStandardAssets.Vehicles.Car.CarController carController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CarX = car.transform.eulerAngles.x;
        CarY = car.transform.eulerAngles.y;
        CarZ = car.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(0, CarY, 0);

        speed = carController.CurrentSpeed;
        acceleration = carController.AccelInput;
        if (!topDownCamera)
        {
            transform.localPosition = new Vector3(0, 0, -speed * cameraFollowMultiplier * acceleration);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            topDownCamera = true;
            povcamera.transform.localPosition = new Vector3(0, 225, 0);
            povcamera.transform.localEulerAngles = new Vector3(90, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            topDownCamera = false;
            povcamera.transform.localPosition = new Vector3(0, 3, -10);
            povcamera.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            minimap.GetComponent<RectTransform>().localScale = new Vector3(5, 5, 1);
            minimap.GetComponent<RectTransform>().localPosition = new Vector3(4096, -1952, 0);
            minimapcamera.GetComponent<Transform>().localPosition = new Vector3(0, -4096, 0);
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            minimap.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            minimap.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            minimapcamera.GetComponent<Transform>().localPosition = new Vector3(0, -4775, 0);
        }
    }
}
