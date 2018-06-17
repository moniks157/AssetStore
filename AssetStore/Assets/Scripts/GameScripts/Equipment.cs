using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName ="Gameplay/Equipment")]
public class Equipment : MonoBehaviour
{
    public CharacterEvent ShowCharacter;
    public ItemCharacterEvent EquipEvent;
    public StringEvent ShowError;

    LoadDataController data;

    private void Start()
    {
        data = FindObjectOfType<LoadDataController>();
    }

    private void Awake()
    {
        EquipEvent.AddListener(EquipItem);
    }

    private void OnDisable()
    {
        EquipEvent.RemoveListener(EquipItem);
    }

    private void EquipItem(Item item, Character character)
    {
        Debug.Log("EQUIP!");
        if (!character.HasEquiped(item))
        {
            Debug.Log("Nie ma itemu");
            if (character.HasPlace())
            {
                Debug.Log("Ma miejsce - wyposażam");
                item.OnEquip(character);
                character.AddItem(item);
                data.EquipItem(item);
            }
            else
            {
                ShowErrorPanel("Brak miejsca!");
            }
            
        }
        else
        {
            Debug.Log("Ma - odposażam");
            item.OnDequip(character);
            character.RemoveItem(item);
            data.DequipItem(item);
        }
        ShowCharacter.Invoke(character);
        
    }

    public void ShowErrorPanel(String message)
    {
        ShowError.Invoke(message);
    }
}