using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateObject", menuName = "Scriptable Objects/PlayerStateObject")]
public class PlayerStateObject : ScriptableObject
{
    public int initialScore = 0;
    public bool initialIsAlive = true;

    public int score;
    public bool isAlive;

    public void ResetToInitial()
    {
        score = initialScore;
        isAlive = initialIsAlive;
    }

    public PlayerStateObject() => ResetToInitial();
}
