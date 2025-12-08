using UnityEngine;
using System.Collections;

public class LanzadorCuchilla : MonoBehaviour
{
    [Header("Prefab de la Cuchilla")]
    public GameObject cuchillaPrefab;

    [Header("Estadísticas base")]
    public int nivel = 1;
    public int dañoBase = 25;
    public float cooldownBase = 1f;
    public Vector3 tamañoBase = new Vector3(1f, 1f, 2f);

    [Header("Progresión por nivel")]
    public int incrementoDaño = 5;
    public Vector3 incrementoTamaño = new Vector3(0.2f, 0f, 0.3f);
    public float decrementoCooldown = 0.05f;

    private GameObject cuchillaActiva;

    void Start()
    {
        StartCoroutine(GenerarTajos());
    }

    private IEnumerator GenerarTajos()
    {
        while (true)
        {
            CrearCuchilla();
            yield return new WaitForSeconds(GetCooldown());
            DestruirCuchilla();
        }
    }

    void CrearCuchilla()
    {
        if (cuchillaPrefab == null) return;

        // Posición un poco delante del jugador
        Vector3 posicionTajo = transform.position + transform.forward * 1f; // 1 unidad hacia adelante, ajustable

        cuchillaActiva = Instantiate(cuchillaPrefab, posicionTajo, Quaternion.identity, transform);

        // Ajustamos stats según nivel
        Cuchilla scriptCuchilla = cuchillaActiva.GetComponent<Cuchilla>();
        if (scriptCuchilla != null)
        {
            scriptCuchilla.damage = GetDamage();
            scriptCuchilla.spawnPosition = transform; // sigue al jugador
            scriptCuchilla.tiempoVida = GetCooldown();
        }

        // Ajustamos tamaño del Collider
        Collider col = cuchillaActiva.GetComponent<Collider>();
        if (col != null)
        {
            col.transform.localScale = tamañoBase + Vector3.Scale(incrementoTamaño, new Vector3(nivel - 1, nivel - 1, nivel - 1));
        }
    }

    void DestruirCuchilla()
    {
        if (cuchillaActiva != null)
            Destroy(cuchillaActiva);
    }

    //incremento stats por lambdas - se llama en la creacion de la cuchilla
    int GetDamage() => dañoBase + incrementoDaño * (nivel - 1);
    float GetCooldown() => Mathf.Max(0.1f, cooldownBase - decrementoCooldown * (nivel - 1));
}
