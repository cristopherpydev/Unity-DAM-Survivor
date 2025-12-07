using UnityEngine;

public class ChakramBoomerang : MonoBehaviour
{
    public float speed = 10f;
    public float returnSpeed = 14f;
    public float tiempoAntesDeVolver = 1f;
    public int damage = 2;

    public int nivelArma = 1;

    private Transform jugador;
    private bool volviendo = false;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;

        Invoke("VolverAlJugador", tiempoAntesDeVolver);
    }

    void Update()
    {
        if (!volviendo)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            Vector3 dir = (jugador.position - transform.position).normalized;
            transform.position += dir * returnSpeed * Time.deltaTime;

            //Cuando ya llegó, se destruye
            if (Vector3.Distance(transform.position, jugador.position) < 1f)
            {
                Destroy(gameObject);
            }
        }
    }

    void VolverAlJugador()
    {
        volviendo = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.Recibirdano(damage);
            }

            volviendo = true;
        }
    }
}
