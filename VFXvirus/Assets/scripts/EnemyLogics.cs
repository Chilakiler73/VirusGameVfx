using UnityEngine;
using System.Collections;

public class EnemyLogics : MonoBehaviour
{
    public float health = 50f;
    public Color damageColor = Color.red;
    public float flashDuration = 0.15f;

    private Renderer myRenderer;
    private Color originalColor;
    private bool isFlashing = false;

    void Start()
    {
        // Buscamos el renderer en este objeto o en sus hijos (común en modelos FBX)
        myRenderer = GetComponentInChildren<Renderer>();

        if (myRenderer != null)
        {
            // Guardamos el color actual del Albedo
            originalColor = myRenderer.material.color;
        }
        else
        {
            Debug.LogError("¡No se encontró un Renderer en " + gameObject.name + "!");
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Vida restante: " + health);

        if (!isFlashing && myRenderer != null)
        {
            StartCoroutine(FlashRed());
        }

        if (health <= 0f)
        {
            Die();
        }
    }

    IEnumerator FlashRed()
    {
        isFlashing = true;

        // Cambiamos el color del material (esto tiñe la textura Albedo)
        myRenderer.material.color = damageColor;

        yield return new WaitForSeconds(flashDuration);

        // Restauramos el color original
        myRenderer.material.color = originalColor;

        isFlashing = false;
    }

    void Die()
    {
        Debug.Log("Enemigo eliminado");
        Destroy(gameObject);
    }
}