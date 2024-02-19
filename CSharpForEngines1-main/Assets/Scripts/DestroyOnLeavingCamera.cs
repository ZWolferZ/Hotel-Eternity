using UnityEngine;

#region Destroy on camera leave

public class DestroyOnLeavingCamera : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        // When the bullet leaves the camera, destroy it
        Destroy(gameObject);
    }
}

#endregion