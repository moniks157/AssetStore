using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreTailController : MonoBehaviour, IPointerClickHandler
{

    public TileObject tile;

    public CharacterEvent ShowCharacter;
    public ItemEvent ShowItem;

    public CurrentCharacter currentCharacter;

    public Image Image;
    public string Name;
    public string Description;//zmina na text?
    /*
     private void Start()
      {
          Image = GetComponent<Image>();
          Image.sprite = tile.Image ?? null;
          Name = tile.Name ?? "";
          Description = tile.Description ?? "";


      }*/
     
    public void init(TileObject tile2)
    {
        Image = GetComponent<Image>();
        Image.sprite = tile2.Image ?? null;
        Name = tile2.Name ?? "";
        Description = tile2.Description ?? "";
        tile = tile2;


    }
    //Wychwycenie podwójnego klika
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            Debug.Log("Tile clicked");
            //Podmianka aktywnego bohatera
            if (tile is Character)
            {
                Debug.Log("Character clicked");
                currentCharacter.character = tile as Character;
                ShowCharacter.Invoke(tile as Character);
            }
            if (tile is Item)
            {
                Debug.Log("Item clicked");

                var item = tile as Item;
                ShowItem.Invoke(item);
            }
        }
    }

}
