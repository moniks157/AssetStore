using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileStoreDetailController : MonoBehaviour, IPointerClickHandler
{
    public TitleStoreEvent ShowTileStore;
    public TileEvent buyTile;

    public TileObject tileObject;

    public Text ObjectName;
    public Text Price;
    public Text PricePrefix;
    public Text Description;
    public Image Image;

    private void Awake()
    {
        ShowTileStore.AddListener(ShowDetails);

        DisactiveItems();

    }

    public void DisactiveItems()
    {
        ObjectName.gameObject.SetActive(false);
        Price.gameObject.SetActive(false);
        PricePrefix.gameObject.SetActive(false);
        Description.gameObject.SetActive(false);
        Image.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        ShowTileStore.RemoveListener(ShowDetails);
    }

    public void ShowDetails(TitleStore tile)
    {
        tileObject = tile.tile;

        ObjectName.text = tile.ObjectName.text.ToString();
        Price.text = tile.Price.text;
       
        Description.text = tile.Description;
        Image.sprite = tile.Image.sprite;


        ObjectName.gameObject.SetActive(true);
        Price.gameObject.SetActive(true);
        PricePrefix.gameObject.SetActive(true);
        Description.gameObject.SetActive(true);
        Image.gameObject.SetActive(true);

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            buyTile.Invoke(tileObject);
            DisactiveItems();
        }
    }
}
