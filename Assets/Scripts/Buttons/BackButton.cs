using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour, IService
{
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            ServiceLocator.Current.Get<EventBus>()?.buttonClicked.Invoke(EObjectToActiveName.Menu);
        });
    }
}
