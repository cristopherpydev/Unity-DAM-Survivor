using System.Collections;
using UnityEngine;

public class LanzadorArma : MonoBehaviour
{
    public GameObject[] armas;
    
    public Transform spawn;
    public float ratioDeDisparo = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(dispararArma());
    }

    public IEnumerator dispararArma()
    {
        while (true)
        {
            foreach (GameObject armaPrefab in armas)
            {
                if (armaPrefab == null)
                {
                    Debug.LogWarning("Un arma en el array 'armas' es null o ha sido destruida");
                    continue;
                }

                GameObject rayo = Instantiate(armaPrefab, spawn.position, transform.rotation);
                rayo.transform.SetParent(spawn);
                yield return new WaitForSeconds(ratioDeDisparo);
            }
        }
    }

}
