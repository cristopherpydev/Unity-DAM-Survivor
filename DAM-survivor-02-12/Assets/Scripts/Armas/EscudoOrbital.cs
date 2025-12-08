using UnityEngine;

public class EscudoOrbital : MonoBehaviour
{
    public Transform player;
    public float distancia = 2f;
    public float velocidadRotacion = 180f;
    public float anguloInicial = 0f;
    public int damage = 10;

    private float anguloActual;

    void Start()
    {
        anguloActual = anguloInicial;
    }

    void Update()
    {
        if (player == null) return;

        // ROTACION ORBITAL
        anguloActual += velocidadRotacion * Time.deltaTime;
        float rad = anguloActual * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * distancia;
        transform.position = player.position + offset;

        transform.LookAt(player.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
                enemy.Recibirdano(damage);
        }
    }
}
