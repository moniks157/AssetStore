using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDetailsController : MonoBehaviour {

    public CharacterEvent ShowCharacter;

    public Image tile;
    public Text NameText;
    public Text DescText;
    public GameObject tileImage;

    private void OnEnable()
    {
        ShowCharacter.AddListener(FillData);
    }

    private void OnDisable()
    {
        ShowCharacter.RemoveListener(FillData);
    }
    

    //Wypełnienie danymi bohatera
    public void FillData(Character character)
    {
        tile.sprite = character.Image;
        NameText.text = character.Name;
        DescText.text = character.GetDescription();
        tileImage.SetActive(true);
    }
}
