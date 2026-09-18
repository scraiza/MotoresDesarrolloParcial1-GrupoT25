using UnityEngine;

public class Tile_Manager : MonoBehaviour
{
    public GameObject groundTile;
    public GameObject obstacle;
    public int numberOfTiles = 4;
    public float tileLength = 20f;
    public Transform player;

    private GameObject[] tiles;
    private float spawnZ = 0f;

    void Start()
    {
        tiles = new GameObject[numberOfTiles];

        for (int i = 0; i < numberOfTiles; i++)
        {
            Vector3 pos = new Vector3(0, 0, spawnZ);
            tiles[i] = Instantiate(groundTile, pos, Quaternion.identity);
            spawnZ -= tileLength; //lo puse asi porque el personaje va avanzando por z negativo y me da flojera darlo vuelta
            spawnObstacle(tiles[i]);
        }
    }

    void spawnObstacle(GameObject tile)
    {
        float randomX;
        float randomZ;
            Vector3 newObstaclePosition;
        for (int i = 0; i < Mathf.Floor(tileLength); i++)
        { 
            randomX = Random.Range(-50f, 50f);
            randomZ = Random.Range(-50f, 50f);
            newObstaclePosition = new(randomX, 1.3f, randomZ);
            GameObject NewObstacle = Instantiate(obstacle, newObstaclePosition, new Quaternion(), tile.transform);
            Vector3 desiredScale = new Vector3(2, 4, 2);
            Vector3 TileScale = tile.transform.localScale;
            Vector3 inverseTileScale = new Vector3(1 / TileScale.x, 1 / TileScale.y, 1 / TileScale.z);
            NewObstacle.transform.localScale = Vector3.Scale(desiredScale, inverseTileScale);
        }
       
        //el obstaculo incrementa su escala debido a que es hijo, con esto se evita
    }

    void Update()
    {
        if (player.position.z - tileLength < (tiles[0].transform.position.z - tileLength / 2))
        {
            RecycleTile();
        }
    }

    void RecycleTile()
    {
        GameObject tile = tiles[0];

        Vector3 newPos = new Vector3(0, 0, spawnZ);
        tile.transform.position = newPos;
        spawnZ -= tileLength;

        for (int i = 0; i < tiles.Length - 1; i++)
        {
            tiles[i] = tiles[i + 1];
        }
        tiles[tiles.Length - 1] = tile;
    }
}
