using UnityEngine;

[RequireComponent(typeof(LightSystem))]
public class Damage : MonoBehaviour
{
    public float damage;
    [Min(0f)] public float invulnerabilityTime = 1f;
    private LightSystem lightSystem;
    private float nextDamageTime;

    void Awake() { lightSystem = GetComponent<LightSystem>(); }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Time.timeScale == 0f || Time.time < nextDamageTime || !other.CompareTag("Enemy")) return;
        lightSystem.TakeDamage(Mathf.Max(0f, damage));
        nextDamageTime = Time.time + invulnerabilityTime;
    }
}
