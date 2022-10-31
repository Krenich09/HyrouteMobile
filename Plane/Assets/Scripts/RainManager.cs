using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{
    public static RainManager instance;
    ParticleSystem particals;
    Color NewColor;
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset;
    public bool rainy;
    [Range(0f, 1f)]
    public float Intensity;
    float randomIntenisty;
    public AudioSource rainSource;
    void Start()
    {
        particals = GetComponent<ParticleSystem>();
        instance = this;
        rainSource = GetComponentInChildren<AudioSource>();
        InvokeRepeating("changeRainColor", 0, 0.7f);
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            rainy = false;
        } else if (Input.GetKeyDown(KeyCode.R))
        {
            rainy = true;
        }

        if(UI_Manager.instance.PauseMenu.activeSelf == true || GameMechanics.instance.Fuel <= 0)
        {
            rainSource.volume = 0;
        }
        else
        {
            rainSource.volume = Intensity;
        }

        if (rainy == true)
        {
            Intensity += Time.deltaTime;
            Intensity = Mathf.Clamp(Intensity, 0f, 1f);
        }
        else if (rainy == false)
        {
            Intensity -= Time.deltaTime * 0.3f;
            Intensity = Mathf.Clamp(Intensity, 0f, 1f);
            
        }
        var main = particals.main;
        var emmision = particals.emission;
        emmision.rateOverTime = 120 * Intensity;
        transform.position = target.position + offset;
    }

    public void changeRainColor()
    {
        NewColor = GameMechanics.instance.Bottom.Evaluate(GameMechanics.instance.timeStart);
        if (particals != null)
        {
            Color n = Color.Lerp(NewColor, Color.white, 0.2f);
            var main = particals.main;
            main.startColor = n;
        }
    }
}
