using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Ajustes de Vida")]
    public float maxHealth = 100f;
    public float currentHealth;

    void Start()
    {
        // Al iniciar, el jugador tiene la vida al máximo
        currentHealth = maxHealth;
    }

    // Esta función será llamada por los botiquines
    public void Heal(float amount)
    {
        currentHealth += amount;

        // Evitamos que la vida supere el máximo permitido
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        Debug.Log("¡Botiquín recogido! Vida actual: " + currentHealth);
    }
}