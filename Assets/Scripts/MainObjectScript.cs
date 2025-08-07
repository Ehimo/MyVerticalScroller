using UnityEngine;

public class MainObjectScript : MonoBehaviour, IService
{
    [SerializeField] GameObject mainObject;

    public GameObject MainObject { get => mainObject; }

}
