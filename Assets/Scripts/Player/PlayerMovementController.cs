using UnityEngine;

public class PlayerMovementController : NeedToStopWhenPlayerDies, IService 
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    ShipStats shipStats;

    public override void Stop()
    {
        rb.velocity = Vector3.zero;
        this.enabled = false;
    }

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
