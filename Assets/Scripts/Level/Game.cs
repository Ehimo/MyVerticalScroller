using UnityEngine;

public class Game : MonoBehaviour, IService
{

    static ILoadLevel loadLevel;

    public void SetLoadLovel(ILoadLevel _loadLevel)
    {
        loadLevel = _loadLevel;
    }


    public void Init()
    {
        if (loadLevel != null)
        {
            loadLevel.LoadLevel();
        }
        else
        {
            Debug.LogError("Load level is null");
        }
    }
}
