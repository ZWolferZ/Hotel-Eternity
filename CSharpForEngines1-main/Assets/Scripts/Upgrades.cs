using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public  bool floor2Unlocked;
    public  bool floor3Unlocked;
    public  bool floor1Unlocked = true;
    public  bool yourFloorUnlocked;
    public  bool tutorialtrigger;
    public int money;
    private TopDownCharacterController _player;

    private void Awake()
    {
        _player = FindObjectOfType<TopDownCharacterController>();
        _player.moneyLabel.text = "Money: " + money;
    }

    private void FixedUpdate()
    {
        // I know it's expensive but I need to re-update it if the player dies (It's a little lazy)
        _player = FindObjectOfType<TopDownCharacterController>();
        _player.moneyLabel.text = "Money: " + money;

        if (money <= 0)
        {
            money = 0;
        }
    }
}
