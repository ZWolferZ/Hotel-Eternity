
using System.Collections;
using UnityEngine;
using Image = UnityEngine.UI.Image;


public class UpgradeUI : MonoBehaviour
{
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
    

    
    private void Awake()
    {
        _camTrigger = FindObjectOfType<CamTrigger>();
    }

    private void Start()
    {
        StartCoroutine(Begin(0.1f));

    }

    private void FixedUpdate()
    {
        
        if (!_camTrigger.inTigger)
        {
            upgradePopup.SetActive(false);
        }

        lobbyLightsButton.color = _upgrades.money >= 50 ? Color.green : Color.red;
        floor2Button.color = _upgrades.money >= 50 ? Color.green : Color.red;
        floor3Button.color = _upgrades.money >= 200 ? Color.green : Color.red;
        yourfloorButton.color = _upgrades.money >= 700 ? Color.green : Color.red;
        projectileSize1.color = _upgrades.money >= 150 ? Color.green : Color.red;
        projectileRefill.color = _upgrades.money >= 20 ? Color.green : Color.red;
        playerlightupgradeButton.color = _upgrades.money >= 200 ? Color.green : Color.red;
        
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
    public void YourFloor()
    {
        if (_upgrades.money >= 700 && !_upgrades.yourFloorUnlocked)
        {
            _upgrades.money -= 700;
            boughtAudioSource.Play();
            _upgrades.yourFloorUnlocked = true;
        }
        else
        {
            errorAudioSource.Play();
        }
    }
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
    private IEnumerator Begin(float time)
    {
        
        yield return new WaitForSeconds(time);
        _upgrades = FindObjectOfType<Upgrades>();
        _player = FindObjectOfType<TopDownCharacterController>();


    }   
  
}
