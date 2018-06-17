using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


[CreateAssetMenu(menuName = "Gameplay/Character")]
public class Character : TileObject
{
    public List<Skill> skillsPart1;
    public List<int> skillsPart2;

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

    public int hpPoints = 20;
    public int actualHpPoints;

    public int ItemsMaxCount = 4;

    public List<Item> Items;

    public bool HasEquiped(Item item)
    {
        return Items.Contains(item);
    }

    public bool HasPlace()
    {
        return !(Items.Count == ItemsMaxCount);
    }

    public void RemoveItem(Item item)
    {
        Items.Remove(item);
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    public override string GetDescription()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(Description);
        for (int i = 0; i < skillsPart1.Count; i++)
        {
            if (skillsPart2[i] > 0)
            {
                stringBuilder.AppendLine(skillsPart1[i].Name + ": +" + skillsPart2[i]);
            }
            else if (skillsPart2[i] < 0)
            {
                stringBuilder.AppendLine(skillsPart1[i].Name + ": " + skillsPart2[i]);
            }
        }

        return stringBuilder.ToString();
    }
}
