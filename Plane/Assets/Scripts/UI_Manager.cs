using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    public GameObject AltitudeMSG;
    public bool isRightSide;
    public Text AltitudeText;
    public Text DistanceScore;
    public Scrollbar bar;
    public float score;
    public float HighScore;
    public Text highScoreText;
    public GameObject MainMenu;
    public GameObject InGameMenu;
    public GameObject PauseMenu;
    public GameObject LoseMenu;
    public Transform DistanceCalcu;
    public Animator anim;
    public bool DoColorsOnSky;

    public GameObject[] CreditsObj;
    bool isPause;

    private void Awake()
    {
        instance = this;


    }
    private void Start()
    {
        foreach (GameObject item in CreditsObj)
        {
            item.SetActive(false);
        }
        highScoreText.text = PlayerPrefs.GetFloat("High").ToString("0.#") + " Km";
        GameMechanics.instance.isMainMenu = true;
        PauseMenu.SetActive(false);
    }

    public void OpenCredits()
    {
        foreach (GameObject item in CreditsObj)
        {
            item.SetActive(true);
        }
    }
    public void CloseCredits()
    {
        foreach (GameObject item in CreditsObj)
        {
            item.SetActive(false);
        }
    }

    public void AdRestart(float ammount)
    {
        GameMechanics.instance.Fuel = ammount;
        LoseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        
        HighScore = PlayerPrefs.GetFloat("High");
        if (score >= PlayerPrefs.GetFloat("High"))
        {
            PlayerPrefs.SetFloat("High", score);
        }
        if (isPause || LoseMenu.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        bar.value = (RigidBodyFollow.instance.transform.position.y + 100) / 200;
        if(GameMechanics.instance.isMainMenu == false)
        {
            InGameMenu.SetActive(true);
            MainMenu.SetActive(false);
            DistanceCalcu.transform.SetParent(null);
            score = Vector3.Distance(DistanceCalcu.position, RigidBodyFollow.instance.transform.position);
            score = Mathf.Clamp(score, 0, float.MaxValue);
            score /= 100;
        }
        else
        {
            InGameMenu.SetActive(false);
            MainMenu.SetActive(true);
        }
        DistanceScore.text = score.ToString("0.#") + " Km";

        if (PlaneMov.instance.isReseting)
        {
            AltitudeMSG.SetActive(true);
        }
        else
        {
            AltitudeMSG.SetActive(false);
        }
        float score1 = GameMechanics.instance.Fuel;
        score1 = Mathf.Clamp(score1, 0, float.MaxValue);
        AltitudeText.text = score1.ToString("0");
    }

 

    public void RightClickEnter()
    {
        isRightSide = true;
    }
    public void RightClickLeave()
    {
        isRightSide = false;
    }
    public void Lost()
    {
        anim.SetBool("GoBlack", true);
        StartCoroutine(ResetLevelTime(1.5f));
    }

    public void ClickedPlay()
    {
        GameMechanics.instance.isMainMenu = false;
    }
    public void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }
    IEnumerator ResetLevelTime(float time)
    {

        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);
    }

    public void OpenPause()
    {
        PauseMenu.SetActive(true);
        isPause = true;
    }
    public void ClosePause()
    {
        isPause = false;
        PauseMenu.SetActive(false);
    }
}
