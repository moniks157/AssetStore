using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Item")]
public class Item : ScriptableObject
{

    [SerializeField]
    private string itemName;

    [SerializeField]
    private List<Skill> modifierListPart1;

    [SerializeField]
    private List<int> modifierListPart2;


    public void OnEquip(Character character)
    {
        
    }


    public void OnDequip(Character character)
    {
        
    }

}
