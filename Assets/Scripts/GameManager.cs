using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField]MenuManager _mainMenuManager;
    [SerializeField] InGameUIManager _inGameUIManager;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        _inGameUIManager.ShowInGameUI();
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        _inGameUIManager.ShowGameOverPanel();
    }
}
