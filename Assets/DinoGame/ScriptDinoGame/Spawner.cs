using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnChance;
    }

    public SpawnableObject[] obstacles;
    public SpawnableObject[] gummies;

    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance = Random.value;

        // Decide whether to spawn an obstacle or a Gummy based on their spawn chances.
        if (spawnChance < 0.5f) // Adjust this threshold as needed.
        {
            SpawnObject(obstacles);
        }
        else
        {
            SpawnObject(gummies);
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void SpawnObject(SpawnableObject[] objectArray)
    {
        foreach (var obj in objectArray)
        {
            if (Random.value < obj.spawnChance)
            {
                GameObject spawnedObject = Instantiate(obj.prefab);
                spawnedObject.transform.position += transform.position;
                break;
            }
        }
    }
}


