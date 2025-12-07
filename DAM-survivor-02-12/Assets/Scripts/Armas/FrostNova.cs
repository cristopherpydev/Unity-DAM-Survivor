using System.Collections.Generic;
using UnityEngine;

public class FrostNova : MonoBehaviour
{
    public int dotDamage = 2;
    public float dotTime = 0.25f;

    public float ralentizacion = 2f;

    private Transform jugador;
    private float tiempoAcumulado = 0f;

    // Lista de todos los enemigos dentro
    private List<EnemyController> enemigosDentro = new List<EnemyController>();

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = jugador.position;

        tiempoAcumulado += Time.deltaTime;

        if (tiempoAcumulado >= dotTime)
        {
            foreach (EnemyController enemy in enemigosDentro)
            {
                if (enemy != null)
                {
                    enemy.Recibirdano(dotDamage);
                    enemy.Ralentizar(ralentizacion);
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
            {
                enemigosDentro.Add(enemy);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            enemy.ResetVeloc();

            if (enemy != null && enemigosDentro.Contains(enemy))
            {
                enemigosDentro.Remove(enemy);
            }
        }
    }
}
