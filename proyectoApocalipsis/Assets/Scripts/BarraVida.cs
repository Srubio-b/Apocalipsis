using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f;  // Vida máxima
    private float currentHealth;    // Vida actual

    public Slider healthSlider;     // Referencia al Slider de la UI para la barra de vida

private float CurrentHealth
{
    get => currentHealth;
    set{
        currentHealth = Mathf.Clamp(value, 0, maxHealth);

        UpdateHealthUI();
    }
}

    void Start()
    {
        CurrentHealth = maxHealth;  // Al inicio la vida es la máxima
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)) Heal(10);
        if(Input.GetKeyDown(KeyCode.L)) TakeDamage(10);
    }

    // Función para reducir vida al recibir daño (por ejemplo, al tocar a un enemigo)
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
    }

    // Función para recuperar vida al recoger un botiquín
    public void Heal(float healAmount)
    {
        CurrentHealth += healAmount;
    }

    // Actualizar la UI de la barra de vida
    private void UpdateHealthUI()
    {
        if(!healthSlider) return;
        
        healthSlider.value = currentHealth / maxHealth;  // Actualizar el valor del Slider
    }

    // Para ver si el jugador colisiona con un enemigo, se puede usar OnCollisionEnter o OnTriggerEnter
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10f);  // Aquí defines cuánto daño recibe el jugador al tocar a un enemigo
        }
    }

    // Para cuando el jugador recoja un botiquín
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HealthPack"))
        {
            Heal(maxHealth * 0.25f);  // Recupera el 25% de la vida máxima
            Destroy(other.gameObject);  // Destruye el botiquín después de ser recogido
        }
    }
}
