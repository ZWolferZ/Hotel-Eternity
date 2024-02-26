using System.Collections;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
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
    

   

    private void Start()
    {
        _player.moneyLabel.text = "Money: " + money;
    }

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
