using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Destroy on camera leave

public class DestroyOnLeavingCamera : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        // When the bullet leaves the camaera, destroy it
        Destroy(gameObject);
    }
}

#endregion