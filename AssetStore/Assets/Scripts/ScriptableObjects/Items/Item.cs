using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Item")]
public class Item : TileObject
{
    [SerializeField]
    private List<Skill> modifierListPart1;

    [SerializeField]
    private List<int> modifierListPart2;

    private bool IsEquiped = false;

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

    public override string GetDescription()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(Description);
        for (int i = 0; i < modifierListPart1.Count; i++)
        {
            if (modifierListPart2[i] > 0)
            {
                stringBuilder.AppendLine(modifierListPart1[i].Name + ": +" + modifierListPart2[i]);
            }
            else
            {
                stringBuilder.AppendLine(modifierListPart1[i].Name + ": " + modifierListPart2[i]);
            }
        }

        return stringBuilder.ToString();
    }

}