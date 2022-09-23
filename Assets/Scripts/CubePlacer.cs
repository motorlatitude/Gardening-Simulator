using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    [SerializeField]
    private GameObject highlightedCube;

    private Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = FindObjectOfType<Grid>();
        highlightedCube.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hitInfo)) {
                PlaceCubeNear(hitInfo.point);
            }
        }
        else {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hitInfo)) {
                moveHighlightedCube(hitInfo.point);
            }
        }
    }

    private void moveHighlightedCube(Vector3 mousePoint) {
        Vector3 nearestPoint = grid.GetNearestPointOnGrid(mousePoint);
        nearestPoint.y = 0.05f;
        highlightedCube.transform.position = nearestPoint;
        highlightedCube.SetActive(true);
    }

    private void PlaceCubeNear(Vector3 clickPoint) {
        Vector3 nearestPoint = grid.GetNearestPointOnGrid(clickPoint);

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = nearestPoint;
    }
}
