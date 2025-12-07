using UnityEngine;
using System.Collections;

public class LanzadorFrostNova : MonoBehaviour
{
    public GameObject frostNova;
    public float radioFrostNova = 1f;

    public int lvl = 1;

    void Start()
    {
        Instantiate(frostNova, transform.position, transform.rotation);
    }
}
