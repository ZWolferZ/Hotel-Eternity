using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;



public class FogofLight : MonoBehaviour
{
    // Initialising variables
    private bool _inSquare;
    public bool hotelLight;
    public Light2D light2D;
    private double _tolerance;
    private Upgrades _upgrades;

    // Start Finder coroutine 
    private void Awake()
    {
        StartCoroutine(Begin(0.1f));
    }
    
    

    // On trigger, activate bool
    private void OnTriggerStay2D(Collider2D collision)
{
    if (!collision.CompareTag("Player")) return;
    _inSquare = true;
}

    // Check bool 
    private void FixedUpdate()
    {
        hotelLight = _upgrades.lobbyLights;
    }

    private void Update()
    {
        
        // Turn on the hotel lights, gradually
        if (_inSquare != true || hotelLight != true) return;
        var intensity = light2D.intensity;
         
        intensity += 0.1f * Time.deltaTime;
         
        light2D.intensity = intensity;   
                     
        if (!(intensity >= 0.7f)) return;
        intensity = 0.7f;
        light2D.intensity = intensity;







    }
    
    //Find script after time
    private IEnumerator Begin(float time)
    {
        
        yield return new WaitForSeconds(time);
        _upgrades = FindObjectOfType<Upgrades>();
        

    }  
 }
