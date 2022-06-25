using UnityEngine;

public class CircleAI : MonoBehaviour
{
    public float moveSpeed;
    public float attackRange = 3f;
    public bool isRedTeam;
    public LayerMask Damagable;
    public GameObject BulletPrefab;
    public float FireInterval;

    [SerializeField] private bool hasTarget;



    private Vector2 movementVector;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movementVector = isRedTeam ? Vector2.right : Vector2.left;
        InvokeRepeating(nameof(Shoot), 0f, FireInterval);
    }

    void FixedUpdate()
    {
        //Get the first object hit by the ray
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movementVector, attackRange);

        //If the collider of the object hit is not NUll
        if (hit.collider != null)
        {
            if (Damagable == (Damagable | (1 << hit.collider.gameObject.layer)))
            {
                hasTarget = true;
            }
            Debug.Log("Hitting: " + hit.collider.gameObject.name);
            Debug.Log(hasTarget);
        }

        //Method to draw the ray in scene for debug purpose
        Debug.DrawRay(transform.position, movementVector * attackRange, isRedTeam ? Color.red : Color.blue);



        if (hasTarget)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = moveSpeed * movementVector;
        }
    }

    private void Shoot()
    {
        if (!hasTarget)
            return;
        GameObject spawnedBullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
        spawnedBullet.GetComponent<circleBullet>().isRedTeam = isRedTeam;
    }
}
