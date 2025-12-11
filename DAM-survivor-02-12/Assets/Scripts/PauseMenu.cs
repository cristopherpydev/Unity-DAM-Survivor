using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;   
    bool isPaused = false;

    Controles inputActions;         
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
        inputActions.Player.Disable(); 
        Time.timeScale = 1f;
        isPaused = false;
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenuScreen");

}
}
