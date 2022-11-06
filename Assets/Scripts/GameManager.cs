using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private GameObject[] cars = new GameObject[10];
    public GameObject car;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI laptimer;
    public TextMeshProUGUI destinationtext;
    public GameObject flag;
    public bool timeRunning = true;
    public float starttime = 0;
    private int currloc = 1;
    private int lap = 0;

    // declare array of 3 location destinations, x coord, y coord, and z coord
    private string[] locnames = new string[] { "Bytes", "Pentland Hills", "MSE", "Glen Mor North", "Glen Mor Fields", "Glen Mor South", "Lothian", "USDA Salinity Laboratory", "Chemical Sciences", "Greenhouses", "Computing and Communications", "Herbarium", "Fawcett Laboratory", "University Office Building", "Campbell Hall", "Genomics", "Boyden Laboratories", "Entomology" };
    private Vector3[] loccoords = new Vector3[] { new Vector3(-19.6000004f, -26.4200001f, -1157.19995f), new Vector3(-265f, -19.7999992f, -1314f), new Vector3(118f, -32.7299995f, -1269.09998f), new Vector3(-627, -10.3000002f, -1464), new Vector3(-749.599976f, -4.80000019f, -1588.5f), new Vector3(-597.400024f, -13.2200003f, -1267.30005f), new Vector3(-304.100006f, -21.5599995f, -1210.59998f), new Vector3(-444, -22.2299995f, -954.299988f), new Vector3(-352, -25.3299999f, -992.200012f), new Vector3(-352, -12.6300001f, -774.700012f), new Vector3(-423, 1.52999997f, -549), new Vector3(-262.899994f, -0.639999986f, -529.900024f), new Vector3(-254.100006f, -8.47999954f, -655.900024f), new Vector3(-165.699997f, -10.3900003f, -655.900024f), new Vector3(-71.5999985f, -15.5100002f, -655.900024f), new Vector3(-20.2999992f, -17.3400002f, -655.900024f), new Vector3(-56.7000008f, -12.5100002f, -573.299988f), new Vector3(-9.60000038f, -13.5799999f, -534.400024f) };



    // Start is called before the first frame update
    void Start()
    {
        //currloc = Random.Range(0, locnames.Length);
        setDestination(currloc);
        for (int i = 0; i < 10; i++)
        {
            GameObject newcar = Instantiate(car, new Vector3(0, -10000, 0), Quaternion.identity);
            cars[i] = newcar;
        }
        Debug.Log(locnames.Length);
        Debug.Log(loccoords.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRunning)
        {
            // set timer to Time.time with format Time: HH:MM:SS:MS
            float time = Time.time;
            int hours = (int)time / 3600;
            int minutes = (int)(time % 3600) / 60;
            int seconds = (int)(time % 3600) % 60;
            int milliseconds = (int)(time * 1000) % 1000;
            timer.text = "Time: " + hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("000");
        }
    }

    public void CompleteLevel()
    {
        float time = Time.time - starttime;
        if (time < 1)
        {
            return;
        }
        // generate new random int for currlocal that is different from currlocal
        int newloc = Random.Range(0, locnames.Length);
        while (newloc == currloc)
        {
            newloc = Random.Range(0, locnames.Length);
        }
        currloc = newloc;
        setDestination(currloc);
        Debug.Log(time);
        int hours = (int)time / 3600;
        int minutes = (int)(time % 3600) / 60;
        int seconds = (int)(time % 3600) % 60;
        int milliseconds = (int)(time * 1000) % 1000;
        laptimer.text = "Lap Time: " + hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("000");
        starttime = Time.time;
        // timeRunning = false;
    }

    public void setDestination(int loc)
    {
        ++lap;
        destinationtext.text = "Destination #" + lap + ": " + locnames[loc];
        flag.transform.position = loccoords[loc];
        Debug.Log("Destination coordinates: " + loccoords[loc]);
    }

}
