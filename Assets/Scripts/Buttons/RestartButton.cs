public class RestartButton : BasicButton
{
    protected override void OnClickThisButton()
    {
        ServiceLocator.Current.Get<Game>().RestartGame();
    }
}
