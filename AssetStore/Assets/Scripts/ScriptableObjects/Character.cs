﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Gameplay/Character")]
public class Character : TileObject
{
    public List<Skill> skillsPart1;
    public List<int> skillsPart2;


    public string Description;
}
