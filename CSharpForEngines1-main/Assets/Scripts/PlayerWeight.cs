using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerWeight : MonoBehaviour
{
    public int weight = 0;
    public float trueWeight = 0;
    public TMPro.TextMeshProUGUI CarryWeight;

    private void Start()
    {
        CarryWeight.text = "Carry Weight: " + weight;
    }

    private void Update()
    {
        

        switch (weight)
        {
            case 0:
                trueWeight = 10;
                break;
            case 1:
                trueWeight = 20;
                break;
            case 2:
                trueWeight = 30;
                break;
            case 3:
                trueWeight = 40;
                break;
            case 4:
                trueWeight = 50;
                break;
            case 5:
                trueWeight = 60;
                break;
            case 6:
                trueWeight = 70;
                break;
            case 7:
                    trueWeight = 80;
                break;
            case 8:
                    trueWeight = 90;
                break;
            case 9:
                    trueWeight = 100;
                break;
            case 10:
                    trueWeight = 110;
                break;
            case 11:
                    trueWeight = 120;
                break;
            case 12:
                    trueWeight = 130;
                break;
            case 13:
                    trueWeight = 140;
                break;
            case 14:
                    trueWeight = 150;
                break;
            case 15:
                    trueWeight = 160;
                break;
            case 16:
                    trueWeight = 170;
                break;
            case 17:
                    trueWeight = 180;
                break;
            case 18:
                    trueWeight = 190;
                break;
            case 19:
                    trueWeight = 200;
                break;
        }
      
    }

}
