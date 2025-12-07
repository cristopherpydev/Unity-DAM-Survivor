using UnityEngine;

public class LanzadorOrbital : MonoBehaviour
{
    public GameObject prefabOrbe;
    public int cantidadOrbes = 3;
    public float distancia = 2f;
    public float velocidadRotacion = 180f;

    void Start()
    {
        CrearOrbes();
    }

    void CrearOrbes()
    {
        if (prefabOrbe == null)
        {
            Debug.LogError("NO HAY PREFAB EN EL LANZADOR");
            return;
        }

        for (int i = 0; i < cantidadOrbes; i++)
        {
            GameObject nuevo = Instantiate(prefabOrbe);
            EscudoOrbital orb = nuevo.GetComponent<EscudoOrbital>();

            orb.player = transform; // SIEMPRE SE ASIGNA
            orb.distancia = distancia;
            orb.velocidadRotacion = velocidadRotacion;

            // Ángulo inicial automático
            orb.anguloInicial = (360f / cantidadOrbes) * i;
        }
    }
}
