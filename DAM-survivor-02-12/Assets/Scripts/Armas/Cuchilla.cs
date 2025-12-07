using UnityEngine;

public class Cuchilla : MonoBehaviour
{
    [Header("Datos de la cuchilla")]
    public float speed = 10f;
    public float tiempoVida = 5f;
    public int damage = 25;

    [HideInInspector] 
    public Transform spawnPosition;

    void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        if (spawnPosition != null)
        {
            transform.position = spawnPosition.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
                enemy.Recibirdano(damage);
        }
    }
}
