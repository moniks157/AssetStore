using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDetailsControllerr : MonoBehaviour {

    CharacterEvent ShowCharacter;
    
    private void Awake()
    {
        ShowCharacter.AddListener(ShowPanel);
    }

    private void OnDisable()
    {
        ShowCharacter.RemoveListener(ShowPanel);
    }

    //Wypełnienie danymi bohatera
    public void ShowPanel(Character character)
    {
        //Włączenie/ wyłączenie panelu
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
