using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public GameObject car;
    public GameObject camera;
    public float CarX;
    public float CarY;
    public float CarZ;
    public float speed;
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
        transform.localPosition = new Vector3(0, 0, -speed * cameraFollowMultiplier * acceleration);

    }
}
