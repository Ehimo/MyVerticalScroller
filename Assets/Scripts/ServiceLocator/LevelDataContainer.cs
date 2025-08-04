public class LevelDataContainer : IService
{
    static int levelTime = 0;

    public int LevelTime { get => levelTime; }

    public void SetLevelTime(int _levelTime)
    {
        levelTime = _levelTime;
    }
}
