using UnityEngine;

#region Dont Destroy on a load

public class DontDestroy : MonoBehaviour
{
    // Mark the game object as not destroyable on a load
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

#endregion