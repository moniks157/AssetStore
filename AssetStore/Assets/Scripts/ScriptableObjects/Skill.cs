﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Skill")]
public class Skill : TileObject {

    public string SkillName;

    public Sprite skillSprite;
    
    public Skill strongFor;

    public Skill weekFor;

}
