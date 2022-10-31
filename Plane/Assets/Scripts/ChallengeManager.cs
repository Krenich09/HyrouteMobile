using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChallengeManager : MonoBehaviour
{
    public GameObject[] Challenges;
    public GameObject[] DonePics;
    [Space]
    [Space]
    [Space]


    public int CurrentProgress;

    private void Start()
    {
        CurrentProgress = PlayerPrefs.GetInt("Progress");
        if(PlayerPrefs.GetInt("Progress") == 0)
        {
            Challenges[0].GetComponent<Text>().color = new Color(Challenges[0].GetComponent<Text>().color.r, Challenges[0].GetComponent<Text>().color.g, Challenges[0].GetComponent<Text>().color.b, 0f / 1.5f);
            Challenges[1].GetComponent<Text>().color = new Color(Challenges[1].GetComponent<Text>().color.r, Challenges[1].GetComponent<Text>().color.g, Challenges[1].GetComponent<Text>().color.b, 0.2f / 1.5f);
            Challenges[2].GetComponent<Text>().color = new Color(Challenges[2].GetComponent<Text>().color.r, Challenges[2].GetComponent<Text>().color.g, Challenges[2].GetComponent<Text>().color.b, 0.4f / 1.5f);
            Challenges[3].GetComponent<Text>().color = new Color(Challenges[3].GetComponent<Text>().color.r, Challenges[3].GetComponent<Text>().color.g, Challenges[3].GetComponent<Text>().color.b, 0.6f / 1.5f);
            Challenges[4].GetComponent<Text>().color = new Color(Challenges[4].GetComponent<Text>().color.r, Challenges[4].GetComponent<Text>().color.g, Challenges[4].GetComponent<Text>().color.b, 0.8f / 1.5f);


            DonePics[0].GetComponent<Image>().color = new Color(DonePics[0].GetComponent<Image>().color.r, DonePics[0].GetComponent<Image>().color.g, DonePics[0].GetComponent<Image>().color.b, 0f / 1.5f);
            DonePics[1].GetComponent<Image>().color = new Color(DonePics[1].GetComponent<Image>().color.r, DonePics[1].GetComponent<Image>().color.g, DonePics[1].GetComponent<Image>().color.b, 0.2f / 1.5f);
            DonePics[2].GetComponent<Image>().color = new Color(DonePics[2].GetComponent<Image>().color.r, DonePics[2].GetComponent<Image>().color.g, DonePics[2].GetComponent<Image>().color.b, 0.4f / 1.5f);
            DonePics[3].GetComponent<Image>().color = new Color(DonePics[3].GetComponent<Image>().color.r, DonePics[3].GetComponent<Image>().color.g, DonePics[3].GetComponent<Image>().color.b, 0.6f / 1.5f);
            DonePics[4].GetComponent<Image>().color = new Color(DonePics[4].GetComponent<Image>().color.r, DonePics[4].GetComponent<Image>().color.g, DonePics[4].GetComponent<Image>().color.b, 0.8f / 1.5f);
            for (int i = 0; i < DonePics.Length; i++)
            {
                DonePics[i].SetActive(false);
            }
        }
        else
        {
            if(PlayerPrefs.GetInt("Progress") == 1)
            {
                Challenges[0].GetComponent<Text>().color = new Color(Challenges[0].GetComponent<Text>().color.r, Challenges[0].GetComponent<Text>().color.g, Challenges[0].GetComponent<Text>().color.b, 0f/1.5f);
                Challenges[1].GetComponent<Text>().color = new Color(Challenges[1].GetComponent<Text>().color.r, Challenges[1].GetComponent<Text>().color.g, Challenges[1].GetComponent<Text>().color.b, 0.2f / 1.5f);   
                Challenges[2].GetComponent<Text>().color = new Color(Challenges[2].GetComponent<Text>().color.r, Challenges[2].GetComponent<Text>().color.g, Challenges[2].GetComponent<Text>().color.b, 0.4f / 1.5f);
                Challenges[3].GetComponent<Text>().color = new Color(Challenges[3].GetComponent<Text>().color.r, Challenges[3].GetComponent<Text>().color.g, Challenges[3].GetComponent<Text>().color.b, 0.6f / 1.5f); 
                Challenges[4].GetComponent<Text>().color = new Color(Challenges[4].GetComponent<Text>().color.r, Challenges[4].GetComponent<Text>().color.g, Challenges[4].GetComponent<Text>().color.b, 1f / 1.5f);

                DonePics[0].GetComponent<Image>().color = new Color(DonePics[0].GetComponent<Image>().color.r, DonePics[0].GetComponent<Image>().color.g, DonePics[0].GetComponent<Image>().color.b, 0f / 1.5f);
                DonePics[1].GetComponent<Image>().color = new Color(DonePics[1].GetComponent<Image>().color.r, DonePics[1].GetComponent<Image>().color.g, DonePics[1].GetComponent<Image>().color.b, 0.2f / 1.5f);
                DonePics[2].GetComponent<Image>().color = new Color(DonePics[2].GetComponent<Image>().color.r, DonePics[2].GetComponent<Image>().color.g, DonePics[2].GetComponent<Image>().color.b, 0.4f / 1.5f);
                DonePics[3].GetComponent<Image>().color = new Color(DonePics[3].GetComponent<Image>().color.r, DonePics[3].GetComponent<Image>().color.g, DonePics[3].GetComponent<Image>().color.b, 0.6f / 1.5f);
                DonePics[4].GetComponent<Image>().color = new Color(DonePics[4].GetComponent<Image>().color.r, DonePics[4].GetComponent<Image>().color.g, DonePics[4].GetComponent<Image>().color.b, 1f / 1.5f);



                for (int i = 0; i < DonePics.Length - 1; i++)
                {
                    DonePics[i].SetActive(false);
                }
            }
            else if (PlayerPrefs.GetInt("Progress") == 2)
            {
                Challenges[0].GetComponent<Text>().color = new Color(Challenges[0].GetComponent<Text>().color.r, Challenges[0].GetComponent<Text>().color.g, Challenges[0].GetComponent<Text>().color.b, 0.2f / 1.5f);
                Challenges[1].GetComponent<Text>().color = new Color(Challenges[1].GetComponent<Text>().color.r, Challenges[1].GetComponent<Text>().color.g, Challenges[1].GetComponent<Text>().color.b, 0.4f / 1.5f);
                Challenges[2].GetComponent<Text>().color = new Color(Challenges[2].GetComponent<Text>().color.r, Challenges[2].GetComponent<Text>().color.g, Challenges[2].GetComponent<Text>().color.b, 0.6f / 1.5f);
                Challenges[3].GetComponent<Text>().color = new Color(Challenges[3].GetComponent<Text>().color.r, Challenges[3].GetComponent<Text>().color.g, Challenges[3].GetComponent<Text>().color.b, 1f / 1.5f);
                Challenges[4].GetComponent<Text>().color = new Color(Challenges[4].GetComponent<Text>().color.r, Challenges[4].GetComponent<Text>().color.g, Challenges[4].GetComponent<Text>().color.b, 0.6f / 1.5f);


                DonePics[0].GetComponent<Image>().color = new Color(DonePics[0].GetComponent<Image>().color.r, DonePics[0].GetComponent<Image>().color.g, DonePics[0].GetComponent<Image>().color.b, 0.2f / 1.5f);
                DonePics[1].GetComponent<Image>().color = new Color(DonePics[1].GetComponent<Image>().color.r, DonePics[1].GetComponent<Image>().color.g, DonePics[1].GetComponent<Image>().color.b, 0.4f / 1.5f);
                DonePics[2].GetComponent<Image>().color = new Color(DonePics[2].GetComponent<Image>().color.r, DonePics[2].GetComponent<Image>().color.g, DonePics[2].GetComponent<Image>().color.b, 0.6f / 1.5f);
                DonePics[3].GetComponent<Image>().color = new Color(DonePics[3].GetComponent<Image>().color.r, DonePics[3].GetComponent<Image>().color.g, DonePics[3].GetComponent<Image>().color.b, 1f / 1.5f);
                DonePics[4].GetComponent<Image>().color = new Color(DonePics[4].GetComponent<Image>().color.r, DonePics[4].GetComponent<Image>().color.g, DonePics[4].GetComponent<Image>().color.b, 0.6f / 1.5f);
                for (int i = 0; i < DonePics.Length - 2; i++)
                {
                    DonePics[i].SetActive(false);
                }
            }
            else if (PlayerPrefs.GetInt("Progress") == 3)
            {
                Challenges[0].GetComponent<Text>().color = new Color(Challenges[0].GetComponent<Text>().color.r, Challenges[0].GetComponent<Text>().color.g, Challenges[0].GetComponent<Text>().color.b, 0.4f / 1.5f);
                Challenges[1].GetComponent<Text>().color = new Color(Challenges[1].GetComponent<Text>().color.r, Challenges[1].GetComponent<Text>().color.g, Challenges[1].GetComponent<Text>().color.b, 0.6f / 1.5f);
                Challenges[2].GetComponent<Text>().color = new Color(Challenges[2].GetComponent<Text>().color.r, Challenges[2].GetComponent<Text>().color.g, Challenges[2].GetComponent<Text>().color.b, 1f / 1.5f);
                Challenges[3].GetComponent<Text>().color = new Color(Challenges[3].GetComponent<Text>().color.r, Challenges[3].GetComponent<Text>().color.g, Challenges[3].GetComponent<Text>().color.b, 0.6f / 1.5f);
                Challenges[4].GetComponent<Text>().color = new Color(Challenges[4].GetComponent<Text>().color.r, Challenges[4].GetComponent<Text>().color.g, Challenges[4].GetComponent<Text>().color.b, 0.4f / 1.5f);

                DonePics[0].GetComponent<Image>().color = new Color(DonePics[0].GetComponent<Image>().color.r, DonePics[0].GetComponent<Image>().color.g, DonePics[0].GetComponent<Image>().color.b, 0.4f / 1.5f);
                DonePics[1].GetComponent<Image>().color = new Color(DonePics[1].GetComponent<Image>().color.r, DonePics[1].GetComponent<Image>().color.g, DonePics[1].GetComponent<Image>().color.b, 0.6f / 1.5f);
                DonePics[2].GetComponent<Image>().color = new Color(DonePics[2].GetComponent<Image>().color.r, DonePics[2].GetComponent<Image>().color.g, DonePics[2].GetComponent<Image>().color.b, 1f / 1.5f);
                DonePics[3].GetComponent<Image>().color = new Color(DonePics[3].GetComponent<Image>().color.r, DonePics[3].GetComponent<Image>().color.g, DonePics[3].GetComponent<Image>().color.b, 0.6f / 1.5f);
                DonePics[4].GetComponent<Image>().color = new Color(DonePics[4].GetComponent<Image>().color.r, DonePics[4].GetComponent<Image>().color.g, DonePics[4].GetComponent<Image>().color.b, 0.4f / 1.5f);
                for (int i = 0; i < DonePics.Length - 3; i++)
                {
                    DonePics[i].SetActive(false);
                }
            }
            else if (PlayerPrefs.GetInt("Progress") == 4)
            {
                Challenges[0].GetComponent<Text>().color = new Color(Challenges[0].GetComponent<Text>().color.r, Challenges[0].GetComponent<Text>().color.g, Challenges[0].GetComponent<Text>().color.b, 0.6f / 1.5f);
                Challenges[1].GetComponent<Text>().color = new Color(Challenges[1].GetComponent<Text>().color.r, Challenges[1].GetComponent<Text>().color.g, Challenges[1].GetComponent<Text>().color.b, 1f / 1.5f);
                Challenges[2].GetComponent<Text>().color = new Color(Challenges[2].GetComponent<Text>().color.r, Challenges[2].GetComponent<Text>().color.g, Challenges[2].GetComponent<Text>().color.b, 0.6f / 1.5f);
                Challenges[3].GetComponent<Text>().color = new Color(Challenges[3].GetComponent<Text>().color.r, Challenges[3].GetComponent<Text>().color.g, Challenges[3].GetComponent<Text>().color.b, 0.4f / 1.5f);
                Challenges[4].GetComponent<Text>().color = new Color(Challenges[4].GetComponent<Text>().color.r, Challenges[4].GetComponent<Text>().color.g, Challenges[4].GetComponent<Text>().color.b, 0.2f / 1.5f);

                DonePics[0].GetComponent<Image>().color = new Color(DonePics[0].GetComponent<Image>().color.r, DonePics[0].GetComponent<Image>().color.g, DonePics[0].GetComponent<Image>().color.b, 0.6f / 1.5f);
                DonePics[1].GetComponent<Image>().color = new Color(DonePics[1].GetComponent<Image>().color.r, DonePics[1].GetComponent<Image>().color.g, DonePics[1].GetComponent<Image>().color.b, 1f / 1.5f);
                DonePics[2].GetComponent<Image>().color = new Color(DonePics[2].GetComponent<Image>().color.r, DonePics[2].GetComponent<Image>().color.g, DonePics[2].GetComponent<Image>().color.b, 0.6f / 1.5f);
                DonePics[3].GetComponent<Image>().color = new Color(DonePics[3].GetComponent<Image>().color.r, DonePics[3].GetComponent<Image>().color.g, DonePics[3].GetComponent<Image>().color.b, 0.4f / 1.5f);
                DonePics[4].GetComponent<Image>().color = new Color(DonePics[4].GetComponent<Image>().color.r, DonePics[4].GetComponent<Image>().color.g, DonePics[4].GetComponent<Image>().color.b, 0.2f / 1.5f);
                for (int i = 0; i < DonePics.Length - 4; i++)
                {
                    DonePics[i].SetActive(false);
                }
            }
            else if (PlayerPrefs.GetInt("Progress") == 5)
            {
                Challenges[0].GetComponent<Text>().color = new Color(Challenges[0].GetComponent<Text>().color.r, Challenges[0].GetComponent<Text>().color.g, Challenges[0].GetComponent<Text>().color.b, 1f / 1.5f);
                Challenges[1].GetComponent<Text>().color = new Color(Challenges[1].GetComponent<Text>().color.r, Challenges[1].GetComponent<Text>().color.g, Challenges[1].GetComponent<Text>().color.b, 0.6f / 1.5f);
                Challenges[2].GetComponent<Text>().color = new Color(Challenges[2].GetComponent<Text>().color.r, Challenges[2].GetComponent<Text>().color.g, Challenges[2].GetComponent<Text>().color.b, 0.4f / 1.5f);
                Challenges[3].GetComponent<Text>().color = new Color(Challenges[3].GetComponent<Text>().color.r, Challenges[3].GetComponent<Text>().color.g, Challenges[3].GetComponent<Text>().color.b, 0.2f / 1.5f);
                Challenges[4].GetComponent<Text>().color = new Color(Challenges[4].GetComponent<Text>().color.r, Challenges[4].GetComponent<Text>().color.g, Challenges[4].GetComponent<Text>().color.b, 0f / 1.5f);

                DonePics[0].GetComponent<Image>().color = new Color(DonePics[0].GetComponent<Image>().color.r, DonePics[0].GetComponent<Image>().color.g, DonePics[0].GetComponent<Image>().color.b, 1f / 1.5f);
                DonePics[1].GetComponent<Image>().color = new Color(DonePics[1].GetComponent<Image>().color.r, DonePics[1].GetComponent<Image>().color.g, DonePics[1].GetComponent<Image>().color.b, 0.6f / 1.5f);
                DonePics[2].GetComponent<Image>().color = new Color(DonePics[2].GetComponent<Image>().color.r, DonePics[2].GetComponent<Image>().color.g, DonePics[2].GetComponent<Image>().color.b, 0.4f / 1.5f);
                DonePics[3].GetComponent<Image>().color = new Color(DonePics[3].GetComponent<Image>().color.r, DonePics[3].GetComponent<Image>().color.g, DonePics[3].GetComponent<Image>().color.b, 0.2f / 1.5f);
                DonePics[4].GetComponent<Image>().color = new Color(DonePics[4].GetComponent<Image>().color.r, DonePics[4].GetComponent<Image>().color.g, DonePics[4].GetComponent<Image>().color.b, 0f / 1.5f);
                for (int i = 0; i < DonePics.Length - 5; i++)
                {
                    DonePics[i].SetActive(false);
                }
            }
        }   
    }

    private void Update()
    {
    }
}
