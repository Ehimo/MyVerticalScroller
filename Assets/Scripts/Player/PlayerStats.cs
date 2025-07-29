using System.Threading.Tasks;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] int shieldTimer = 20;

    [SerializeField] Transform shieldObject;
    bool playerHasShield = false;
    public bool PlayerHasShield() => playerHasShield;
    public async Task ActiveShield()
    {
        playerHasShield = true;
        Debug.Log("Эффект щита начался");
        shieldObject.gameObject.SetActive(true);
        
        await Task.Delay(shieldTimer * 1000);
        
        shieldObject.gameObject.SetActive(false);
        Debug.Log("Эффект щита закончился");
        playerHasShield = false;
    }


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

    void Start()
    {
        playerHealth = maxPlayerHealth;
        EventBus.Get.addThisCoinAndSave += (int addMoney) => 
        {
            Money += addMoney;
            // Сохранение монет.
        };
    }
}
