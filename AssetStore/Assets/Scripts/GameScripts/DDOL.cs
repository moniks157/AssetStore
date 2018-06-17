using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour {

    private bool isInstantiated = false;

    private void Awake()
    {
        if(!isInstantiated)
            DontDestroyOnLoad(gameObject);

        SceneManager.LoadScene(1);
    }
}
