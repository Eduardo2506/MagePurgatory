using UnityEngine;

public abstract class PowerUps : ScriptableObject
{
    public Sprite image;
    public string text;

    [TextArea(3, 10)]
    public string description;
}
