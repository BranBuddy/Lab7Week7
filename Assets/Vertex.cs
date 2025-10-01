using UnityEngine;

public class Vertex : MonoBehaviour
{
    private Vector3 translation = new Vector3(2, 2, 2);
    private Quaternion rotation = Quaternion.Euler(new Vector3(90, 0 , 0));
    private Vector3 scale = Vector3.one;

    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        Mesh mesh = meshFilter.mesh;

        Vector3[] vertices = mesh.vertices;

        Matrix4x4 matrix = Matrix4x4.TRS(translation, rotation, scale);

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = matrix.MultiplyPoint3x4(vertices[i]);
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }
}
