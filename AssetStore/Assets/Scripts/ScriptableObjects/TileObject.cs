using UnityEngine;

public abstract class TileObject : ScriptableObject
{
    public Sprite Image;

    public string Name; 

    public string Description;

    public virtual string GetDescription()
    {
        return "";
    }
}