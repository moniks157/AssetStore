using UnityEngine;

public class TileObject : ScriptableObject
{
    public Sprite Image;

    public string Name;

    public string Description;

    public string GetDescription()
    {
        return "no description";
    }
}