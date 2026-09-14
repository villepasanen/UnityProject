using UnityEngine;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField]CanvasGroup _gameOverPanelCG;
    CanvasGroup _cg;
    public void Awake()
    {
        _cg = GetComponent<CanvasGroup>();
    }
    public void ShowGameOverPanel()
    {
        _gameOverPanelCG.alpha = 1;
        _gameOverPanelCG.interactable = true;
        _gameOverPanelCG.blocksRaycasts = true;
    }
    public void ReturnToMainMenu()
    {
        GameManager.Instance.ResetGame();
    }
    public void ShowInGameUI()
    {
        _cg.alpha = 1.0f;
        _cg.interactable = true;
        _cg.blocksRaycasts= true;
    }

}
