using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Item")]
public class Item : TileObject
{
    [SerializeField]
    private List<Skill> modifierListPart1;

    [SerializeField]
    private List<int> modifierListPart2;
    
    public void OnEquip(Character character)
    {
        for (int i = 0; i < modifierListPart1.Count; i++)
        {
            if (character.skillsPart1.Contains(modifierListPart1[i]))
            {
                character.skillsPart2[character.skillsPart1.IndexOf(modifierListPart1[i])] += modifierListPart2[i];
            }
            else
            {
                character.skillsPart1.Add(modifierListPart1[i]);
                character.skillsPart2.Add(modifierListPart2[i]);
            }
        }
    }
    
    public void OnDequip(Character character)
    {
        for (int i = 0; i < modifierListPart1.Count; i++)
        {
            character.skillsPart2[character.skillsPart1.IndexOf(modifierListPart1[i])] -= modifierListPart2[i];
        }
    }

}