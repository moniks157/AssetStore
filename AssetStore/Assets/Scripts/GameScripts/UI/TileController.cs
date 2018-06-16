using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

    public TileObject tile;

    public Image Image;
    public string Name;
    public string Description;

    public CharacterEvent ShowCharacter;
    public ItemCharacterEvent EquipItem;
    public TileEvent ShowDetails;

    public Character currentCharacter;
    
    private void Start()
    {
        Image = GetComponent<Image>();
        Image.sprite = tile.Image ?? null;
        Name = tile.Name ?? "";
        Description = tile.Description ?? "";
    }

    //Wychwycenie podwójnego klika
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            //Podmianka aktywnego bohatera
            if (tile is Character)
            {
                currentCharacter = tile as Character;
                ShowCharacter.Invoke(tile as Character);
            }
            if (tile is Item)
            {//JESZCZE CZY MA MIEJSCE!!!
                var item = tile as Item;
                EquipItem.Invoke(item, currentCharacter);
                    
            }
                                
        }

    }

    //Pokazanie stałego dymku z nazwą i opisem
    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowDetails.Invoke(tile);
    }

    //Zniknięcie dymku
    public void OnPointerExit(PointerEventData eventData)
    {
        ShowDetails.Invoke(tile);
    }
}
