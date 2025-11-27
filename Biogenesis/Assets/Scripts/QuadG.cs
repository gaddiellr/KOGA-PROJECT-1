using UnityEngine;

public class GrassQuadifier : MonoBehaviour
{
    public Terrain terrain;            // The terrain object
    public float quadSize = 10f;       // Size of each "quad" (distance between grass clusters)
    public int detailLayerIndex = 0;   // The index of the detail layer (e.g., grass texture or mesh)

    void Start()
    {
        QuadifyPaintedGrass();
    }

    void QuadifyPaintedGrass()
    {
        TerrainData terrainData = terrain.terrainData;
        int width = terrainData.detailWidth;
        int height = terrainData.detailHeight;

        // Get the current detail layer data (grass placement)
        int[,] detailLayer = terrainData.GetDetailLayer(0, 0, width, height, detailLayerIndex);

        // Loop through the detail layer and adjust the placement to form a grid pattern
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Create a grid-like pattern by checking if we're at a multiple of quadSize
                if ((x % (int)quadSize == 0) && (y % (int)quadSize == 0))
                {
                    // Preserve existing grass or set new grass at this location
                    // Only set the detail to 1 (place grass) if there's already grass, or add it at grid positions
                    if (detailLayer[x, y] == 0) // Only set if no grass is already there
                    {
                        detailLayer[x, y] = 1; // Set grass at this grid position
                    }
                }
            }
        }

        // Apply the modified detail layer back to the terrain
        terrainData.SetDetailLayer(0, 0, detailLayerIndex, detailLayer);
    }
}