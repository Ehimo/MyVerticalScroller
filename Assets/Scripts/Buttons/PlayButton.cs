using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour, ILoadLevel
{
    [SerializeField] LevelData levelData;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            ServiceLocator.Current.Get<Game>().SetLoadLovel(this);

            SceneManager.LoadScene(1);
        });
    }

    public virtual void LoadLevel()
    {
        ServiceLocator.Current.Get<LevelDataContainer>().SetLevelTime(levelData.LevelTime);

        Debug.Log($"{ServiceLocator.Current.Get<LevelDataContainer>().LevelTime} == LevelTime");

    }
}
