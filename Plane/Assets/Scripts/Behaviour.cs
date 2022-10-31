using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    public float speed;
    public float randomSpeed;
    Rigidbody rb;
    public float alpha;
    public Material mat;
    bool Die;
    public GameObject Model;
    public Transform particalCheck;
    public GameObject Particals;
    bool spawned;
    public Animator anim;

    public Gradient model_colors;
    public float randomColorValue;
    [Range(0, 1)]
    public float ColorValue;

    public bool randomColor;
    public Color NewColor;
    public float lifeTime;
    public float RandomRotateSpeed;
    [Range(0, 1)]
    public float DarkValue;
    [Range(0, 1)]
    public float BottomValue;

    public float timeTillDeath;


    private void Awake()
    {
        randomColorValue = Random.Range(0f, 1f);
        mat = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
        if (randomColor)
        {
            Color a = model_colors.Evaluate(randomColorValue);
            Color b = Color.Lerp(a, GameMechanics.instance.Bottom.Evaluate(GameMechanics.instance.timeStart), BottomValue);
            NewColor = Color.Lerp(b, Color.black, 0.35f);
            mat.color = new Color(NewColor.r, NewColor.g, NewColor.b, alpha);
        }
        else
        {

            Color a = GameMechanics.instance.Top.Evaluate(GameMechanics.instance.timeStart);
            Color b = Color.Lerp(a, GameMechanics.instance.Bottom.Evaluate(GameMechanics.instance.timeStart), BottomValue);
            NewColor = Color.Lerp(b, Color.black, DarkValue);
            mat.color = new Color(NewColor.r, NewColor.g, NewColor.b, alpha);
        }
        mat.SetFloat("_Surface", 1);
        mat.SetFloat("_Metallic", 0);
        mat.SetFloat("_Smoothness", 0);
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.renderQueue = 3000;

        Model.GetComponent<MeshRenderer>().material = mat;

    }
    // Start is called before the first frame update
    void Start()
    {
        Particals = GameMechanics.instance.particalPop;
        rb = GetComponent<Rigidbody>();
        randomSpeed = Random.Range(0.1f, 5f);
        RandomRotateSpeed = Random.Range(0.3f, 1f);
    }

    private void Update()
    {
        lifeTime += Time.deltaTime;
        if (transform.position.y > 150f || lifeTime >= 30)
        {
            StartCoroutine(destoryObj(gameObject.transform.parent.gameObject, false));
            Die = true;
        }

        if(Die == false)
        {
            alpha += Time.deltaTime * 0.4f;
            alpha = Mathf.Clamp(alpha, 0, 1f);
            mat.color = new Color(NewColor.r, NewColor.g, NewColor.b, alpha);
            Model.GetComponent<MeshRenderer>().material = mat;
            if(alpha >= 0.98f)
            {
                mat.SetFloat("_Surface", 0);
                Model.GetComponent<MeshRenderer>().material = mat;
            }
        }
        else
        {
            anim.SetTrigger("Die");
            StartCoroutine(destoryObj(gameObject, true));
            
        }
    }

    public void playSound()
    {
        int random = Random.Range(0, GameMechanics.instance.Clips.Length);
        GameObject source = Instantiate(GameMechanics.instance.SourceObj, particalCheck.position, Quaternion.identity);
        source.GetComponent<AudioSource>().clip = GameMechanics.instance.Clips[random];
        float randomVol = Random.Range(0.2f, 0.3f);
        source.GetComponent<AudioSource>().volume = randomVol;
        source.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        transform.Translate(Vector3.up * speed * randomSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, 2 * RandomRotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            playSound();
            Die = true;
            Debug.Log("Dying");
        }
    }

    IEnumerator destoryObj(GameObject obj, bool partical)
    {
        if (partical == true)
        {
            
            if(spawned == false)
            {
                GameObject particals = Instantiate(Particals, particalCheck.position, Quaternion.identity);
                spawned = true;
                anim.SetTrigger("Die");
                timeTillDeath = anim.GetCurrentAnimatorClipInfo(0).Length;
            }
        }
        else if(partical == false)
        {
            mat.SetFloat("_Surface", 1);
            alpha -= Time.deltaTime;
            alpha = Mathf.Clamp(alpha, 0, 1f);
            mat.color = new Color(NewColor.r, NewColor.g, NewColor.b, alpha);
            Model.GetComponent<MeshRenderer>().material = mat;
            timeTillDeath = 2;
        }
        yield return new WaitForSeconds(timeTillDeath);
        Destroy(obj);
    }
}
