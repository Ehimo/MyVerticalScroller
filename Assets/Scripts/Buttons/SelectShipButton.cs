using UnityEngine;
using UnityEngine.UI;

public class SelectShipButton : MonoBehaviour
{
    [SerializeField] ShipStats shipStats;

    [SerializeField] MenuButton selectLevelButton;
    [SerializeField] GameObject selectShipObject;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SelectShip);
    }

    void SelectShip()
    {
        var playerStats = ServiceLocator.Current.Get<PlayerStats>();
        playerStats.SetShipStats(shipStats);
        
        selectShipObject.SetActive(false);
        selectLevelButton.OnThisButtonClick();
    }
}
