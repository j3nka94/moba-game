using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UpdateTransform : NetworkBehaviour {

    #region Singleton
    public static UpdateTransform Instance { get; private set; }

    private void Awake()
    {
        if(Instance  == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public void UpdatePosition(GameObject player, Vector3 position)
    {

    }
}
