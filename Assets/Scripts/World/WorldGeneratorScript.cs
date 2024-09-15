using UnityEngine;

public class WorldGeneratorScript : MonoBehaviour
{
    [SerializeField] float frequency;
    [SerializeField] int Seed;
    [SerializeField] int Height;
    [SerializeField] int Width;
    [SerializeField] GameObject Grass;
    [SerializeField] GameObject Dirt;
    [SerializeField] GameObject Stone;
    [SerializeField] GameObject Bedrock;
    // Start is called before the first frame update
    void Start()
    {
        GenerateWorld();
    }
    void GenerateWorld()
    {
        Seed = Random.Range(-1000000, 1000000);
        int Ypos = 0;
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (GeneratePerlinNoise(j, i) <= 0.2) { Ypos = -1; }
                else if (GeneratePerlinNoise(j, i) <= 0.4) { Ypos = 0; }
                else if (GeneratePerlinNoise(j, i) <= 0.6) { Ypos = 1; }
                else if (GeneratePerlinNoise(j, i) <= 0.8) { Ypos = 2; }
                Instantiate(Grass, new Vector3(j, Ypos, i), Quaternion.identity);
                while (Ypos > -5)
                {
                    Ypos--;
                    if (Ypos >= -2)
                    {
                        Instantiate(Dirt, new Vector3(j, Ypos, i), Quaternion.identity);
                    }
                    else if (Ypos>=-4)
                    {
                        Instantiate(Stone, new Vector3(j, Ypos, i), Quaternion.identity);
                    }
                    else if (Ypos==-5)
                    {
                        Instantiate(Bedrock, new Vector3(j, Ypos, i), Quaternion.identity);
                    }
                }
            }
        }

    }
    float GeneratePerlinNoise(int x, int y)
    {
        return Mathf.PerlinNoise((x + Seed) * frequency, (y + Seed) * frequency);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
