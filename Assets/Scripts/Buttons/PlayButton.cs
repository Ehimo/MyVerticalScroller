using System;

public class PlayButton : BasicButton
{
    protected override void OnClickThisButton()
    {
        Action<EObjectToActiveName> action = ServiceLocator.Current.Get<EventBus>().buttonClicked;
        
        if (ServiceLocator.Current.Get<PlayerStats>().ShipStat != null)
        {
            action?.Invoke(EObjectToActiveName.SelectLevels);
        }
        else
        {
            action?.Invoke(EObjectToActiveName.SelectShips);
        }
    }
}
