using UnityEngine;
using UnityEngine.UI;

#region Health Float Holder and healthbar Updater

public class Health : MonoBehaviour
{
    public Image healthbar;
    public float health = 100;
    
    private void Update()
    {
        // Fill the healthbar according to the players HP
        healthbar.fillAmount = health / 100;
    }
}

#endregion