public class OpenSelectShipMenuButton : BasicButton
{
    protected override void OnClickThisButton()
    {
        ServiceLocator.Current.Get<EventBus>()?.buttonClicked.Invoke(EObjectToActiveName.SelectShips);
    }
}
