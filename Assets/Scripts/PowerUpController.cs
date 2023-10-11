using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] private PowerUpList list;
    [SerializeField] private Carta[] cards;
    private PowerUps[] current;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            current = list.RandomPowerUps(cards.Length);

            for (int i = 0; i < current.Length; i++)
                cards[i].SetValues(current[i]);
        }
    }
    public void PowerUpCallback(Carta card)
    {
        Stats stat = card.powerUp as Stats;
        if (stat != null)
        {
            print("apply power to player");
            return;
        }
        Item item = card.powerUp as Item;
        if (item != null)
        {
            print("change player item");
            return;
        }
    }
}
