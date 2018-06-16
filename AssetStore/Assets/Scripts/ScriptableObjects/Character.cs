using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(menuName = "Gameplay/Character")]
public class Character : TileObject
{
    public Skill PrimarySkill
    {
        get
        {
            var max = skillsPart2.Max();
            return skillsPart1[skillsPart2.IndexOf(max)];
        }
    }

    public int SkillValueSum
    {
        get
        {
            return skillsPart2.Sum();
        }
    }

    public List<Skill> skillsPart1;
    public List<int> skillsPart2;

    public int hpPoints;
    public int actualHpPoints;
         

    public List<Item> ItemsList;

    public bool HasEquiped(Item item)
    {
        return ItemsList.Contains(item);
    }
}
