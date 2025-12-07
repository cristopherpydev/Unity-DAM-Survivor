using UnityEngine;

public class RadioRecogida : MonoBehaviour
{
    public GameObject player;
    public PlayerStats playerStats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Orbe")
        {
            Orbes orbeTocado = other.GetComponent<Orbes>();
            if (orbeTocado != null)
            {
                CogerOrbe(orbeTocado);

            }
        }
    }
    void CogerOrbe(Orbes orbeEspecifico)
    {
        playerStats.RecibirExperiencia(orbeEspecifico.experiencia);
        orbeEspecifico.DestruirObjeto();
    }
}
