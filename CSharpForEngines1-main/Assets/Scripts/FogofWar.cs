
using UnityEngine;

public class FogofWar : MonoBehaviour
{
    private bool _inSquare;
    public SpriteRenderer sprite;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _inSquare = true;
        }
    }

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
