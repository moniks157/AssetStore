using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


[CreateAssetMenu(menuName = "Gameplay/Character")]
public class Character : TileObject
{
    public Skill PrimarySkill
    {
        get
        {
            var maxValue = skillsPart2.Max();
            return skillsPart1[skillsPart2.IndexOf(maxValue)];
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

    public string Description;

    public new string GetDescription()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(name);
        stringBuilder.AppendLine(Description);
        for (int i = 0; i < skillsPart1.Count; i++)
        {
            if (skillsPart2[i] > 0)
            {
                stringBuilder.AppendLine(skillsPart1[i].name + ": +" + skillsPart2[i]);
            }
            else
            {
                stringBuilder.AppendLine(skillsPart1[i].name + ": " + skillsPart2[i]);
            }
        }

        return stringBuilder.ToString();
    }
}
