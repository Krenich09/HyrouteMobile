using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLook : MonoBehaviour
{
    public Transform Player;
    public Vector3 Offset;
    public Material mat;
    public Color NewColor;
    public Color dark;
    private void Start()
    {
        InvokeRepeating("ChangeColor", 0, 0.3f);
    }
    public void ChangeColor()
    {
        NewColor = GameMechanics.instance.Top.Evaluate(GameMechanics.instance.timeStart);
        Color n = Color.Lerp(NewColor, dark, 0.2f);
        mat = new Material(Shader.Find("Universal Render Pipeline/Unlit")); 
        mat.color = NewColor;
        mat.renderQueue = 3000;
        gameObject.GetComponent<MeshRenderer>().material = mat;

    }
    private void Update()
    {
        transform.LookAt(transform.right * 10);
        transform.position = Player.position + Offset;
    }
}
