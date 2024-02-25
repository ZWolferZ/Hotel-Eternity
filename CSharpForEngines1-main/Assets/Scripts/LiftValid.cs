using UnityEngine;
using UnityEngine.Serialization;

public class LiftValid : MonoBehaviour
{
    [FormerlySerializedAs("_steppedOut")] public bool steppedOut;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            steppedOut = true;
        }
    }
}
                                            