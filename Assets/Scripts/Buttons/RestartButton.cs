using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Restart);
    }

    void Restart()
    {
        ServiceLocator.Current.Get<Game>().RestartGame();
    }
}
