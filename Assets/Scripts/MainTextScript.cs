using TMPro;
using UnityEngine;

public class MainTextScript : MonoBehaviour, IService
{
    [SerializeField] TextMeshProUGUI mainText;

    string basicText;

    public TextMeshProUGUI MainText { get => mainText; }

    void Start()
    {
        basicText = mainText.text;

        ServiceLocator.Current.Get<EventBus>().backButtonClicked += () => { mainText.text = basicText; };
    }

    
}
