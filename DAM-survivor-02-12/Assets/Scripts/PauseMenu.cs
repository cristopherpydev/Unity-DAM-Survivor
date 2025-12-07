using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;   // Panel del menú de pausa
    bool isPaused = false;

    Controles inputActions;          // Tu clase generada

    void Awake()
    {
        inputActions = new Controles();
    }

    void OnEnable()
    {
        inputActions.Player.Pause.performed += OnPausePerformed;
        inputActions.Player.Enable();
    }

    void OnDisable()
    {
        inputActions.Player.Pause.performed -= OnPausePerformed;
        inputActions.Player.Disable();
    }

    void Start()
    {
        // Asegura estado inicial sano
        Time.timeScale = 1f;
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);
    }

    void OnPausePerformed(InputAction.CallbackContext ctx)
    {
        if (isPaused) Resume();
        else Pause();
    }

    public void Resume()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitGame(){
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
}
}
