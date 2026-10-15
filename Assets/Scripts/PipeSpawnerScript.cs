using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipeColumn;
    public float spawnRate = 1;
    public float maxHeightOffset = 1;
    public float offsetRandomStep = 0.5f;

    private float _spawnTimer;
    private float _minY;
    private float _maxY;

    private void Start()
    {
        _minY = transform.position.y - maxHeightOffset;
        _maxY = transform.position.y + maxHeightOffset;

        SpawnPipeColumn();
    }

    void Update()
    {
        if (_spawnTimer < spawnRate)
        {
            _spawnTimer += Time.deltaTime;
            return;
        }

        SpawnPipeColumn();
    }

    private void SpawnPipeColumn()
    {
        float randomY = 0;

        // Never spawn in middle.
        while (randomY == 0)
            randomY = RandomWithStep(_minY, _maxY, offsetRandomStep);

        var spawnPosition = new Vector3(transform.position.x, randomY, 0);

        Instantiate(pipeColumn, spawnPosition, transform.rotation);
        _spawnTimer = 0;
    }

    private float RandomWithStep(float min, float max, float step)
    {
        int totalSteps = Mathf.FloorToInt((max - min) / step);
        int randomStep = Random.Range(0, totalSteps + 1);
        float value = min + (randomStep * step);

        return value;
    }
}
