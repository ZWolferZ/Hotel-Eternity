using UnityEngine;

public class LiftValid : MonoBehaviour
{
    public bool _steppedOut;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _steppedOut = true;
        }
    }
}
