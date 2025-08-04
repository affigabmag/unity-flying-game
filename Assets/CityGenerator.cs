using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    [Header("City Settings")]
    public int citySize = 30;           // 30x30 grid for full city
    public float buildingSpacing = 6f;   // Crowded city streets
    public float minHeight = 3f;         // Shortest buildings
    public float maxHeight = 15f;        // Tallest buildings

    [Header("Commercial Building Materials")]
    public Material glassTowerMaterial;   // Drag GlassTower material here
    public Material concreteMaterial;     // Drag Concrete material here
    public Material retailMaterial;       // Optional: for retail buildings

    void Start()
    {
        GenerateCity();
    }

    void GenerateCity()
    {
        // Create parent object for organization
        GameObject cityParent = new GameObject("Generated City");
        cityParent.transform.parent = this.transform;

        for (int x = 0; x < citySize; x++)
        {
            for (int z = 0; z < citySize; z++)
            {
                // Skip center area for flying space
                if (x > citySize / 2 - 3 && x < citySize / 2 + 3 &&
                    z > citySize / 2 - 3 && z < citySize / 2 + 3) continue;

                CreateCommercialBuilding(x, z, cityParent.transform);
            }
        }

        Debug.Log($"Commercial city generated with {citySize * citySize - 36} buildings!");
    }

    void CreateCommercialBuilding(int x, int z, Transform parent)
    {
        // Create cube for building
        GameObject building = GameObject.CreatePrimitive(PrimitiveType.Cube);
        building.name = $"Building_{x}_{z}";
        building.transform.parent = parent;

        // Random height for variety
        float height = Random.Range(minHeight, maxHeight);

        // Determine building type based on height
        BuildingType buildingType = GetBuildingType(height);

        // Position building
        Vector3 position = new Vector3(
            (x - citySize / 2) * buildingSpacing,
            height / 2f,  // Ground the building
            (z - citySize / 2) * buildingSpacing
        );
        building.transform.position = position;

        // Scale based on building type
        Vector3 scale = GetBuildingScale(buildingType, height);
        building.transform.localScale = scale;

        // Apply appropriate material
        ApplyBuildingMaterial(building, buildingType);
    }

    BuildingType GetBuildingType(float height)
    {
        if (height >= 12f)
        {
            return BuildingType.GlassTower;     // Tall glass towers
        }
        else if (height >= 8f)
        {
            return BuildingType.OfficeBuilding; // Medium concrete offices
        }
        else if (height >= 5f)
        {
            return BuildingType.MixedUse;       // Mid-rise mixed use
        }
        else
        {
            return BuildingType.Retail;         // Low retail/shopping
        }
    }

    Vector3 GetBuildingScale(BuildingType type, float height)
    {
        switch (type)
        {
            case BuildingType.GlassTower:
                // Tall, narrow glass towers
                return new Vector3(2.5f, height, 2.5f);

            case BuildingType.OfficeBuilding:
                // Standard office buildings
                return new Vector3(3f, height, 3f);

            case BuildingType.MixedUse:
                // Wider mixed-use buildings
                return new Vector3(3.5f, height, 3.5f);

            case BuildingType.Retail:
                // Wide, low retail buildings
                return new Vector3(4f, height, 4f);

            default:
                return new Vector3(3f, height, 3f);
        }
    }

    void ApplyBuildingMaterial(GameObject building, BuildingType type)
    {
        Renderer renderer = building.GetComponent<Renderer>();

        switch (type)
        {
            case BuildingType.GlassTower:
                if (glassTowerMaterial != null)
                    renderer.material = glassTowerMaterial;
                break;

            case BuildingType.OfficeBuilding:
                if (concreteMaterial != null)
                    renderer.material = concreteMaterial;
                break;

            case BuildingType.MixedUse:
                // Randomly choose between concrete and glass for variety
                Material mixedMaterial = Random.Range(0f, 1f) > 0.5f ? concreteMaterial : glassTowerMaterial;
                if (mixedMaterial != null)
                    renderer.material = mixedMaterial;
                break;

            case BuildingType.Retail:
                // Use retail material if available, otherwise concrete
                Material retailMat = retailMaterial != null ? retailMaterial : concreteMaterial;
                if (retailMat != null)
                    renderer.material = retailMat;
                break;
        }
    }

    public enum BuildingType
    {
        GlassTower,      // 12+ floors - shiny blue glass
        OfficeBuilding,  // 8-12 floors - gray concrete
        MixedUse,        // 5-8 floors - mixed materials
        Retail           // 3-5 floors - wide retail/shopping
    }
}