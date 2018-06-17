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

    public Sprite NoneImage;
    
    private void Start()
    {
        
        tileDetails = GetComponentInChildren<TileDetailsController>();
        transform.GetChild(0).gameObject.SetActive(false);

        SetData();
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

                tileDetails.ShowPanel(false);
            }
        }
       
    }

    //Pokazanie stałego dymku z nazwą i opisem
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (tile != null)
        {
            Debug.Log("PointerEnter");
            tileDetails.ShowPanel(tile);
        }
    }

    //Zniknięcie dymku
    public void OnPointerExit(PointerEventData eventData)
    {
        if (tile != null)
        {
            Debug.Log("PointerExit");
            tileDetails.ShowPanel(tile);
        }
    }

    public void SetData()
    {
        Image = GetComponent<Image>();
        Image.sprite = tile == null ? NoneImage : tile.Image;
        Name = tile == null ? "" : tile.Name;
        Description = tile.Description ?? "";
    }

    public void ClearData()
    {
        tile = null;
        Image.sprite = NoneImage;
    }
}
