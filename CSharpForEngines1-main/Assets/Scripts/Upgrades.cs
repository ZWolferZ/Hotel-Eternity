using System.Collections;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    // Holds all player upgrades
    public  bool floor2Unlocked;
    public  bool floor3Unlocked;
    public  bool floor1Unlocked = true;
    public  bool yourFloorUnlocked;
    public  bool tutorialtrigger;
    public bool lobbyLights;
    public int money;
    private TopDownCharacterController _player;
    public bool projectileSize1;
    public bool biglight;
    

   

    // Initialising text
    private void Start()
    {
        _player.moneyLabel.text = "Money: " + money;
    }

    // Apply upgrades to the current version of the player
    private void FixedUpdate()
    {
        
        _player = FindObjectOfType<TopDownCharacterController>();
        _player.moneyLabel.text = "Money: " + money;

        if (money <= 0)
        {
            money = 0;
        }
        

        
    }
    
    
}
