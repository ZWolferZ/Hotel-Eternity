using UnityEngine;


public class FogofWar : MonoBehaviour
{
    // Initialising variables
    private bool _inSquare;
    public SpriteRenderer sprite;
   

// On trigger, set bool
private void OnTriggerStay2D(Collider2D collision)
{
    if (!collision.CompareTag("Player")) return;
    _inSquare = true;
}

// Remove fog, gradually
    private void Update()
    {
        if (!_inSquare) return;
        {
            var color = sprite.color;

            color.a -= 1f * Time.deltaTime;

            sprite.color = color;
        }
    }
}
