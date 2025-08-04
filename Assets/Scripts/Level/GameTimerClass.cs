using UnityEngine;
using UnityEngine.UI;

public class GameTimerClass : MonoBehaviour, IService
{
    [SerializeField] Slider timeSlider;

    int maxLevelTime = 25;
    [SerializeField] float timer = 0;

    public void Init()
    {
        maxLevelTime = ServiceLocator.Current.Get<LevelDataContainer>().LevelTime;
    }

    void Start()
    {
        timer = maxLevelTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        timeSlider.value = timer / maxLevelTime;
    
        if(timeSlider.value == 0)
        {
            Debug.Log("Win");
        }
    }
}
