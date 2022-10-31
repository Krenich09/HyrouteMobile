using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomFuel : MonoBehaviour
{
    // Start is called before the first frame update
    public float amount;
    public string charecter;
    public TextMesh visual;


    public float newAmmount;
    void Start()
    {
        GetRandomNumber();
        visual.text = amount.ToString("0.##") + " " + charecter;
    }

    void GetRandomNumber()
    {
        if(GameMechanics.instance.Difficulty == 0)
        {
            int cases = Random.Range(1, 3);  
            switch (cases)
            {
                case 1:
                    charecter = "+";
                    amount = Random.Range(7, 30);
                    break;
                case 2:
                    charecter = "-";
                    amount = Random.Range(7, 20);
                    break;
                case 3:
                    charecter = "x";
                    amount = Random.Range(0.1f, 1.5f);
                    break;
            }
        }
        if(GameMechanics.instance.Difficulty == 1)
        {
            int cases1 = Random.Range(1, 6);
            switch (cases1)
            {
                case 1:
                    charecter = "+";
                    amount = Random.Range(7, 30);
                    break;
                case 2:
                    charecter = "-";
                    amount = Random.Range(7, 20);
                    break;
                case 3:
                    charecter = "x";
                    amount = Random.Range(0.1f, 1.5f);
                    break;
                case 4:
                    charecter = "÷";
                    amount = Random.Range(0.9f, 4f);
                    break;
                case 5:
                    charecter = "x";
                    amount = Random.Range(0.1f, 1f);
                    break;
                case 6:
                    charecter = "-";
                    amount = Random.Range(15, 40);
                    break;
            }
        }
        if (GameMechanics.instance.Difficulty == 2)
        {
            int cases2 = Random.Range(1, 9);
            switch (cases2)
            {
                case 1:
                    charecter = "+";
                    amount = Random.Range(7f, 30f);
                    break;
                case 2:
                    charecter = "-";
                    amount = Random.Range(7f, 20f);
                    break;
                case 3:
                    charecter = "x";
                    amount = Random.Range(0.1f, 1.5f);
                    break;
                case 4:
                    charecter = "÷";
                    amount = Random.Range(0.8f, 4);
                    break;
                case 5:
                    charecter = "x";
                    amount = Random.Range(0.1f, 1f);
                    break;
                case 6:
                    charecter = "-";
                    amount = Random.Range(15f, 40f);
                    break;
                case 7:
                    charecter = "-";
                    amount = Random.Range(15f, 70f);
                    break;
                case 8:
                    charecter = "-";
                    amount = Random.Range(5f, 40f);
                    break;
                case 9:
                    charecter = "÷";
                    amount = Random.Range(2, 4);
                    break;
            }
        }
        if (GameMechanics.instance.Difficulty == 3)
        {
            int cases2 = Random.Range(1, 11);
            switch (cases2)
            {
                case 1:
                    charecter = "+";
                    amount = Random.Range(10f, 40f);
                    break;
                case 2:
                    charecter = "-";
                    amount = Random.Range(30f, 90f);
                    break;
                case 3:
                    charecter = "x";
                    amount = Random.Range(0.1f, 1.1f);
                    break;
                case 4:
                    charecter = "÷";
                    amount = Random.Range(0.8f, 100);
                    break;
                case 5:
                    charecter = "x";
                    amount = Random.Range(0f, 1f);
                    break;
                case 6:
                    charecter = "-";
                    amount = Random.Range(30f, 70f);
                    break;
                case 7:
                    charecter = "-";
                    amount = Random.Range(100f, 300f);
                    break;
                case 8:
                    charecter = "-";
                    amount = Random.Range(50f, 90f);
                    break;
                case 9:
                    charecter = "÷";
                    amount = Random.Range(2, 10);
                    break;
                case 10:
                    charecter = "-";
                    amount = Random.Range(30, 50);
                    break;
                case 11:
                    charecter = "x";
                    amount = Random.Range(0.1f, 1.1f);
                    break;

            }
        }
    }

    public float CalculateFuel(float currentFuel)
    {
        switch (charecter)
        {
            case "+":
                newAmmount = currentFuel += amount;
                break;
            case "-":
                newAmmount = currentFuel -= amount;
                break;
            case "x":
                newAmmount = currentFuel *= amount;
                break;
            case "÷":
                newAmmount = currentFuel/amount;
                break;
        }
        return newAmmount;
    }
}
