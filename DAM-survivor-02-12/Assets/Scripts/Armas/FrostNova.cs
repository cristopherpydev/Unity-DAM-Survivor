using UnityEngine;
using System.Collections.Generic;

public class FrostNova : MonoBehaviour
{
    public int dotDamage = 2;
    public float dotTime = 0.50f;
    public float ralentizacion = 2f;

    public Transform objetivo;  

    private float tiempoAcumulado = 0f;
    private List<EnemyController> enemigosDentro = new List<EnemyController>();

    void Start()
    {
        if (objetivo == null)
            objetivo = transform.parent;
    }

    void Update()
    {
        if (objetivo != null)
            transform.position = objetivo.position;

        tiempoAcumulado += Time.deltaTime;

        if (tiempoAcumulado >= dotTime)
        {
            foreach (EnemyController enemy in enemigosDentro)
            {
                if (enemy != null)
                {
                    enemy.Recibirdano(dotDamage);
                }
            }
            tiempoAcumulado = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null && !enemigosDentro.Contains(enemy))
                enemigosDentro.Add(enemy);
                enemy.Ralentizar(ralentizacion);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.ResetVeloc();
                enemigosDentro.Remove(enemy);
            }
        }
    }
}
