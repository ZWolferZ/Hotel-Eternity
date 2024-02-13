using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Dont Destroy on a load

public class DontDestory : MonoBehaviour
{
    // Mark the gameobject as not destroyable on a load
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
}

#endregion