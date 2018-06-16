using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Skill")]
public class Skill : TileObject {
    

    public Sprite skillSprite;
    
    public Skill strongFor;

    public Skill weekFor;

    public override string GetDescription()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(Description);
        stringBuilder.AppendLine("Strong for: " + strongFor.Name);
        stringBuilder.AppendLine("Week for: " + weekFor.Name);

        return stringBuilder.ToString();
    }

}
