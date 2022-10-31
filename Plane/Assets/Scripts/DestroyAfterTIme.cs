using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTIme : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<ParticleSystem>() != null)
        {
            Destroy(gameObject, GetComponent<ParticleSystem>().main.duration); 
        }
        if (GetComponent<AudioSource>() != null)
        {
            if (GetComponent<AudioSource>().clip != null)
            {
                Destroy(gameObject, GetComponent<AudioSource>().clip.length);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {   
    }
}
