using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;
    private int ataque = 5;
    private int defensa = 0;
    public GameObject mainCameraGO; // referencia al objeto que tiene CameraShake
    private int nivel = 1;
    private int experiencia = 0;
    private int expSubida = 100;
    private float velMov = 5f;

    private float velAtk = 1f;

    private bool estaVivo;
    public CameraShake sacudida;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake() 
    {
        currentHealth = maxHealth;
        estaVivo = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    //////////////////////////////// Funciones propias /////////////////////////
    

    public void RecibirDmg(int dmg)
    {
        Debug.Log("RecibirDmg llamado con dmg = " + dmg);

        if (!estaVivo) return;

        if (dmg > defensa)
        {
            currentHealth -= dmg - defensa;

            Debug.Log("Vida actual: " + currentHealth);

            if (mainCameraGO != null)
            {
                CameraShake cameraShake = mainCameraGO.GetComponent<CameraShake>();
                if (cameraShake != null)
                {
                    cameraShake.Shake();
                }
            }

            if (currentHealth <= 0)
                estaVivo = false;
        }
    }



    public void RecibirExperiencia(int cantidad)
    {
        experiencia += cantidad;

        while (experiencia >= expSubida)
        {
            experiencia -= expSubida;
            nivel++;

            expSubida = (int)(expSubida * 1.2f);

            float porcentajeVida = (float)currentHealth / maxHealth;

            maxHealth = Mathf.RoundToInt(maxHealth * 1.2f);

            currentHealth = Mathf.RoundToInt(maxHealth * porcentajeVida);

            Debug.Log($"[LEVEL UP] Nivel: {nivel}");
            Debug.Log($"Vida: {currentHealth}/{maxHealth}");
        }
    }
}