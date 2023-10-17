using UnityEngine;

[CreateAssetMenu(fileName = "list", menuName = "PowerUps/List", order = 0)]
public class PowerUpList : ScriptableObject
{
    [SerializeField] private PowerUps[] list;


    public PowerUps[] RandomPowerUps(int lenght)
    {
        return new PowerUps[] { list[0], list[1], list[2] };
    }
}
