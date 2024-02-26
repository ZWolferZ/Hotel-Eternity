
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;


public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private GameObject upgradePopup;
    private CamTrigger _camTrigger;
    private Upgrades _upgrades;
    public Image lobbyLightsButton;
    [SerializeField] private AudioSource errorAudioSource;
    [SerializeField] private AudioSource boughtAudioSource;

    
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

        lobbyLightsButton.color = _upgrades.money >= 30 ? Color.green : Color.red;

        if (_upgrades.lobbyLights)
        {
            lobbyLightsButton.color = Color.yellow;
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
        if (_upgrades.money >= 30 && !_upgrades.lobbyLights)
        {
            _upgrades.money -= 30;
            boughtAudioSource.Play();
            _upgrades.lobbyLights = true;
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
        

    }   
  
}
