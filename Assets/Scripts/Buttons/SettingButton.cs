public class SettingButton : BasicButton
{
    protected override void OnClickThisButton()
    {
        ServiceLocator.Current.Get<EventBus>()?.buttonClicked.Invoke(EObjectToActiveName.Settings);
    }
}
