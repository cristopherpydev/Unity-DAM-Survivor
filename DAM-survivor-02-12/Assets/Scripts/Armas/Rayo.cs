using UnityEngine;

public class Rayo : MonoBehaviour
{
    public float tiempoVida = 3f;
    public int dotDamage = 2;

    public float dotTime = 0.25f;
    private float tiempoAcumulado = 0f;

    public Transform spawnPosition;

    private EnemyController enemigoActual; 

    void Start()
    {
        if (spawnPosition == null)
        {
            spawnPosition = GameObject.FindGameObjectWithTag("Player")
                .transform.Find("SpawnPosition").transform;
        }

        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        if (spawnPosition == null)
        {
            Debug.Log("ERROR TRANSFORM");
            return;
        }

        transform.position = spawnPosition.position;

        if (enemigoActual != null)
        {
            tiempoAcumulado += Time.deltaTime;
            if (tiempoAcumulado >= dotTime)
            
            {
                enemigoActual.Recibirdano(dotDamage);
                tiempoAcumulado = 0f;
            }
            else
            {
                Debug.Log("ERROR tiempo");

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemigoActual = other.GetComponent<EnemyController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy == enemigoActual)
            {
                enemigoActual = null;
                tiempoAcumulado = 0f;
            }
        }
    }
}
