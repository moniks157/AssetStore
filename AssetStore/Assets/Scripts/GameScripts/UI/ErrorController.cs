using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorController : MonoBehaviour {

    StringEvent ShowError;
    public Text ErrorText;

    private void OnEnable()
    {
        ShowError.AddListener(ShowPanel);
    }

    private void OnDisable()
    {
        ShowError.RemoveListener(ShowPanel);
    }

    //Wypełnienie danymi bohatera
    public void ShowPanel(string message)
    {
        //Włączenie/ wyłączenie panelu
        gameObject.SetActive(!gameObject.activeSelf);
        ErrorText.text = message;
    }

    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
