using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsUIController : MonoBehaviour {

    Character currentCharacter;
    CharacterEvent showItemsPanel;

    public List<TileController> tiles;

    private void Awake()
    {
        showItemsPanel.AddListener(ShowItemsPanel);
    }

    private void ShowItemsPanel(Character character)
    {
        currentCharacter = character;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        showItemsPanel.RemoveListener(ShowItemsPanel);
    }

}
