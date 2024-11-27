/*using UnityEngine;

public class PlaneToCircle : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        Bounds bounds = mesh.bounds;
        float maxExtent = Mathf.Max(bounds.extents.x, bounds.extents.z);

        for (int i = 0; i < vertices.Length; i++)
        {
            float x = vertices[i].x;
            float z = vertices[i].z;
            float distance = Mathf.Sqrt(x * x + z * z);

            if (distance > 0)
            {
                vertices[i] = new Vector3(x / distance, vertices[i].y, z / distance) * maxExtent;
            }
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}
*/