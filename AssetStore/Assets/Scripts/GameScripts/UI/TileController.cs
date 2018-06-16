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

    TileDetailsController tileDetails;

    public CurrentCharacter currentCharacter;
    
    private void Start()
    {
        Image = GetComponent<Image>();
        Image.sprite = tile.Image ?? null;
        Name = tile.Name ?? "";
        Description = tile.Description ?? "";

        tileDetails = GetComponentInChildren<TileDetailsController>();
        transform.GetChild(0).gameObject.SetActive(false);
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
            if (tile is Item) {
                Debug.Log("Item clicked");
                
                var item = tile as Item;
                EquipItem.Invoke(item, currentCharacter.character); 
            }                    
        }
    }

    //Pokazanie stałego dymku z nazwą i opisem
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("PointerEnter");
        tileDetails.ShowPanel(tile);
    }

    //Zniknięcie dymku
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("PointerExit");
        tileDetails.ShowPanel(tile);
    }
}
