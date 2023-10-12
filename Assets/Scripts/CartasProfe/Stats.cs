using UnityEngine;

public enum Stat
{
    health,
    speed,
    strengh,
    lessCooldown
}

[CreateAssetMenu(fileName = "stat", menuName = "PowerUps/Stat")]
public class Stats: PowerUps
{
    public Stat stat;
}
