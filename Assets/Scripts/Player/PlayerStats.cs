using UnityEngine;

public class PlayerStats : MonoBehaviour, IService
{
    [SerializeField] int money = 0;
    public int Money
    {
        get => money;
        set
        {
            money = value;
        }
    }

    [SerializeField] int playerHealth = 0;
    [SerializeField] int maxPlayerHealth = 3;

    public void AddHealth(int health)
    {
        playerHealth += health;

        if (playerHealth > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
            // Event to change health UI.
        }
    }

    public void RemoveHealth(int damage)
    {
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            // Event to stop game.
            Debug.Log("Игрок умер");
            
        }
    }

    public void Init()
    {
        playerHealth = maxPlayerHealth;
        ServiceLocator.Current.Get<EventBus>().addThisCoinAndSave += (int addMoney) => 
        {
            Money += addMoney;
            // Сохранение монет.
        };
    }

    [SerializeField] int shieldTimer = 20;

    [SerializeField] Transform shieldObject;
    bool playerHasShield = false;
    public bool PlayerHasShield() => playerHasShield;

    void Start()
    {
        ServiceLocator.Current.Get<EventBus>().activeShield += () => { playerHasShield = true; };
    }
}
