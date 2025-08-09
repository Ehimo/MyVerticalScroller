using UnityEngine;

public class PlayerMovementController : MonoBehaviour, IService
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    ShipStats shipStats;

    public void Init()
    {
        shipStats = ServiceLocator.Current.Get<PlayerStats>().ShipStat;        
    }

    void Update()
    {
        var playerInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = Vector2.right * playerInput * shipStats.ShipMoveSpeed * Time.fixedDeltaTime;
    }

}
