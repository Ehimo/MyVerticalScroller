using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ShipCheckerScript : MonoBehaviour
{
    [SerializeField] MenuButton selectShipButton;

    [SerializeField] GameObject selectLevels;

    void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(IsPlayerSelectShip);
    }

    public async void IsPlayerSelectShip()
    {
        if(ServiceLocator.Current.Get<PlayerStats>().ShipStat == null)
        {
            selectShipButton.OnThisButtonClick();

            await Task.Delay(1);

            selectLevels.SetActive(false);
        }
    }
}
