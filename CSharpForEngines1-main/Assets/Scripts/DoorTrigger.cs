
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject door;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            door.SetActive(true);
        }
    }
}
