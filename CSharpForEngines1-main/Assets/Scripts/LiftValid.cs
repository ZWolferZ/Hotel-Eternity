using UnityEngine;
using UnityEngine.Serialization;

public class LiftValid : MonoBehaviour
{
    // Check to see if the lift ui can be switched back on
    
    [FormerlySerializedAs("_steppedOut")] public bool steppedOut;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            steppedOut = true;
        }
    }
}
                                            