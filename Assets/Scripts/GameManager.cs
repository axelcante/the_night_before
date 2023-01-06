using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SINGLETON DECLARATION

    private static GameManager instance;
    public static GameManager GetInstance () { return instance; }

    #endregion

    private void Awake ()
    {
        if (instance != null) {
            Debug.LogWarning("More than one instance of GameManager running");
        }

        instance = this;
    }
}
