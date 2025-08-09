using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour, IService
{
    [SerializeField] Transform endUI;
    [SerializeField] TextMeshProUGUI endText;

    [SerializeField] string playerDeadText = "You Dead!";
    [SerializeField] string playerCompleteLevel = "You Win!";

    static ILoadLevel loadLevel;

    public void SetLoadLovel(ILoadLevel _loadLevel)
    {
        loadLevel = _loadLevel;
    }


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
            endUI.gameObject.SetActive(true);
            endText.text = playerDeadText;
        };

        bus.playerCompleteLevel += () => 
        {
            endUI.gameObject.SetActive(true);
            endText.text = playerCompleteLevel;
        };
    }
}
