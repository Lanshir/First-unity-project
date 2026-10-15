using UnityEngine;

public class PileColumnScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZoneX = -10;

    void Update()
    {
        transform.position += Time.deltaTime * moveSpeed * Vector3.left;

        if (transform.position.x < deadZoneX)
        {
            Destroy(gameObject);
        }
    }
}
