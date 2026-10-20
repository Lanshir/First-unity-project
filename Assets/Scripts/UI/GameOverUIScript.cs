using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(PanelRenderer))]
public class GameOverUIScript : MonoBehaviour
{
    private PanelRenderer _panelRenderer;
    private GameStateManagerScript _gameState;

    private void OnEnable()
    {
        _panelRenderer = GetComponent<PanelRenderer>();
        _gameState = Helpers.GetGameStateManager();

        _panelRenderer.RegisterUIReloadCallback(OnPanelReloadCallback);
    }

    private void OnDisable()
    {
        if (_panelRenderer != null)
            _panelRenderer.UnregisterUIReloadCallback(OnPanelReloadCallback);
    }

    private void OnPanelReloadCallback(PanelRenderer panel, VisualElement root)
    {
        var retryButton = root.Q<Button>("RetryButton");
        var quitButton = root.Q<Button>("QuitButton");

        retryButton.clicked += _gameState.RestartGame;
        quitButton.clicked += _gameState.QuitToStartingScreen;
    }
}
