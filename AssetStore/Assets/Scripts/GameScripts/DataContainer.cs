using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataContainer : MonoBehaviour {

    public List<Skill> allSkills;
    public List<Character> notBoughtCharacters;
    public List<Character> boughtCharacters;
    public List<Item> notBoughtItems;
    public List<Item> boughtItems;
    public List<Item> equipedItems;
    public List<Item> notEquipedItems;
    public List<Character> deadHeroes;

    public int Coins;
    
    public TextAsset nameFile;
    public int money;
    
}
