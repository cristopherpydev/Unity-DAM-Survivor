using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    [Header("Prefabs de armas")]
    public GameObject[] armasPrefab; // Prefabs que arrastras en el Inspector
    private GameObject[] armasInstanciadas; // Para guardar las instancias
    private int indiceActual = 0;

    public Controles input;

    void Awake()
    {
        if (input == null)
            input = new Controles();
    }

    void OnEnable()
    {
        input.Enable();
        input.Player.AñadirArma.performed += OnAñadirArma;
    }

    void OnDisable()
    {
        input.Player.AñadirArma.performed -= OnAñadirArma;
        input.Disable();
    }

    void Start()
    {
        // Inicializamos el array de instancias
        armasInstanciadas = new GameObject[armasPrefab.Length];

        // Instanciamos solo la primera arma al inicio (si hay alguna)
        if (armasPrefab.Length > 0)
        {
            InstanciarArma(indiceActual);
            Debug.Log("Arma inicial activada: " + armasPrefab[indiceActual].name);
        }
    }

    private void OnAñadirArma(InputAction.CallbackContext ctx)
    {
        ActivarSiguienteArma();
    }

    void ActivarSiguienteArma()
    {
        if (indiceActual + 1 >= armasPrefab.Length)
        {
            Debug.Log("Ya están todas las armas activadas.");
            return;
        }

        indiceActual++;
        InstanciarArma(indiceActual);
        Debug.Log("Activada arma: " + armasPrefab[indiceActual].name);
    }

    // Método para instanciar un prefab y asignarlo al Player
    void InstanciarArma(int indice)
    {
        if (armasInstanciadas[indice] == null)
        {
            // Instanciamos el prefab como hijo del Player
            armasInstanciadas[indice] = Instantiate(armasPrefab[indice], transform);
        }
        else
        {
            // Si ya está instanciada, simplemente activamos
            armasInstanciadas[indice].SetActive(true);
        }
    }
}
