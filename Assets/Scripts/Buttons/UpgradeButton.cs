public class UpgradeButton : BasicButton
{
    protected override void OnClickThisButton()
    {
        ServiceLocator.Current.Get<EventBus>()?.buttonClicked.Invoke(EObjectToActiveName.Upgrades);
    }
}
