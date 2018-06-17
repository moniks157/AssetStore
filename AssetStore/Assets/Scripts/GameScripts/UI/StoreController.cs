using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class StoreController : MonoBehaviour {

    public Text Coins;

    public GameObject HerosPanel;
    public GameObject ItemsPanel;

    public GameObject tilePrefab;

    public List<Character> Heros = new List<Character>();
    public List<Item> Items = new List<Item>();
    
    DataContainer dataContainer;

    public TileEvent buyTile;
    public StringEvent throwError;
    // Use this for initialization
    private void Start()
    {
        
        dataContainer = FindObjectOfType<DataContainer>();
        
        if (dataContainer == null)
        {
            Debug.Log("null list");
        }
        else {

            SetData();
        }
    }

    private void Awake()
    {
        buyTile.AddListener(BuySomething);
    }

    private void OnDisable()
    {
        buyTile.RemoveListener(BuySomething);
    }

    public void SetData()
    {
        Items.Clear();
        Heros.Clear();

        Heros = dataContainer.notBoughtCharacters.Take(3).ToList();
        Items = dataContainer.notBoughtItems.Take(3).ToList();

        foreach (var h in Heros)
        {
            var hero = Instantiate(tilePrefab, HerosPanel.transform);
            hero.GetComponentInChildren<TitleStore>().tile = h;
            hero.GetComponentInChildren<TitleStore>().Image.sprite = h.Image;
            hero.GetComponentInChildren<TitleStore>().ObjectName.text = h.Name;
            hero.GetComponentInChildren<TitleStore>().Price.text = h.SkillValueSum.ToString();
            hero.GetComponentInChildren<TitleStore>().Description = h.GetDescription();
        }

        foreach (var h in Items)
        {
            var item = Instantiate(tilePrefab, ItemsPanel.transform);
            item.GetComponentInChildren<TitleStore>().tile = h;
            item.GetComponentInChildren<TitleStore>().Image.sprite = h.Image;
            item.GetComponentInChildren<TitleStore>().ObjectName.text = h.Name;
            item.GetComponentInChildren<TitleStore>().Price.text = h.ItemValueSum.ToString();
            item.GetComponentInChildren<TitleStore>().Description = h.GetDescription();
        }

        Coins.text = "Coins: " + dataContainer.Coins.ToString();
    }

    public void BuySomething(TileObject tile)
    {
        if (tile is Item)
            BuyItem(tile as Item);
        if (tile is Character)
            BuyCharacter(tile as Character);
    }

    public void BuyItem(Item item)
    {
        if (dataContainer.Coins >= item.ItemValueSum)
        {
            dataContainer.boughtItems.Add(item);
            dataContainer.notEquipedItems.Add(item);
            dataContainer.notBoughtItems.Remove(item);
            dataContainer.Coins -= item.ItemValueSum;
            Coins.text = "Coins: " + dataContainer.Coins.ToString();

            RemoveItems();
            RemoveHeros();

            SetData();
        }
        else
            throwError.Invoke("Niewystarczająca ilość pieniędzy!");
    }

    public void BuyCharacter(Character character)
    {
        if (dataContainer.Coins >= character.SkillValueSum)
        {
            dataContainer.boughtCharacters.Add(character);
            dataContainer.notBoughtCharacters.Remove(character);
            dataContainer.Coins -= character.SkillValueSum;
            Coins.text = "Coins: " + dataContainer.Coins.ToString();

            RemoveItems();
            RemoveHeros();


            SetData();
        }
        else
            throwError.Invoke("Niewystarczająca ilość pieniędzy!");
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

}
