using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "list", menuName = "PowerUps/List", order = 0)]
public class PowerUpList : ScriptableObject
{
    [SerializeField] private PowerUps[] list;


    public PowerUps[] RandomPowerUps(int lenght)
    {
        if (list.Length == 0 || lenght <= 0)
        {
            return new PowerUps[0];
        }
        if (lenght >= list.Length )
        {
            return (PowerUps[])list.Clone();
        }
        List<PowerUps> randomPowerUps = new List<PowerUps>();
        List<int> selectedIndices = new List<int>();
        System.Random random = new System.Random();

        while (randomPowerUps.Count < lenght)
        {
            int randomInex = random.Next(0, list.Length);
            if (!selectedIndices.Contains(randomInex))
            {
                randomPowerUps.Add(list[randomInex]);
                selectedIndices.Add(randomInex);
            }
        }
        //for (int i = 0; i < lenght; i++)
        //{
        //    int randomIndex = random.Next(0, list.Length);
        //    randomPowerUps.Add(list[randomIndex]);
        //}
        return randomPowerUps.ToArray();
        //return new PowerUps[] { list[0], list[1], list[2] };//random
    }
}
