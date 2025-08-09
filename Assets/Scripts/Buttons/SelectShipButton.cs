using UnityEngine;
using UnityEngine.UI;

public class SelectShipButton : MonoBehaviour
{
    [SerializeField] ShipStats shipStats;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SelectShip);
    }

    void SelectShip()
    {
        PlayerStats playerStats = new();
        playerStats.SetShipStats(shipStats);
    }
}
