using UnityEngine;

public class FlipNormals : MonoBehaviour
{
    void Awake()
    {
        InvertSphere();
    }

    void InvertSphere()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        
        if (meshFilter == null || meshFilter.sharedMesh == null)
        {
            Debug.LogError("MeshFilter or mesh not found on the object.");
            return;
        }

        Vector3[] normals = meshFilter.mesh.normals;
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = -normals[i];
        }
        meshFilter.sharedMesh.normals = normals;

        int[] triangles = meshFilter.sharedMesh.triangles;
        for (int i = 0; i < triangles.Length; i += 3)
        {
            int t = triangles[i];
            triangles[i] = triangles[i + 2];
            triangles[i + 2] = t;
        }
        meshFilter.sharedMesh.triangles = triangles;
    }
}