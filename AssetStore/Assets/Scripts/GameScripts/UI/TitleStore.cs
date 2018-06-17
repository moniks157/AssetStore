using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleStore : MonoBehaviour, IPointerClickHandler {

    public TitleStoreEvent showTile;

    public TileObject tile;

	public Text ObjectName;
    public Text Price;
    public Image Image;
    public string Description;

   
    public void OnPointerClick(PointerEventData eventData)
    {
        showTile.Invoke(this);
    }
}
