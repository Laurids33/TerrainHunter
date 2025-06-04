using UnityEngine;

public class Landschaft : MonoBehaviour
{
    void Start()
    {
        TerrainData terrainDaten = GetComponent<Terrain>().terrainData;
        int aufloesung = terrainDaten.heightmapResolution;

        float[,] hMap = new float[aufloesung, aufloesung];
        float stufe = 0.003f;

        int[,] faktor = new int[aufloesung, aufloesung];
        int links, unten;

        for (int z = 0; z < aufloesung; z++)
        {
            for (int x = 0; x < aufloesung; x++)
            {
                if (z == 0 && x == 0)
                {
                    faktor[z, x] = 5;
                }
                else if (z == 0)
                {
                    links = faktor[z, x - 1];
                    faktor[z, x] = Random.Range(links - 1, links + 2);
                }
                else if (x == 0)
                {
                    unten = faktor[z - 1, x];
                    faktor[z, x] = Random.Range(unten - 1, unten + 2);
                }
                else
                {
                    links = faktor[z, x - 1];
                    unten = faktor[z - 1, x];
                    if (links == unten)
                    {
                        faktor[z, x] = Random.Range(links - 1, links + 2);
                    }
                    else if (links > unten)
                    {
                        faktor[z, x] = Random.Range(unten, links + 1);
                    }
                    else
                    {
                        faktor[z, x] = Random.Range(links, unten + 1);
                    }
                }

                if (faktor[z, x] < 0)
                {
                    faktor[z, x] = 0;
                }
                hMap[z, x] = faktor[z, x] * stufe;
            }
        }

        terrainDaten.SetHeights(0, 0, hMap);
    }
}
