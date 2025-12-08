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
    void Start()
    {
        GameObject frost = Instantiate(frostNovaPrefab, transform.position, Quaternion.identity);

        FrostNova frostScript = frost.GetComponent<FrostNova>();
        if (frostScript != null)
        {
            frostScript.dotDamage = Mathf.RoundToInt(dañoBase * (1 + (nivel - 1) * progresionDaño));
            frostScript.ralentizacion = ralentizacionBase * (1 + (nivel - 1) * progresionRalent);
        }
    }

    public void SubirNivel()
    {
        nivel++;
    }
}
