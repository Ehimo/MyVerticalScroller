using UnityEngine;

[CreateAssetMenu(fileName = "New ShipStats", menuName = "Create ShipStats")]
public class ShipStats : ScriptableObject 
{
    [SerializeField] Sprite shipSprite;
    public Sprite ShipSprite => shipSprite;

    [SerializeField] int shipMaxHealth = 3;
    public int ShipMaxHealth => shipMaxHealth;
    
    [SerializeField] int shipMoveSpeed = 10;
    public int ShipMoveSpeed => shipMoveSpeed;
   
    [SerializeField] int shipBulletDamage = 1;
    public int ShipBulletDamage => shipBulletDamage;

    [SerializeField] float shipReloadTime = 1f;
    public float ShipReloadTime => shipReloadTime;

    [SerializeField] int passesThroughEnemy = 1;
    public int ProjectilePassesThroughEnemy => passesThroughEnemy;

    [SerializeField] int bulletSpeed = 100;
    public int BulletSpeed => bulletSpeed;
}