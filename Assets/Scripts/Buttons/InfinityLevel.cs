using UnityEngine.UI;

public class InfinityLevel : PlayButton
{
    public override void LoadLevel()
    {
        FindFirstObjectByType<Slider>().gameObject.SetActive(false);
    }
}