using UnityEngine;

public class LanzadorFrostNova : MonoBehaviour
{
    [Header("Prefab Frost Nova")]
    public GameObject frostNovaPrefab;

    [Header("Estadísticas")]
    public int nivel = 1;
    public int dañoBase = 2;
    public float ralentizacionBase = 2f;
    public float progresionDaño = 0.5f;
    public float progresionRalent = 0.5f;

    private FrostNova frostScript;
    private int nivelAnterior;

    void Start()
    {
        GameObject frost = Instantiate(
            frostNovaPrefab,
            transform.position,
            Quaternion.identity,
            transform
        );

        frostScript = frost.GetComponent<FrostNova>();

        if (frostScript != null)
        {
            frostScript.objetivo = transform;

            AumentarStats();
        }

        nivelAnterior = nivel;
    }

    void Update()
    {
        // Si el valor en el inspector cambió → actualizamos stats
        if (nivel != nivelAnterior)
        {
            nivelAnterior = nivel;
            AumentarStats();
        }
    }

    public void SubirNivel()
    {
        nivel++;
        AumentarStats();
    }

    public void AumentarStats()
    {
        if (frostScript == null) return;

        frostScript.dotDamage = Mathf.RoundToInt(
            dañoBase * (1 + (nivel - 1) * progresionDaño)
        );

        frostScript.ralentizacion = ralentizacionBase *
            (1 + (nivel - 1) * progresionRalent);

        Debug.Log($"[FrostNova] Nivel: {nivel} | Daño: {frostScript.dotDamage} | Ralentización: {frostScript.ralentizacion}");
    }
}
