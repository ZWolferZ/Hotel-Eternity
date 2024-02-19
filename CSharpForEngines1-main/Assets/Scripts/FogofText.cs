using UnityEngine;


public class FogofText : MonoBehaviour
{
    private bool _inSquare;
    public SpriteRenderer sprite;
    public Animator animator;
    public string triggerName;
    public string triggerName2;


private void OnTriggerStay2D(Collider2D collision)
{
    if (!collision.CompareTag("Player")) return;
    _inSquare = true;
    animator.SetTrigger(triggerName);
    animator.SetTrigger(triggerName2);
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
