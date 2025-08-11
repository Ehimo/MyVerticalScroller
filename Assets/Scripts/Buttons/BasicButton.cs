using UnityEngine;
using UnityEngine.UI;

public abstract class BasicButton : MonoBehaviour
{
    void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClickThisButton);
    }

    protected abstract void OnClickThisButton();

}
