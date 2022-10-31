using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMechanics : MonoBehaviour
{
    public static GameMechanics instance;
    public bool GameLost;
    public float Fuel;
    public GameObject particalPop;

    public Material skyBox;
    public Gradient Top;
    public Gradient Bottom;

    public Gradient LightColor;
    public Light directionalLight;
    public float KMScore;
    public float timeMultiplier;

    public int FirstTime = 0;


    [Range(0, 1)]
    public float timeStart;

    [Header("Spawner")]
    public int Progress;
    public int Difficulty = 0;
    public float Lvl1;
    public float Lvl2;
    public float Lvl3 = 100;

    public GameObject FuelStack;
    public float CheckDistance;
    public Transform spawnLoc;
    
    public bool isMainMenu;
    [Header("Sounds")]
    public Vector2 volumeRange;
    private AudioSource mainSource;
    public AudioSource windSource;

    private float currentClip;
    public float delayForNextSong;
    public AudioClip[] mainClips;
    public int randomClipPlay;
    [Space]
    public AudioClip[] Clips;
    public GameObject SourceObj;
    [Space]
    [Header("Rain")]
    public float currentRain;
    public float CurrentSong;
    public float[] Challanges;

    public GameObject Tutorial;
    private void Awake()
    {
        instance = this;
        Progress = PlayerPrefs.GetInt("Progress");
        FirstTime = PlayerPrefs.GetInt("First");
        
    }
    private void Start()
    {

        mainSource = GetComponent<AudioSource>();
        randomClipPlay = (int)Random.Range(0, mainClips.Length - 1);
        delayForNextSong = Random.Range(10f, 20f);
        callRain();
        Difficulty = 0;
        timeStart = Random.Range(0f, 1f);
        if(PlayerPrefs.GetInt("First") == 0)
        {
            Fuel = 50;
        }
        InvokeRepeating("ChangeColorSlow", 0, 0.5f);
    }

    IEnumerator turnOff()
    {
        yield return new WaitForSeconds(mainSource.clip.length);
        delayForNextSong = Random.Range(50f, 200f);
        mainSource.clip = null;

    }

    void DoRain()
    {
        RainManager.instance.rainy = true;
        currentRain = Random.Range(30, 60);
    }
    void callRain()
    {
        float delayStart = Random.Range(120, 300);
        Invoke("DoRain", delayStart);
    }
    
    private void Update()
    {
        if (FirstTime == 0 && isMainMenu == false)
        {
            //Do Tutorial;
            if (Tutorial != null)
            {
                Tutorial.SetActive(true);
            }
        }
        else if (FirstTime == 1 && isMainMenu == false)
        {
            if(Tutorial != null)
            {
                Tutorial.SetActive(false);
            }
            Debug.Log("No need for Tutorial | Player passed " + (int)Challanges[0] + " Km");
        }
        if (PlayerPrefs.GetFloat("High") >= (int)Challanges[0])
        {
            if(PlayerPrefs.GetInt("First") == 0)
            {
                Debug.Log("Good to Go");
            }
            PlayerPrefs.SetInt("First", 1);
            if (PlayerPrefs.GetFloat("High") >= (int)Challanges[1])
            {
                if(PlayerPrefs.GetFloat("High") >= (int)Challanges[2])
                {
                    if (PlayerPrefs.GetFloat("High") >= (int)Challanges[3])
                    {
                        if (PlayerPrefs.GetFloat("High") >= (int)Challanges[4])
                        {
                            PlayerPrefs.SetInt("Progress", 5);
                        }
                        else
                        {
                            PlayerPrefs.SetInt("Progress", 4);
                        }
                    }
                    else
                    {
                        PlayerPrefs.SetInt("Progress", 3);
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("Progress", 2);
                }

            }
            else
            {
                PlayerPrefs.SetInt("Progress", 1);
            }
        }
        Progress = PlayerPrefs.GetInt("Progress");
        delayForNextSong -= Time.deltaTime;
        if (mainSource.clip == null && delayForNextSong <= -0.5f)
        {
            randomClipPlay++;

            if(randomClipPlay == mainClips.Length)
            {
                randomClipPlay = 0;
            }
            mainSource.clip = mainClips[randomClipPlay];
            mainSource.Play();
            currentClip = mainSource.clip.length;
            StartCoroutine(turnOff());
        }

        currentRain -= Time.deltaTime;
        if(currentRain <= 0)
        {
            RainManager.instance.rainy = false;
            callRain();
            currentRain = float.MaxValue;
        }

        if (UI_Manager.instance.PauseMenu.activeSelf == true || Fuel <= 0)
        {
            windSource.volume -= Time.unscaledDeltaTime;
            windSource.volume = Mathf.Clamp(windSource.volume, volumeRange.x, volumeRange.y);


        }

        else if(UI_Manager.instance.PauseMenu.activeSelf == false)
        {
            windSource.volume += Time.unscaledDeltaTime;
            windSource.volume = Mathf.Clamp(windSource.volume, volumeRange.x, volumeRange.y);
        }
        if(Fuel <= 0)
        {
            mainSource.volume -= Time.unscaledDeltaTime;
        }
        else
        {
            mainSource.volume += Time.unscaledDeltaTime;
            mainSource.volume = Mathf.Clamp(mainSource.volume, 0, 0.638f);
        }

        timeStart += Time.deltaTime * timeMultiplier;
        if(timeStart >= 0.99f)
        {
            timeStart = 0;
        }

        if(isMainMenu == false)
        {

            KMScore = UI_Manager.instance.score;

            if(KMScore >= Lvl1)
            {
                Difficulty = 1;
            }
            if (KMScore >= Lvl2)
            {
                Difficulty = 2;
            }
            if (KMScore >= Lvl3)
            {
                Difficulty = 3;
            }


            Fuel -= Time.deltaTime;
            if(Fuel <= 0)
            {
                UI_Manager.instance.LoseMenu.SetActive(true);
            }

        }

        if (Vector3.Distance(RigidBodyFollow.instance.transform.position, spawnLoc.position) <= CheckDistance)
        {
            if(isMainMenu == false)
            {
                SpawnObject(FuelStack);

            }
            spawnLoc.position = spawnLoc.position + new Vector3(150, 0, 0);
        }



    }


    public void ChangeColorSlow()
    {
        Color newColor = Top.Evaluate(timeStart);
        skyBox.SetColor("_Top", newColor);
        Color newColor1 = Bottom.Evaluate(timeStart);
        skyBox.SetColor("_Bottom", newColor1);
        directionalLight.color = LightColor.Evaluate(timeStart);
    }
    void SpawnObject(GameObject obj)
    {
        GameObject spawned = Instantiate(obj, spawnLoc.position, Quaternion.identity);
    }

}
