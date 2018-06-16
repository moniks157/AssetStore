using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Gameplay/Character")]
public class Character : ScriptableObject
{


    public string characterName;
    public List<Skil> skils;
  //  public List<Item> items;
    public string description;
}
