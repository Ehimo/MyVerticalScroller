using UnityEngine;

public class SelectShipButton : BasicButton
{
    [SerializeField] ShipStats shipStats;

    protected override void OnClickThisButton()
    {
        var playerStats = ServiceLocator.Current.Get<PlayerStats>();
        playerStats.SetShipStats(shipStats);
    }
}
