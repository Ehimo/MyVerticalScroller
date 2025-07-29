using UnityEngine;

public class LevelInGameData : MonoBehaviour
{
    int playerCoinColleted = 0;

    // int playerScoreCollected = 0;
    void Start()
    {
        EventBus.Get.inGameCoinCollected += (int val) => { playerCoinColleted += val; };
        EventBus.Get.onGameEnd += () => 
        {
            EventBus.Get.addThisCoinAndSave?.Invoke(playerCoinColleted); 
            // —охранить полученные очки за пройденый уровень
        };
    }

}
