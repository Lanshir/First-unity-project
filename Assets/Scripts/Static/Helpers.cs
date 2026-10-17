using UnityEngine;

public static class Helpers
{
    public static float RandomWithStep(float min, float max, float step)
    {
        int totalSteps = Mathf.FloorToInt((max - min) / step);
        int randomStep = Random.Range(0, totalSteps + 1);
        float value = min + (randomStep * step);

        return value;
    }

    public static GameStateManagerScript GetGameStateManager()
        => GameObject
            .FindGameObjectWithTag(Constants.Tags.GameState)
            .GetComponent<GameStateManagerScript>();
}
