using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Gameplay/Character")]
public class Character : ScriptableObject
{
    public string CharacterName;

    public Sprite characterImage;

    public List<Skill> skillsPart1;
    public List<int> skillsPart2;

    public int hpPoints;

    public string Description;
}
