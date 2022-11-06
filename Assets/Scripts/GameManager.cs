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
    private int currloc = 0;
    private int lap = 0;

    // declare array of 3 location destinations, x coord, y coord, and z coord
    private string[] locnames = new string[] { "Pentland Hills", "Lothian", "Glasgow", "Dundee", "Aberdeen-Inverness", "Environmental Health and Safety", "Glen Mor North", "Glen Mor Fields", "Glen Mor South", "Lothian", "Veitch Student Center", "Winston Chung Hall", "Physics Building", "Orbach Library", "Geology Building", "Science Laboratories", "Webber Hall", "Boyce Hall", "SOM Education", "Plant Environment and Greenhouses", "Batchelor Hall", "Spieth Hall", "Life Sciences", "Biological Sciences", "Genomics", "Boyden Laboratories", "Entomology", "SOM Research", "Chapman Hall", "Anderson Hall", "Entomology Museum", "Herbarium", "Fawcett Laboratory", "University Office Building", "USDA Salinity Laboratory", "Chemical Sciences", "Computing and Communications", "SOM Student Center", "Campbell Hall", "Botanic Gardens", "Falrik Apartments", "Barnockburn Village", "Student Recreation Center", "MultiDisciplinary Building", "Materials and Science Building", "University Theatre", "Skye Hall", "Bookstore", "Bourne Hall", "The Hub", "CHASS Parking Lot", "Arts Building", "Pierce Hall", "Rivera Library", "Bell Tower", "Costco Hall", "Student Services", "Watkins Hall", "Sproule Hall", "Humanities 1500", "Olmstead Hall", "University Theatre", "Psychology" };
    private Vector3[] loccoords = new Vector3[] { new Vector3(322.799988f, -19.1299992f, -572.400024f), new Vector3(318.809998f, -21.9699993f, -707.599976f), new Vector3(191f, -18.4799995f, -372.600006f), new Vector3(177.399994f, -18.4799995f, -352.100006f), new Vector3(35.9000015f, -19.9400005f, -352.100006f), new Vector3(595f, -7.34000015f, -227.860001f), new Vector3(653.119995f, -10.1599998f, -449f), -new Vector3(775.700012f, -4.63999987f, -310.79998f), new Vector3(689f, -12.2700005f, -598.599976f), new Vector3(329f, -21.2000008f, -696.650024f), new Vector3(185f, -22.8400002f, -611.77002f), new Vector3(117.300003f, -27.4300003f, -751.200012f), new Vector3(83f, -22.7299995f, -851.700012f), new Vector3(216.100006f, -27.1800003f, -806.200012f), new Vector3(5.19999981f, -24.2399998f, -812.900024f), new Vector3(63.0999985f, -21.6000004f, -930.799988f), new Vector3(92.1999969f, -20.8199997f, -1008.70001f), new Vector3(201.699997f, -19.1000004f, -1008.70001f), new Vector3(267.899994f, -19.6800003f, -1008.70001f), new Vector3(324f, -11.0799999f, -1188.5f), new Vector3(169.899994f, -16.25f, -1142.59998f), new Vector3(27.5f, -21.4699993f, -1105.53003f), new Vector3(-31.5f, -20.7919998f, -1213.40002f), new Vector3(54.4000015f, -18.7600002f, -1202.09998f), new Vector3(79.5f, -14.9300003f, -1287.59998f), new Vector3(73.5f, -13.1780005f, -1330.09998f), new Vector3(39.5f, -13.5f, -1375.09998f), new Vector3(71.3000031f, -9.60999966f, -1431.59998f), new Vector3(36.4000015f, -11.4219999f, -1431.59998f), new Vector3(28.5f, -9.42000008f, -1501.09998f), new Vector3(97.0999985f, -6.32999992f, -1468.59998f), new Vector3(97.0999985f, -6.32999992f, -1468.59998f), new Vector3(258.899994f, -9f, -1252.54004f), new Vector3(156.100006f, -10.1700001f, -1280.69995f), new Vector3(489.26001f, -20.1399994f, -1011.77002f), new Vector3(385.799988f, -25.1200008f, -925.599976f), new Vector3(445f, 1.83000004f, -1363f), new Vector3(213.399994f, -18.8600006f, -1049.91003f), new Vector3(111.300003f, -13.3000002f, -1279.69995f), new Vector3(674f, 16.3400002f, -1473.70996f), new Vector3(-539.400024f, -30.5699997f, -213.600006f), new Vector3(-539.400024f, -32.2999992f, -524.700012f), new Vector3(-211.419998f, -25.9599991f, -338.799988f), new Vector3(-76, -29.6000004f, -560), new Vector3(-90.4000015f, -32.4000015f, -644.700012f), new Vector3(-217.100006f, -25.9799995f, -741.700012f), new Vector3(-298.299988f, -30.6499996f, -708.299988f), new Vector3(-166.300003f, -24.9099998f, -794.75f), new Vector3(-58.0999985f, -19.5799999f, -704.599976f), new Vector3(-229.5f, -24.5f, -916.5f), new Vector3(-422.5f, -29.2299995f, -792.299988f), new Vector3(-550.099976f, -29.2000008f, -842.299988f), new Vector3(-158, -24.5f, -925), new Vector3(-178, -25.7999992f, -1093.59998f), new Vector3(-190.199997f, -25.1000004f, -1032.09998f), new Vector3(-311, -26.7000008f, -953.700012f), new Vector3(-360, -26.9799995f, -953.700012f), new Vector3(-257.299988f, -27.2199993f, -1129.69995f), new Vector3(-406.399994f, -28.7099991f, -1121.19995f), new Vector3(-406.399994f, -28.7099991f, -1121.19995f), new Vector3(-152.699997f, -23.1499996f, -1315.80005f), new Vector3(-229.5f, -25.2999992f, -1268.90002f), new Vector3(-229.5f, -25.2999992f, -1268.90002f), new Vector3(-167.899994f, -25, -1403.19995f) };

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
