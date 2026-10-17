using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(PanelRenderer))]
public class GameLayoutScript : MonoBehaviour
{
    private PanelRenderer panelRenderer;
    private GameStateManagerScript gameState;

    private void OnEnable()
    {
        gameState = Helpers.GetGameStateManager();
        panelRenderer = GetComponent<PanelRenderer>();
        panelRenderer.RegisterUIReloadCallback(GameLayoutReloadCallback);
    }

    private void OnDisable()
    {
        panelRenderer.UnregisterUIReloadCallback(GameLayoutReloadCallback);
    }

    private void GameLayoutReloadCallback(PanelRenderer panel, VisualElement root)
    {
        root.dataSource = gameState.player;
    }
}
