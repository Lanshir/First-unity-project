using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(PanelRenderer))]
public class StartupMenuScript : MonoBehaviour
{
    private PanelRenderer _panelRenderer;

    private void OnEnable()
    {
        _panelRenderer = GetComponent<PanelRenderer>();
        _panelRenderer.RegisterUIReloadCallback(OnPanelReloadCallback);
    }

    private void OnDisable()
    {
        if (_panelRenderer != null)
            _panelRenderer.UnregisterUIReloadCallback(OnPanelReloadCallback);
    }

    private void OnPanelReloadCallback(PanelRenderer panel, VisualElement root)
    {
        var startButton = root.Q<Button>("StartButton");
        var quitButton = root.Q<Button>("QuitButton");

        startButton.clicked += () => SceneManager.LoadScene(Constants.Scenes.Gameplay);
        quitButton.clicked += () => Application.Quit();
    }
}
