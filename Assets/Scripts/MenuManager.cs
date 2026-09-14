using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]CanvasGroup _mainMenuButtonsCG;
    [SerializeField] CanvasGroup _quitConfirmationCG;
    CanvasGroup _mainMenuCG;

   void Awake()
    {
        _mainMenuCG = GetComponent<CanvasGroup>();
        OpenMainMenu();
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit!");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    void CanvasGroupSetState(CanvasGroup canvasGroup, bool state) 
    {
        canvasGroup.alpha = state ? 1.0f : 0.0f;
        canvasGroup.interactable = state;
        canvasGroup.blocksRaycasts = state;
    }
    public void OpenQuitConfirmation()
    {
        CanvasGroupSetState(_mainMenuButtonsCG, false);
        CanvasGroupSetState(_quitConfirmationCG, true);
    }
    public void CloseQuitConfirmation()
    {
        CanvasGroupSetState(_mainMenuButtonsCG, true);
        CanvasGroupSetState(_quitConfirmationCG, false);
    }
    public void OpenMainMenu()
    {
        CanvasGroupSetState(_mainMenuCG, true);
        
    }
    public void CloseMainMenu()
    {
        CanvasGroupSetState(_mainMenuCG, false);

    }
    public void Play()
    {
        CloseMainMenu();
        GameManager.Instance.StartGame();
    }
}
