using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] private PowerUpList list;
    [SerializeField] private Carta[] cards;
    private PowerUps[] current;

    [SerializeField] private GameObject[] cetros;
    [SerializeField] private GameController gameController;

    [SerializeField] private EnemySpawner panel;


    public void PowerUps()
    {
        print("Activado");
        current = list.RandomPowerUps(cards.Length);

        for (int i = 0; i < current.Length; i++)
            cards[i].SetValues(current[i]);
    }
    public void PowerUpCallback(Carta card)
    {
        Stats stat = card.powerUp as Stats;
        if (stat != null)
        {
            switch (stat.stat)
            {
                case Stat.speed:
                    gameController.PotenciadorVelocidad(); break;
                case Stat.health:
                    gameController.PotenciadorVida(); break;
                case Stat.strengh:
                    gameController.PotenciadorDaño(); break;
                case Stat.lessCooldown:
                    gameController.MenorTiempoDeRecarga(); break;
            }
            return;
        }
        Item item = card.powerUp as Item;
        if (item != null)
        {
            for (int i = 0; i < cetros.Length; i++)
            {
                Time.timeScale = 1f;
                panel.panelToActivate.SetActive(false);
                cetros[i].SetActive(i == item.index);
            }
            return;
        }
    }
}
