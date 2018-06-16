using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileDetailsController : MonoBehaviour {
    
    private string NamePrefix = "Name: ";
    private string DescPrefix = "Description: ";

    public Text NameText;
    public Text DescText;
    
    public void ShowPanel(TileObject tile)
    {
        //Włączenie/ wyłączenie panelu
        gameObject.SetActive(!gameObject.activeSelf);
        //Wypełnienie danych na texty
        NameText.text = NamePrefix + tile.Name;
        DescText.text = DescPrefix + tile.GetDescription();
    }
}
