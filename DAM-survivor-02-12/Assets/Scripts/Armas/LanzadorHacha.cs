using UnityEngine;
using System.Collections;

public class LanzadorHacha : MonoBehaviour
{
    [Header("Prefab del Hacha")]
    public GameObject hachaPrefab;

    [Header("Estadísticas del Lanzador")]
    public int nivel = 1;               
    public float dañoBase = 25f;         
    public float progresion = 0.5f;     

    [Header("Velocidad y ráfaga")]
    public float velocidadHacha = 10f;
    public float delayEntreHachas = 0.2f;  
    public float intervaloDisparo = 1f;    

    private void Start()
    {
        StartCoroutine(DisparoAutomatico());
    }

    public int NumeroHachas => nivel;

    public float DañoActual => dañoBase * (1 + (nivel - 1) * progresion);

    private IEnumerator DisparoAutomatico()
    {
        while (true)
        {
            yield return LanzarRafaga();
            yield return new WaitForSeconds(intervaloDisparo);
        }
    }

    private IEnumerator LanzarRafaga()
    {
        for (int i = 0; i < NumeroHachas; i++)
        {
            GameObject nuevaHacha = Instantiate(hachaPrefab, transform.position, transform.rotation);

            Hacha hachaScript = nuevaHacha.GetComponent<Hacha>();
            if (hachaScript != null)
            {
                hachaScript.damage = Mathf.RoundToInt(DañoActual);
                hachaScript.speed = velocidadHacha;
            }

            yield return new WaitForSeconds(delayEntreHachas);
        }
    }

    public void SubirNivel()
    {
        nivel++;
    }
}
