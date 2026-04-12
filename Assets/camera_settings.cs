using UnityEngine;

public class camera_setting : MonoBehaviour
{
    public float gridCellSize = 1f;        // size of one grid cell in world units
    public int gridColumns = 16;           // how many columns visible
    public int gridRows = 10;             // how many rows visible

    void Start()
    {
        Camera cam = Camera.main;
        cam.orthographic = true;

        // Set height to fit exactly N rows
        cam.orthographicSize = (gridRows * gridCellSize) / 2f;

        // Force aspect to match grid dimensions exactly
        cam.aspect = (float)gridColumns / (float)gridRows;
    }
}
