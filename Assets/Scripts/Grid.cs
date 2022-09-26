using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    public float Size = 0.5f;

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / Size);
        int yCount = Mathf.RoundToInt(position.y / Size);
        int zCount = Mathf.RoundToInt(position.z / Size);

        Vector3 result = new Vector3(
            (float)xCount * Size,
            (float)yCount * Size,
            (float)zCount * Size
        );

        result += transform.position;

        return result;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        for (float x = 0; x < 40; x += Size)
        {
            for (float z = 0; z < 40; z += Size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawSphere(point, 0.02f);
            }
        }
    }
}
