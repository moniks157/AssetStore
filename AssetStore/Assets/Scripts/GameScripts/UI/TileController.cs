using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileController : MonoBehaviour {

    public TileObject tile;

    public Image Image;
    public string Name;
    public string Description;

    private void Start()
    {
        Image = GetComponent<Image>();
        Image.sprite = tile.Image ?? null;
        Name = tile.Name ?? "";
        Description = tile.Description ?? "";
    }
}
