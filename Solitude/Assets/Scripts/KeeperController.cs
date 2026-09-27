using UnityEngine;

public class KeeperController : MonoBehaviour
{
    public Transform pontoA, pontoB;
    public Transform skin;
    public bool goRight;
    public CapsuleCollider2D keeperCollider = null;
    public float speed = 1;
    private Vector3 startPoint, endPoint;
    private SpriteRenderer sprite;

    void Start()
    {
        if (pontoA == null || pontoB == null)
        {
            Debug.LogWarning("Patrulha sem pontos A/B: " + name, this);
            enabled = false;
            return;
        }
        // Store world positions so child waypoints do not move with the enemy.
        startPoint = pontoA.position;
        endPoint = pontoB.position;
        sprite = skin != null ? skin.GetComponent<SpriteRenderer>() : null;
        goRight = true;
    }

    void Update()
    {
        Vector3 target = goRight ? endPoint : startPoint;
        if (sprite != null) sprite.flipX = target.x < transform.position.x;
        transform.position = Vector3.MoveTowards(transform.position, target, Mathf.Max(0f, speed) * Time.deltaTime);
        if (Vector2.Distance(transform.position, target) < 0.02f) goRight = !goRight;
    }
}
