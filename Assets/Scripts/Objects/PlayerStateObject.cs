using Unity.Properties;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateObject", menuName = "Scriptable Objects/PlayerStateObject")]
public class PlayerStateObject : ScriptableObject
{
    public int initialScore = 0;
    public bool initialIsAlive = true;

    [CreateProperty(ReadOnly = true)]
    public int Score { get; set; }

    [CreateProperty(ReadOnly = true)]
    public bool IsAlive { get; set; }

    public void ResetToInitial()
    {
        Score = initialScore;
        IsAlive = initialIsAlive;
    }

    public PlayerStateObject() => ResetToInitial();
}
