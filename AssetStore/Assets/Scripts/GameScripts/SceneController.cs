using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public void ToShop()
    {
        SceneManager.LoadScene(2);
    }

    public void ToMainView()
    {
        SceneManager.LoadScene(1);
    }
}
