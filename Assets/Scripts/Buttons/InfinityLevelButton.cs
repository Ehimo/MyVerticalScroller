using UnityEngine.UI;

public class InfinityLevelButton : PlayButton
{
    public override void LoadLevel()
    {
        FindFirstObjectByType<Slider>().gameObject.SetActive(false);
        ServiceLocator.Current.Get<Game>().SetIsLevelInfinity(true);
    }
}