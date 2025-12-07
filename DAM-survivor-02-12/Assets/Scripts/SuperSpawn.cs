using UnityEngine;

public class SuperSpawn : MonoBehaviour
{
    [Header("La habilidad del Enemigo 4")]
    public GameObject zangano;
    public int army = 10;
    public float spawnRadius = 10f;

    private Transform player;

    void OnEnable()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < army; i++)
        {
            Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = player.position + new Vector3(randomPoint.x, 0f, randomPoint.y);

            Instantiate(zangano, spawnPosition, Quaternion.identity);
        }
    }
}
