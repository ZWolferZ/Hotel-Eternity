
using System.Collections;
using UnityEngine;
using Image = UnityEngine.UI.Image;


public class UpgradeUI : MonoBehaviour
{
    // Initialising variables 
    [SerializeField] private GameObject upgradePopup;
    private CamTrigger _camTrigger;
    private Upgrades _upgrades;
    public Image lobbyLightsButton;
    public Image floor2Button;
    public Image floor3Button;
    public Image yourfloorButton;
    public Image projectileSize1;
    public Image projectileRefill;
    public Image playerlightupgradeButton;
    [SerializeField] private AudioSource errorAudioSource;
    [SerializeField] private AudioSource boughtAudioSource;
    private TopDownCharacterController _player;
    

    
    // Gather script
    private void Awake()
    {
        _camTrigger = FindObjectOfType<CamTrigger>();
    }

    // Wait a sec, then gather scripts
    private void Start()
    {
        StartCoroutine(Begin(0.1f));

    }

    private void FixedUpdate()
    {
        // If the player leaves the trigger, disable the UI
        if (!_camTrigger.inTigger)
        {
            upgradePopup.SetActive(false);
        }

        // If the player has enough money, display green button, else red button is displayed
        lobbyLightsButton.color = _upgrades.money >= 50 ? Color.green : Color.red;
        floor2Button.color = _upgrades.money >= 50 ? Color.green : Color.red;
        floor3Button.color = _upgrades.money >= 200 ? Color.green : Color.red;
        yourfloorButton.color = _upgrades.money >= 500 ? Color.green : Color.red;
        projectileSize1.color = _upgrades.money >= 150 ? Color.green : Color.red;
        projectileRefill.color = _upgrades.money >= 20 ? Color.green : Color.red;
        playerlightupgradeButton.color = _upgrades.money >= 200 ? Color.green : Color.red;
        
        // Check if the upgrades have been bought, display yellow button
        if (_upgrades.lobbyLights)
        {
            lobbyLightsButton.color = Color.yellow;
        }
        if (_upgrades.floor2Unlocked)
        {
            floor2Button.color = Color.yellow;
        }
        if (_upgrades.floor3Unlocked)
        {
            floor3Button.color = Color.yellow;
        }
        if (_upgrades.yourFloorUnlocked)
        {
            yourfloorButton.color = Color.yellow;
        }
        if (_upgrades.projectileSize1)
        {
            projectileSize1.color = Color.yellow;
        }
        if (_player.mStartingBullets == 5)
        {
            projectileRefill.color = Color.yellow;
        }
        if (_upgrades.biglight)
        {
            playerlightupgradeButton.color = Color.yellow;
        }
        
        
        
    }

    public void PopupButton()
    {
        upgradePopup.SetActive(true);
    }
    public void BackButton()
    {
        upgradePopup.SetActive(false);
    }
    
    // If enough money, buy upgrade, play sound
    public void LobbyLights()
    {
        if (_upgrades.money >= 50 && !_upgrades.lobbyLights)
        {
            _upgrades.money -= 50;
            boughtAudioSource.Play();
            _upgrades.lobbyLights = true;
        }
        else
        {
            errorAudioSource.Play();
        }
    }
    
    // If enough money, buy upgrade, play sound
    public void Refill()
    {
        if (_upgrades.money >= 20 && (_player.mStartingBullets != 5))
        {
            _upgrades.money -= 20;
            boughtAudioSource.Play();
            _player.mStartingBullets = 5;
        }
        else
        {
            errorAudioSource.Play();
        }
    }
    
    // If enough money, buy upgrade, play sound
    public void Floor2()
    {
        if (_upgrades.money >= 50 && !_upgrades.floor2Unlocked)
        {
            _upgrades.money -= 50;
            boughtAudioSource.Play();
            _upgrades.floor2Unlocked = true;
        }
        else
        {
            errorAudioSource.Play();
        }
    }
    
    // If enough money, buy upgrade, play sound
    public void Floor3()
    {
        if (_upgrades.money >= 200 && !_upgrades.floor3Unlocked)
        {
            _upgrades.money -= 200;
            boughtAudioSource.Play();
            _upgrades.floor3Unlocked = true;
        }
        else
        {
            errorAudioSource.Play();
        }
    }
    
    // If enough money, buy upgrade, play sound
    public void YourFloor()
    {
        if (_upgrades.money >= 500 && !_upgrades.yourFloorUnlocked)
        {
            _upgrades.money -= 500;
            boughtAudioSource.Play();
            _upgrades.yourFloorUnlocked = true;
        }
        else
        {
            errorAudioSource.Play();
        }
    }
    
    // If enough money, buy upgrade, play sound
    public void Projectilesize1()
    {
        if (_upgrades.money >= 150 && !_upgrades.projectileSize1)
        {
            _upgrades.money -= 150;
            boughtAudioSource.Play();
            _upgrades.projectileSize1 = true;
        }
        else
        {
            errorAudioSource.Play();
        }
    }
    
    // If enough money, buy upgrade, play sound
    public void PlayerlightUpgrade()
    {
        if (_upgrades.money >= 200 && !_upgrades.projectileSize1)
        {
            _upgrades.money -= 200;
            boughtAudioSource.Play();
            _upgrades.biglight = true;
        }
        else
        {
            errorAudioSource.Play();
        }
    }
    
    // Gather scripts after time
    private IEnumerator Begin(float time)
    {
        
        yield return new WaitForSeconds(time);
        _upgrades = FindObjectOfType<Upgrades>();
        _player = FindObjectOfType<TopDownCharacterController>();


    }   
  
}
