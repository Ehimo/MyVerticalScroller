using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour, IService
{
    [SerializeField] Transform endUI;
    [SerializeField] TextMeshProUGUI endText;

    [SerializeField] string playerDeadText = "You Dead!";
    [SerializeField] string playerCompleteLevel = "You Win!";
    [SerializeField] List<NeedToStopWhenPlayerDies> objectToDiseable;

    static ILoadLevel loadLevel;

    public void SetLoadLovel(ILoadLevel _loadLevel)
    {
        loadLevel = _loadLevel;
    }

    /// <summary>
    /// Если level с ограничение по времени то нужно передать true а если без то false. 
    /// </summary>
    public void SetIsLevelInfinity(bool type)
    {
        levelIsInfinity = type;
    }
    static bool levelIsInfinity = false;

    public bool LevelIsInfinity => levelIsInfinity;
    public void Init()
    {
        if (loadLevel != null)
        {
            loadLevel.LoadLevel();
        }
        else
        {
            Debug.LogError("Load level is null");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    void Start()
    {
        var bus = ServiceLocator.Current.Get<EventBus>();
        bus.playedDied += () => 
        {

            bus?.stopAll.Invoke();
            endUI.gameObject.SetActive(true);
            endText.text = playerDeadText;
        };

        bus.playerCompleteLevel += () => 
        {
            bus?.stopAll.Invoke();

            endUI.gameObject.SetActive(true);
            endText.text = playerCompleteLevel;
        };

        bus.stopAll += () => 
        {
            foreach (var obj in objectToDiseable)
            {
                obj.Stop();
            }
        };

    }

}
