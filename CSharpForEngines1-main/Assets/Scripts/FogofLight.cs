using UnityEngine;
using UnityEngine.Rendering.Universal;



public class FogofLight : MonoBehaviour
{
    private bool _inSquare;
    public bool hotelLight;
    public Light2D light2D;
    private double _tolerance;


private void OnTriggerStay2D(Collider2D collision)
{
    if (!collision.CompareTag("Player")) return;
    _inSquare = true;
}

    private void Update()
    {
        if (_inSquare != true || hotelLight != true) return;
        var intensity = light2D.intensity;
         
        intensity += 0.1f * Time.deltaTime;
         
        light2D.intensity = intensity;   
                     
        if (!(intensity >= 0.7f)) return;
        intensity = 0.7f;
        light2D.intensity = intensity;







    }
 }
