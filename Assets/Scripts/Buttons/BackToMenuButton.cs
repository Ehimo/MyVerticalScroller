using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMenuButton : MonoBehaviour
{
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(BackToMenu);
    }

    void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
