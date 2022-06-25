using UnityEngine;

public class circleBullet : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDamage;
    public Rigidbody2D rb;
    public bool isRedTeam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = bulletSpeed * (isRedTeam ? Vector2.right : Vector2.left);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        Damagable damagable = collision.gameObject.GetComponent<Damagable>();
        if (damagable != null)
        {
            damagable.takeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
