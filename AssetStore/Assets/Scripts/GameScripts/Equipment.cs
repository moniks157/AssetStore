using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName ="Gameplay/Equipment")]
public class Equipment : ScriptableObject
{
    public ItemCharacterEvent EquipEvent;
    public StringEvent ShowError;

    //DataContainer - jak wyposaza to wywala z listy ekwipunkow ogolnej

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
        if (character.HasPlace())
        {
            if (!character.HasEquiped(item))
            {
                item.OnEquip(character);
            }
            else
            {
                item.OnDequip(character);
            }
        }
        else
        {
            ShowErrorPanel("Brak miejsca!");
        }
    }

    public void ShowErrorPanel(String message)
    {
        ShowError.Invoke(message);
    }
}