using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataController : MonoBehaviour {

    public GameObject HerosPanel;
    public GameObject ItemsPanel;

    public GameObject tilePrefab;
    DataContainer data;

    private void Start()
    {
        data = FindObjectOfType<DataContainer>();
        Debug.Log("Heros");
        LoadHeros();
        Debug.Log("Items");
        LoadItems();
    }

    public void LoadHeros()
    {
        RemoveHeros();

        var Heros = data.boughtCharacters;

        foreach(var h in Heros)
        {
            h.Items.Clear();
            var hero = Instantiate(tilePrefab, HerosPanel.transform);
            hero.GetComponentInChildren<TileController>().tile = h;
        }
    }

    public void LoadItems()
    {
        RemoveItems();
        RemoveHeros();

        var Items = data.notEquipedItems;
        var Heros = data.boughtCharacters;

        foreach(var h in Heros)
        {
            var hero = Instantiate(tilePrefab, HerosPanel.transform);
            hero.GetComponentInChildren<TileController>().tile = h;
            //hero.GetComponent<TileController>().SetData();
        }
        
        foreach (var h in Items)
        {
            var item = Instantiate(tilePrefab, ItemsPanel.transform);
            item.GetComponentInChildren<TileController>().tile = h;
        }
    }

    public void RemoveItems()
    {
        for (var i = ItemsPanel.transform.childCount - 1; i >= 0; i--)
        {
            var objectA = ItemsPanel.transform.GetChild(i);
            objectA.transform.parent = null;
            Destroy(objectA.gameObject);
        }
    }

    public void RemoveHeros()
    {
        for (var i = HerosPanel.transform.childCount - 1; i >= 0; i--)
        {
            var objectA = HerosPanel.transform.GetChild(i);
            objectA.transform.parent = null;
            Destroy(objectA.gameObject);
        }
    }

    public void EquipItem(Item item)
    {
        data.equipedItems.Add(item);
        data.notEquipedItems.Remove(item);
        LoadItems();
    }

    public void DequipItem(Item item)
    {
        data.equipedItems.Remove(item);
        data.notEquipedItems.Add(item);
        LoadItems();
    }

    public void BuyItem(Item item)
    {
        data.boughtItems.Add(item);
        data.notEquipedItems.Add(item);
        data.notBoughtItems.Remove(item);
        LoadItems();
    }

    public void BuyCharacter(Character character)
    {
        data.boughtCharacters.Add(character);
        data.notBoughtCharacters.Remove(character);
        LoadHeros();
    }

}
