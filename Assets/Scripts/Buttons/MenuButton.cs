using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] GameObject objectToActive;
    [SerializeField] TextMeshProUGUI buttonText;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnThisButtonClick);

        ServiceLocator.Current.Get<EventBus>().backButtonClicked += OnBackButtonClicked;
    }

    public void OnThisButtonClick()
    {
        var locator = ServiceLocator.Current;
        locator.Get<MainObjectScript>().MainObject.SetActive(false);

        locator.Get<MainTextScript>().MainText.text = buttonText.text;

        objectToActive.SetActive(true);

        locator.Get<EventBus>().menuButtonClicked?.Invoke();
    }

    void OnBackButtonClicked()
    {
        objectToActive.SetActive(false);
    }
}
