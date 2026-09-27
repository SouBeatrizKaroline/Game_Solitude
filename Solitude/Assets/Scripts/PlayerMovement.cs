using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    [Min(0f)] public float coyoteTime = 0.12f;
    [Min(0f)] public float jumpBuffer = 0.12f;
    private Rigidbody2D rb;
    private readonly ContactPoint2D[] contacts = new ContactPoint2D[16];
    private float horizontal;
    private float lastGrounded = float.NegativeInfinity;
    private float lastJumpPressed = float.NegativeInfinity;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    void Update()
    {
        if (Time.timeScale == 0f)
        {
            horizontal = 0f;
            lastJumpPressed = float.NegativeInfinity;
            return;
        }
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump")) lastJumpPressed = Time.time;
    }

    void FixedUpdate()
    {
        // Upward contact normals distinguish floors from walls and our own colliders.
        int count = rb.GetContacts(contacts);
        if (rb.velocity.y <= 0.1f)
            for (int i = 0; i < count; i++)
                if (contacts[i].normal.y > 0.5f) lastGrounded = Time.time;

        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        if (Time.time - lastJumpPressed <= jumpBuffer && Time.time - lastGrounded <= coyoteTime)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            lastJumpPressed = lastGrounded = float.NegativeInfinity;
        }
    }
}
