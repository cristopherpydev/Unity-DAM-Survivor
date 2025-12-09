using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /// ////////////////////////////////// Variables ///////////////////////
    // Referencia al jugador (componente PlayerStats)
    private PlayerStats player;

    // Info del SO
    public EnemyStats Stats;

    public GameObject orbeDorado;
    public GameObject orbeVerde;
    public GameObject orbeAzul;

    public GameObject damageOutputPrefab;

    // Stats propios
    private int maxHP = 5;
    private int currentHP = 5;
    private int damage;
    private int defense = 0;
    private float speed;
    private bool estaRalentizado = false;

    private UnityEngine.AI.NavMeshAgent agent;
    
    

    /// ////////////////////////////////// Funciones Unity //////////////////
    void Awake()
    {
        maxHP = Stats.MaxHP;
        currentHP = maxHP;
        damage = Stats.Damage;
        defense = Stats.Defense;
        speed = Stats.Speed;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = Stats.Speed; //la razon de esto es que quiero seguir usando mis scriptable Objects
    }

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.GetComponent<PlayerStats>();
        }
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    public void Recibirdano(int danio)
    {
        int danioFinal = danio - defense;
        if (danioFinal < 0) danioFinal = 0;

        currentHP -= danioFinal;
        if (currentHP <= 0)
        {
            Morir();
        }

        if (damageOutputPrefab != null)
        {
            GameObject popup = Instantiate(damageOutputPrefab, transform.position + Vector3.up, Quaternion.identity);
            popup.GetComponent<DamagePopup>().Setup(danio);
            Debug.Log(danio);
        }
    }

    public void Ralentizar(float factor)
    {
        if (!estaRalentizado)
        {
            agent.speed = Stats.Speed / factor;
            estaRalentizado = true;
        }
    }

    public void ResetVeloc()
    {
        agent.speed = Stats.Speed;
        estaRalentizado = false;
    }


    private void Morir()
    {
        float roll = Random.value;

        if (roll < 0.6f) // verde 60%
        {
            if (orbeVerde != null)
                Instantiate(orbeVerde, transform.position, transform.rotation);
        }
        else if (roll < 0.9f) // azul 30%
        {
            if (orbeAzul != null)
                Instantiate(orbeAzul, transform.position, transform.rotation);
        }
        else // dorado 10%
        {
            if (orbeDorado != null)
                Instantiate(orbeDorado, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }

    public void hacerDanio()
    {
        if (player != null)
        {
            player.RecibirDmg(damage);
        }
    }
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))
        {
            hacerDanio();
        }
    }

}


