using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Gameplay/Character")]
public class Character : TileObject
{
    public List<Skill> skillsPart1;
    public List<int> skillsPart2;

    public int hpPoints;

    public List<Item> ItemsList;

    public bool HasEquiped(Item item)
    {
        return ItemsList.Contains(item);
    }
}
