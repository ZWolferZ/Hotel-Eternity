using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogofWar : MonoBehaviour
{
    bool inHouse;
    public SpriteRenderer sprite;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            inHouse = true;
        }
    }

    private void Update()
    {
        if (inHouse)
        {
            Color color = sprite.color;

            color.a -= 1f * Time.deltaTime;

            sprite.color = color;
        }
    }
}
