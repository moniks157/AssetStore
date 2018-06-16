using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Skill")]
public class Skill : TileObject {

    public string SkillName;

    public Sprite skillSprite;
    
    public Skill strongFor;

    public Skill weekFor;

    public new string GetDescription()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(name);
        stringBuilder.AppendLine(Description);
        stringBuilder.AppendLine("strong for: " + strongFor.name);
        stringBuilder.AppendLine("week for: " + weekFor.name);

        return stringBuilder.ToString();
    }

}
