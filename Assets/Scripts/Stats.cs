using UnityEngine;

public enum Stat
{
    health,
    speed,
    strengh
}

[CreateAssetMenu(fileName = "stat", menuName = "PowerUps/Stat")]
public class Stats: PowerUps
{
    public Stat stat;
}
