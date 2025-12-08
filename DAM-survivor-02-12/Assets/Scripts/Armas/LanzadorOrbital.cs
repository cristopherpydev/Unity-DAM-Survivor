using UnityEngine;
using System.Collections.Generic;

public class LanzadorOrbital : MonoBehaviour
{
    [Header("Prefab del Orbe")]
    public GameObject prefabOrbe;

    [Header("Sistema de Nivel")]
    public int level = 1;

    [Header("Stats Base")]
    public int baseDamage = 10;
    public float baseSpeed = 180f;
    public int baseOrbs = 3;   // <--- AHORA 3 ORBES DE BASE

    [Header("Escalado")]
    public float speedPerLevel = 20f;
    public int damagePerLevel = 2;

    private int lastLevel = -1;
    private List<EscudoOrbital> orbes = new List<EscudoOrbital>();

    void Start()
    {
        ActualizarOrbes();
    }

    void Update()
    {
        if (level != lastLevel)
        {
            Debug.Log("### NIVEL CAMBIADO — REGENERANDO ORBES ###");
            ActualizarOrbes();
        }
    }

    void ActualizarOrbes()
    {
        lastLevel = level;

        // ---------- CALCULO DE STATS ----------
        int cantidad = baseOrbs + ContarNivelesImpares(level);
        float speed = baseSpeed + (level * speedPerLevel);
        int damage = baseDamage + (level * damagePerLevel);

        Debug.Log($"Orbes totales: {cantidad} | Rotación: {speed} | Daño: {damage}");

        // ---------- ELIMINAR ORBES EXISTENTES ----------
        foreach (var orb in orbes)
        {
            if (orb != null)
                Destroy(orb.gameObject);
        }
        orbes.Clear();

        // ---------- CREAR NUEVOS ORBES ----------
        for (int i = 0; i < cantidad; i++)
        {
            GameObject nuevo = Instantiate(prefabOrbe);
            EscudoOrbital o = nuevo.GetComponent<EscudoOrbital>();

            o.player = transform;
            o.velocidadRotacion = speed;
            o.damage = damage;

            o.anguloInicial = (360f / cantidad) * i;

            orbes.Add(o);

            Debug.Log($"Orbe #{i} creado en ángulo {o.anguloInicial}");
        }
    }

    // Cuenta cuántos niveles impares hay: 1, 3, 5, 7...
    int ContarNivelesImpares(int lvl)
    {
        int count = 0;
        for (int i = 1; i <= lvl; i++)
        {
            if (i % 2 != 0) // impar
                count++;
        }

        // Ahora NO restamos nada porque baseOrbs ya es 3
        return count - 1; // Restamos solo el primer nivel 1 para que Nivel 1 siga teniendo 3
    }
}
