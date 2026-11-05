using Unity.VisualScripting;
using UnityEngine;

public class Tile_Manager : MonoBehaviour
{
    public GameObject groundTile;
    public GameObject obstacle;
    public GameObject obstacleVariant2;
    public GameObject obstacleVariant3;
    public GameObject decoration;
    public GameObject decorationVariant2;
    public GameObject HealthPowerup;
    public int numberOfTiles = 12; //el valor en el editor en el objeto Tile-manager pisa este valor; el valor escrito aquí es solamente de referencia
    public float tileLength = 20f;
    public Transform player;
    public GameObject drone;

    public Upgrade_Manager upgradeManager;
    private GameObject[] tiles;
    private GameObject[] obstaclePool;
    private float spawnZ = 0f;
    private int dynamicDifficulty = 1; //dicta la cantidad de obstáculos que se genera cada vez que se recicla una casilla
    private int dynDiffScaling = 0; //usado para incrementar dynamicDifficulty

    void Start()
    {
        upgradeManager = FindObjectOfType<Upgrade_Manager>();
        if (upgradeManager.HealthPowerupUnlocked == true)
        {
            obstaclePool = new[] { obstacle, obstacleVariant2, obstacleVariant3, decoration, decorationVariant2, HealthPowerup };
        }
        else
        {
            obstaclePool = new[] { obstacle, obstacleVariant2, obstacleVariant3, decoration, decorationVariant2 };
        }
        tiles = new GameObject[numberOfTiles];

        for (int i = 0; i < numberOfTiles; i++)
        {
            Vector3 pos = new Vector3(0, 0, spawnZ);
            tiles[i] = Instantiate(groundTile, pos, Quaternion.identity);
            UpdateSpawnZ();
            SpawnObstacle(tiles[i], Mathf.FloorToInt(tileLength), true);
        }
    }

    void SpawnObstacle(GameObject tile, int amount = 1, bool starter = false)
    {
        float randomX;
        float randomZ;
        int factor = 1;
        if (starter) factor++;
        Vector3 newObstaclePosition;
        for (int i = 0; i < amount * factor; i++)
        {
            if (i % 2 == 0)
            {
                randomX = Random.Range(-50f * (factor) + tile.transform.position.x, 50f * (factor) + tile.transform.position.x);
            }
            else
            {
                randomX = Random.Range(-50f + tile.transform.position.x, 50f + tile.transform.position.x);
            }
            randomZ = Random.Range(0f + tile.transform.position.z, -100f + tile.transform.position.z);
            newObstaclePosition = new(randomX, 1.3f, randomZ);
            GameObject NewObstacle = Instantiate(obstaclePool[Random.Range(0, obstaclePool.Length)], newObstaclePosition, new Quaternion(), tile.transform);
            Vector3 desiredScale = new Vector3(2, 4, 2);
            Vector3 TileScale = tile.transform.localScale;
            Vector3 inverseTileScale = new Vector3(1 / TileScale.x, 1 / TileScale.y, 1 / TileScale.z);
            NewObstacle.transform.localScale = Vector3.Scale(desiredScale, inverseTileScale);
        }

        //el obstaculo incrementa su escala debido a que es hijo, con esto se evita
    }
    void SpawnDrone(GameObject tile)
    {
        float randomX;
        float randomZ;
        float dynDiffFloat = dynamicDifficulty;
        Vector3 newObstaclePosition;
        for (int i = 0; i < Mathf.Ceil((dynDiffFloat)/10f); i++)
        {
            randomX = Random.Range(-50f + tile.transform.position.x, 50f + tile.transform.position.x);
            randomZ = Random.Range(0f + tile.transform.position.z, -100f + tile.transform.position.z);
            newObstaclePosition = new(randomX, 3f, randomZ);
            Instantiate(drone, newObstaclePosition, new Quaternion());
            print("Drone spawned");
        }
    }

    void Update()
    {
        if (!player.IsUnityNull())
        {
            if (player.position.z < (tiles[0].transform.position.z) - tileLength * 8)
            {
                RecycleTile();
                UpdateDynamicDifficulty();
            }
        }
    }

    void RecycleTile()
    {
        GameObject tile = tiles[0];

        Vector3 newPos = new Vector3(player.position.x, 0, spawnZ);
        tile.transform.position = newPos;
        UpdateSpawnZ();

        for (int i = 0; i < tiles.Length - 1; i++)
        {
            tiles[i] = tiles[i + 1];
        }
        tiles[tiles.Length - 1] = tile;
        SpawnObstacle(tile, dynamicDifficulty);
    }
    void UpdateDynamicDifficulty() //dicta cuándo se actualiza la dificultad dinámica
    {
        dynDiffScaling++;
        if (dynDiffScaling > numberOfTiles)
        {
            dynamicDifficulty++;
            dynDiffScaling = 0;
            SpawnDrone(tiles[0]);
        }
    }
    void UpdateSpawnZ() //lo coloqué como su propia función para probar cosas; al final lo dejé como estaba originalmente
    {
        spawnZ -= tileLength;//lo puse asi porque el personaje va avanzando por z negativo y me da flojera darlo vuelta
    }
}
