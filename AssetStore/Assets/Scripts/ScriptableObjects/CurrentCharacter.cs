using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/CurrentCharacter")]
public class CurrentCharacter : ScriptableObject
{
    public Character character;

}