using TMPro;
using UnityEngine;

public class GameData : MonoBehaviour, IService
{
    [SerializeField] TextMeshProUGUI moneyText;

    [SerializeField] int playerCoinColleted = 0;
    // int playerScoreCollected = 0;


    public void Init()
    {
        var eventBus = ServiceLocator.Current.Get<EventBus>();
        eventBus.inGameCoinCollected += (int val) => 
        {
            playerCoinColleted += val; 
            moneyText.text = $"{playerCoinColleted}";
        };
        
        eventBus.playedDied += () =>
        {
            eventBus.addThisCoinAndSave?.Invoke(playerCoinColleted);
            // —охранить полученные очки за пройденый уровень
        };
    }

}
