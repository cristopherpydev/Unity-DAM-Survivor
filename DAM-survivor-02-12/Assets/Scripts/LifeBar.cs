using UnityEngine;
using UnityEngine.UI; 

public class LifeBar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image Health; //la imagen que se usa en relleno
    public PlayerStats player;
    
    void Update()
    {
        if (player != null && Health != null)
        {
            float fillAmount = (float)player.currentHealth / player.maxHealth;
            Health.fillAmount = Mathf.Clamp01(fillAmount); //el factor de reconversion
        }
    }
}
