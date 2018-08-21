using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    #region declaring variables
    public static GameManager instance = null;
    #endregion
    #region void Awake, setting the GameManager
    void Awake () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    // Update is called once per frame
    void Update () {
		
	}
}
