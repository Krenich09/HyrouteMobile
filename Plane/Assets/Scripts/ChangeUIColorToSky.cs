using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeUIColorToSky : MonoBehaviour
{
    Text text;
    Image pic;
    Material mat;
    public Color NewColor;
    public Color dark;
    public bool Bottom;
    public bool doLerp = true;
    [Range(0, 1)]
    public float LerpValue = 0.2f;
    void Start()
    {

        if(gameObject.GetComponent<Text>() != null)
        {
            text = GetComponent<Text>();
        } else if(gameObject.GetComponent<Image>() != null)
        {
            pic = GetComponent<Image>();
        }
        else if (gameObject.GetComponent<MeshRenderer>() != null)
        {
            mat = GetComponent<MeshRenderer>().material;
        }
        if (UI_Manager.instance.DoColorsOnSky)
        {
            InvokeRepeating("ChangeColor", 0, 0.7f);
        }
    }

    public void ChangeColor()
    {
        if (Bottom)
        {
            NewColor = GameMechanics.instance.Bottom.Evaluate(GameMechanics.instance.timeStart);
        }
        else
        {
            NewColor = GameMechanics.instance.Top.Evaluate(GameMechanics.instance.timeStart);
        }
        if (gameObject.GetComponent<Text>() != null)
        {
            if (doLerp)
            {
                Color n = Color.Lerp(NewColor, dark, LerpValue);
                text.color = new Color(n.r, n.g, n.b, text.color.a);
            }
            else
            {
                text.color = new Color(NewColor.r, NewColor.g, NewColor.b, text.color.a);
            }
        }
        if (gameObject.GetComponent<Image>() != null)
        {
            if (doLerp)
            {
                Color n = Color.Lerp(NewColor, dark, LerpValue);
                pic.color = new Color(n.r, n.g, n.b, pic.color.a);
            }
            else
            {
                pic.color = new Color(NewColor.r, NewColor.g, NewColor.b, pic.color.a);
            }
        }
        if (gameObject.GetComponent<MeshRenderer>() != null)
        {
            if (doLerp)
            {
                Color n = Color.Lerp(NewColor, dark, LerpValue);
                mat.color = new Color(n.r, n.g, n.b, 1);
            }
            else
            {
                mat.color = new Color(NewColor.r, NewColor.g, NewColor.b, 1);
            }
        }
    }
}
