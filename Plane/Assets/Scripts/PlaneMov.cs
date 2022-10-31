using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaneMov : MonoBehaviour
{
    private float timeDelay;
    private float rotationTimeDelay;

    private float forwardSpeed;

    public GameObject[] Borders;

    [Header("Sound")]
    AudioSource motorSource;
    public float maxPitch;
    public float lowestPitch;
    public float Volume;

    [Header("Movement")]

    public float Speed;
    public float maxSpeed;
    public float moveDelay;
    public float RotationCircle;

    public float LowestAltitude;
    public float HighestAltitude;
    public float ResetTime;

    [Header("Debug")]
    public float UpRotation;
    public float DownRotation;
    public float RightRotation;
    public float LeftRotation;
    public float rotationSpeed;
    public static PlaneMov instance;
    public bool isReset;
    [HideInInspector] public bool isReseting;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        motorSource = GetComponent<AudioSource>();
        Borders[0].transform.position = new Vector3(Borders[0].transform.position.x, HighestAltitude, Borders[0].transform.position.z); ;
        Borders[1].transform.position = new Vector3(Borders[1].transform.position.x, LowestAltitude, Borders[1].transform.position.z);

        timeDelay = moveDelay;
        forwardSpeed = Speed;
        motorSource.volume = Volume;
    }
    private void Update()
    {
        foreach (GameObject border in Borders)
        {
            border.transform.position = new Vector3(transform.position.x, border.transform.position.y, transform.position.z);
        }

        if(Input.GetMouseButton(0) && CheckHeight(transform.position.y, LowestAltitude, HighestAltitude) && isReseting == false)
        {
            motorSource.pitch += Time.deltaTime;
            motorSource.pitch = Mathf.Clamp(motorSource.pitch, lowestPitch, maxPitch);
        } else if (!Input.GetMouseButton(0))
        {
            motorSource.pitch -= Time.deltaTime;
            motorSource.pitch = Mathf.Clamp(motorSource.pitch, lowestPitch, maxPitch);
        }

        if(UI_Manager.instance.PauseMenu.activeSelf == true || GameMechanics.instance.Fuel <= 0)
        {
            motorSource.volume -= Time.unscaledDeltaTime;
            motorSource.volume = Mathf.Clamp(motorSource.volume, 0, Volume);
        }
        else
        {
            motorSource.volume += Time.unscaledDeltaTime * 0.5f;
            motorSource.volume = Mathf.Clamp(motorSource.volume, 0, Volume);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * forwardSpeed * Time.deltaTime);

        if(GameMechanics.instance.isMainMenu == false)
        {

            if (Input.GetMouseButton(0) && !UI_Manager.instance.isRightSide && CheckHeight(transform.position.y, LowestAltitude, HighestAltitude) && isReseting == false)
            {
                timeDelay -= Time.deltaTime;

                if(timeDelay <= 0)
                {
                    UpRotation += Time.deltaTime * rotationSpeed;
                    UpRotation = Mathf.Clamp(UpRotation, 0, RotationCircle);

                    forwardSpeed += Time.deltaTime * 10;
                    forwardSpeed = Mathf.Clamp(forwardSpeed, Speed, maxSpeed);

                    transform.Rotate(transform.forward, UpRotation);
                }
            }
            else
            {
                timeDelay = moveDelay;

                UpRotation -= Time.deltaTime * rotationSpeed * 2f;
                UpRotation = Mathf.Clamp(UpRotation, 0, RotationCircle);
                transform.Rotate(transform.forward, UpRotation);

                forwardSpeed -= Time.deltaTime * 10;
                forwardSpeed = Mathf.Clamp(forwardSpeed, Speed, maxSpeed);
            }

            if (!CheckHeight(transform.position.y, LowestAltitude, HighestAltitude))
            {
                isReset = true;
            }
            if (isReset)
            {
                ResetMov();
            }



            if (Input.GetMouseButton(0) && UI_Manager.instance.isRightSide && CheckHeight(transform.position.y, LowestAltitude, HighestAltitude) && isReseting == false)
            {
                DownRotation -= Time.deltaTime * rotationSpeed;
                DownRotation = Mathf.Clamp(DownRotation, -RotationCircle - 0.5f, 0f);
                transform.Rotate(transform.forward, DownRotation);

            } 
            else
            {
                DownRotation += Time.deltaTime * rotationSpeed * 3f;
                DownRotation = Mathf.Clamp(DownRotation, -RotationCircle + 0.5f, 0f);
                transform.Rotate(transform.forward, DownRotation);
            }
        }

    }

    private System.Collections.IEnumerator AnimateTowards(Transform target, Quaternion rot, float time)
    {
        float t = 0f;
        Quaternion start = target.rotation;
        while(t < time)
        {
            target.rotation = Quaternion.Slerp(start, rot, t / time);
            yield return null;
            t += Time.deltaTime;
            UpRotation = 0;
            DownRotation = 0;
        } 
        target.rotation = rot;
        if(time <= t)
        {
            isReseting = false;
        }
    }


    void ResetMov()
    {
        if(CheckHeight(transform.position.y, -99999, LowestAltitude - 13))
        {
            isReseting = true;
            UpRotation += Time.deltaTime * 30;
            UpRotation = Mathf.Clamp(UpRotation, 0, 1);
            transform.Rotate(transform.forward, UpRotation);
            StartCoroutine(ResetAnim());

            Debug.Log("Down");
        } 
        else if(CheckHeight(transform.position.y, HighestAltitude + 13, 999999))
        {
            isReseting = true;
            DownRotation -= Time.deltaTime * 30;
            DownRotation = Mathf.Clamp(DownRotation, 2, 0);
            transform.Rotate(transform.forward, DownRotation);
            StartCoroutine(ResetAnim());

            Debug.Log("UP");
        }
    }

    IEnumerator ResetAnim()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(AnimateTowards(this.transform, Quaternion.identity, 2));
    }

    private bool CheckHeight(float height, float lowest, float highest)
    {
        if(lowest > highest)
        {
            return height >= highest && height <= lowest;
        }
        return height >= lowest && height <= highest;
    }

}
