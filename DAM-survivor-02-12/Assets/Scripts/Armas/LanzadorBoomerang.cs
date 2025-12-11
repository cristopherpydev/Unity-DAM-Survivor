using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class LanzadorBoomerang : MonoBehaviour
{
    [Header("Proyecto")]
    public GameObject boomerang;
    public float ratioDisparo = 1f;

    [Header("Escalado de daño")]
    public int lvl = 1;
    public float baseDamage = 2f;
    public float multiplier = 1.2f; 
    [HideInInspector] public float currentDamage;

    [Header("Input System")]
    public Controles inputActions; 
    public string subirNivelActionName = "SubirNivel";


   private void Awake()
    {
        inputActions = new Controles();
        inputActions.Player.SubirNivel.performed += ctx => SubirNivel();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    void Start()
    {
        RecalcularStats();
        StartCoroutine(DispararArma());
    }



    void SubirNivel()
    {
        lvl++;
        RecalcularStats();
        Debug.Log($"Nivel aumentado a {lvl}, daño actual: {currentDamage}");
    }

    public void RecalcularStats()
    {
        currentDamage = baseDamage * Mathf.Pow(multiplier, lvl - 1);
    }

    public IEnumerator DispararArma()
    {
        while (true)
        {
            int i = 0;
            while (lvl > i)
            {
                GameObject proyectilBoomerang = Instantiate(boomerang, transform.position, transform.rotation * boomerang.transform.rotation);
                ChakramBoomerang chakram = proyectilBoomerang.GetComponent<ChakramBoomerang>();
                if (chakram != null)
                {
                    chakram.nivelArma = lvl;
                    chakram.damage = Mathf.RoundToInt(currentDamage);
                }
                yield return new WaitForSeconds(0.2f);
                i++;
            }
            yield return new WaitForSeconds(ratioDisparo);
        }
    }
}
