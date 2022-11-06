using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private GameObject[] cars = new GameObject[10];
    public GameObject car;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI destinationtext;
    public GameObject flag;
    public bool timeRunning = true;
    public float starttime = 0;

    // declare array of 3 location destinations, x coord, y coord, and z coord
    private string[] locnames = new string[3] { "Bytes", "Pentland Hills", "MSE" };
    private Vector3[] loccoords = new Vector3[] { new Vector3(-19.6000004f, -26.4200001f, -1157.19995f), new Vector3(-265f, -19.7999992f, -1314f), new Vector3(118f, -32.7299995f, -1269.09998f) };



    // Start is called before the first frame update
    void Start()
    {
        setDestination(Random.Range(0, 3));
        for (int i = 0; i < 10; i++)
        {
            GameObject newcar = Instantiate(car, new Vector3(0, -10000, 0), Quaternion.identity);
            cars[i] = newcar;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRunning)
        {
            // set timer to Time.time with format Time: HH:MM:SS:MS
            float time = Time.time - starttime;
            int hours = (int)time / 3600;
            int minutes = (int)(time % 3600) / 60;
            int seconds = (int)(time % 3600) % 60;
            int milliseconds = (int)(time * 1000) % 1000;
            timer.text = "Time: " + hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("000");
        }
    }

    public void CompleteLevel()
    {
        timeRunning = false;
        starttime = Time.time;
        setDestination(Random.Range(0, 3));
    }

    public void setDestination(int loc)
    {
        destinationtext.text = "Destination: " + locnames[loc];
        flag.transform.position = loccoords[loc];
        Debug.Log("Destination coordinates: " + loccoords[loc]);
    }

}
