using UnityEngine;

[CreateAssetMenu(fileName = "New LevelData", menuName = "Create LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] int levelTime = 0;
    public int LevelTime { get => levelTime; }

}