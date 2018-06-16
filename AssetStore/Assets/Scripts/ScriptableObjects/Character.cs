using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Gameplay/Character")]
public class Character : ScriptableObject
{
    public string CharacterName;
    public List<Skill> Skils;
  //  public List<Item> items;
    public string Description;
}
