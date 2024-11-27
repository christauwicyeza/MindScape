using UnityEngine;

public class PlaneToCircle : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            float x = vertices[i].x;
            float z = vertices[i].z;
            float distance = Mathf.Sqrt(x * x + z * z);
            if (distance > 0.5f) // Adjust threshold as needed
            {
                vertices[i] = vertices[i].normalized * 0.5f; // Normalize to make a circle
            }
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}
