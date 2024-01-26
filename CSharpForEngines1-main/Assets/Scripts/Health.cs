using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthbar;

    public float health;
    

    // Update is called once per frame
    void Update()
    {
        
        healthbar.fillAmount = health / 100;


    }
}
