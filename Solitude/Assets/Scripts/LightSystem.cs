using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LightSystem : MonoBehaviour
{
    public Light lampada;
    public float intencidade;
    public float totalTime;
    public float currentTime;
    public Slider barra;
    [Min(1f)] public float maxTime = 30f;
    [Min(0f)] public float heartRecovery = 10f;
    public bool IsGameOver { get; private set; }
    private bool paused;
    private int hearts;

    void Start()
    {
        Time.timeScale = 1f;
        maxTime = Mathf.Max(1f, maxTime);
        if (barra != null) { barra.minValue = 0f; barra.maxValue = maxTime; }
        Refresh();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !IsGameOver) SetPaused(!paused);
        if (Input.GetKeyDown(KeyCode.R) && (paused || IsGameOver)) Restart();
        if (paused || IsGameOver) return;
        totalTime -= Time.deltaTime;
        Refresh();
    }

    public void TakeDamage(float amount)
    {
        if (paused || IsGameOver) return;
        totalTime -= Mathf.Max(0f, amount);
        Refresh();
    }

    void Refresh()
    {
        totalTime = Mathf.Clamp(totalTime, 0f, maxTime);
        currentTime = intencidade = totalTime;
        if (lampada != null) lampada.range = intencidade;
        if (barra != null) barra.value = currentTime;
        if (totalTime <= 0f)
        {
            IsGameOver = true;
            Time.timeScale = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (paused || IsGameOver || !other.CompareTag("Heart") || !other.gameObject.activeSelf) return;
        // Destroy is deferred; disable now to prevent duplicate collection.
        other.gameObject.SetActive(false);
        Destroy(other.gameObject);
        hearts++;
        totalTime += Mathf.Max(0f, heartRecovery);
        Refresh();
    }

    void SetPaused(bool value) { paused = value; Time.timeScale = value ? 0f : 1f; }
    void OnApplicationFocus(bool focused) { if (!focused && !IsGameOver) SetPaused(true); }
    void OnDisable() { Time.timeScale = 1f; }
    void Restart() { Time.timeScale = 1f; SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }

    void OnGUI()
    {
        GUI.Box(new Rect(12, 12, 290, 64), "Autoestima: " + Mathf.CeilToInt(totalTime) + " / " + maxTime +
            "   |   Corações: " + hearts + "\nA/D ou setas: mover   •   Espaço: pular\nEsc: pausar");
        if (!paused && !IsGameOver) return;
        float width = Mathf.Min(360f, Screen.width - 24f);
        GUILayout.BeginArea(new Rect((Screen.width - width) / 2f, Mathf.Max(12f, (Screen.height - 240f) / 2f), width, 240f), GUI.skin.box);
        GUILayout.Label(IsGameOver ? "Sua luz precisa de cuidado" : "Uma pausa para respirar");
        GUILayout.Label(IsGameOver ? "Você pode tentar de novo. Cada passo conta." : "Continue quando estiver pronta.");
        GUILayout.Space(12);
        if (!IsGameOver && GUILayout.Button("Continuar", GUILayout.Height(36))) SetPaused(false);
        if (GUILayout.Button("Tentar novamente (R)", GUILayout.Height(36))) Restart();
        if (GUILayout.Button("Voltar ao menu", GUILayout.Height(36)))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");
        }
        GUILayout.EndArea();
    }
}
