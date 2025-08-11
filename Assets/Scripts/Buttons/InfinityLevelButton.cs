using UnityEngine.UI;

public class InfinityLevelButton : LoadLevelButton
{
    public override void LoadLevel()
    {
        FindFirstObjectByType<Slider>().gameObject.SetActive(false);
        ServiceLocator.Current.Get<Game>().SetIsLevelInfinity(true);
    }
}