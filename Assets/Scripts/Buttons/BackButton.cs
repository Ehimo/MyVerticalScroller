using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour, IService
{
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnBackButtonClick);
    }

    void OnBackButtonClick()
    {
        var locator = ServiceLocator.Current;

        locator.Get<EventBus>().backButtonClicked?.Invoke();
        gameObject.SetActive(false);

        locator.Get<MainObjectScript>().MainObject.SetActive(true);
        locator.Get<MainTextScript>().MainText.gameObject.SetActive(true);
    }
}
