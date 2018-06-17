using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItemsController : MonoBehaviour {

    List<Item> Items;
    public List<GameObject> Children;

    public CharacterEvent ShowCharacter;
    
    private void OnEnable()
    {
        ShowCharacter.AddListener(SetData);
    }

    private void OnDisable()
    {
        ShowCharacter.RemoveListener(SetData);
    }

    private void Start()
    {
        ClearData();
    }

    public void SetData(Character character) 
    {
        ClearData();

        Items = character.Items;
        
        for (int i = 0; i < Items.Count; i++)
        {
            Children[i].GetComponentInChildren<TileController>().tile = Items[i];
            Children[i].GetComponentInChildren<TileController>().SetData();
        }
    }

    public void ClearData()
    {
        foreach(var v in Children)
        {
            var comp = v.GetComponentInChildren<TileController>();
            if (comp != null)
            {
                Debug.Log("not null");
                comp.ClearData();
            }
        }
    }
}
