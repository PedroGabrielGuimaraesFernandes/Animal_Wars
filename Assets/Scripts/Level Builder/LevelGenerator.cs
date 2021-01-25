using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    [Header("Imagem Usada para montar o level")]
    public Texture2D map;

    [Header("Tilemap Usado para montar o level")]
    public Tilemap tilemap;

    [Header("Referência da cor que representa cada prefab")]
    public ColorToPrefab[] colorMappings;
    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }

    // Update is called once per frame
    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);
        if (pixelColor.a == 0)
        {
            //Se o pixel for transparente. Ele é ignorado.
            return;
        }

        foreach(ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x, y);
                //Vector3Int position = new Vector3Int(x, y, 0);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
                Debug.Log("x: " + x + " y: " + y + " Tem no grid Array");
                //tilemap.SetTile(position, colorMapping.ruleTile);
            }
        }
        //Debug.Log(pixelColor);
    }
}
