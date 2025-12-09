using UnityEngine;
using UnityEngine.UI; 

public class LifeBar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image Health; // La imagen que se va a rellenar
    public PlayerStats player; // Referencia al jugador
    
    void Update()
    {
        if (player != null && Health != null)
        {
            Debug.Log("Estoy actualizando la barra de vida...");
            float fillAmount = (float)player.currentHealth / player.maxHealth;
            Health.fillAmount = Mathf.Clamp01(fillAmount);
            Debug.Log(fillAmount);

        }
    }
}
