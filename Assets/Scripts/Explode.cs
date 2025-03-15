using UnityEngine;

public class Explode : MonoBehaviour
{
    public int cubesPerAxis = 8;
    public float delay = 1f;
    public float force = 300f;
    public float radius = 2f;
    public Color cubeColor = Color.white;

    private void Start()
    {
        

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        string otherObjectName = collision.gameObject.name;
        Debug.Log("THADWIDAID THIS CHOISDHAWDOHD:   " + otherObjectName);
        if (otherObjectName == "Body")
        {
            Debug.Log("THADWIDAID THIS CHOISDHAWDOHD");
            Invoke("Main", delay);
        }
    }

        


    void Main()
    {
        for (int x = 0; x < cubesPerAxis; x++)
        {
            for (int y = 0; y < cubesPerAxis; y++)
            {
                CreateCube(new Vector2(x, y));
            }
        }
        Destroy(gameObject);
    }

    void CreateCube(Vector2 coordinates)
    {
        GameObject cube = new GameObject("Cube2D");

        Mesh mesh = new Mesh();
        Vector3[] vertices = {
            new Vector3(-0.5f, -0.5f, 0),
            new Vector3(0.5f, -0.5f, 0),
            new Vector3(0.5f, 0.5f, 0),
            new Vector3(-0.5f, 0.5f, 0)
        };
        int[] triangles = { 0, 2, 1, 0, 3, 2 };
        Vector2[] uv = {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1)
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;

        MeshFilter meshFilter = cube.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        Material material = new Material(Shader.Find("Sprites/Default"));
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, cubeColor);
        texture.Apply();
        material.mainTexture = texture;

        MeshRenderer meshRenderer = cube.AddComponent<MeshRenderer>();
        meshRenderer.material = material;

        cube.transform.localScale = transform.localScale / cubesPerAxis;

        Vector2 firstCube = transform.position - (Vector3)transform.localScale / 2 + (Vector3)cube.transform.localScale / 2;
        cube.transform.position = firstCube + Vector2.Scale(coordinates, cube.transform.localScale);

        Rigidbody2D rb = cube.AddComponent<Rigidbody2D>();
        BoxCollider2D bc = cube.AddComponent<BoxCollider2D>();

        // Calculate the direction and distance from the explosion center
        Vector2 explosionDirection = (Vector2)cube.transform.position - (Vector2)transform.position;
        float explosionDistance = explosionDirection.magnitude;

        // Apply force based on distance, so closer cubes get more force
        if (explosionDistance < radius)
        {
            float explosionStrength = force * (1 - (explosionDistance / radius)); // Closer = stronger
            rb.AddForce(explosionDirection.normalized * explosionStrength);
        }
    }
}