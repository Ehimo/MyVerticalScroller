using UnityEngine;

public class PlayerStats : MonoBehaviour, IService
{
    public ShipStats ShipStat => shipStats;

    static ShipStats shipStats;
    public void SetShipStats(ShipStats _shipStats)
    {
        shipStats = _shipStats;
    }

    public void Init()
    {
        playerHealth = shipStats.ShipMaxHealth;

        ServiceLocator.Current.Get<EventBus>().addThisCoinAndSave += (int addMoney) =>
        {
            Money += addMoney;
            // ���������� �����.
        };
        
        ServiceLocator.Current.Get<EventBus>().activeShield += () => { playerHasShield = true; };
    }
    
    void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = shipStats.ShipSprite;

        ServiceLocator.Current.Get<EventBus>().disableShield += () => { playerHasShield = !playerHasShield; };
    }

    bool playerHasShield = false;
    public bool PlayerHasShield => playerHasShield;

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

    public void AddHealth(int health)
    {
        playerHealth += health;

        if (playerHealth > shipStats.ShipMaxHealth)
        {
            playerHealth = shipStats.ShipMaxHealth;
            // Event to change health UI.
        }
    }

    public void RemoveHealth(int damage)
    {
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            // Event to stop game.
            Debug.Log("����� ����");
            ServiceLocator.Current.Get<EventBus>()?.playedDied.Invoke();
        }
    }
}