using UnityEngine;
using UnityEngine.Tilemaps;

public class GridSelector : MonoBehaviour
{
    [SerializeField] private Tilemap _groundTilemap;
    [SerializeField] private Tilemap _highlightTilemap;
    [SerializeField] private TileBase _highlightPrefab;

    private Camera _camera;
    private Vector3Int _currentHoverCell;
    
    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 mouseWorldPosition =  _camera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        
        Vector3Int cellPosition =  _groundTilemap.WorldToCell(mouseWorldPosition);

        if (_groundTilemap.HasTile(cellPosition))
        {
            if (_currentHoverCell != cellPosition)
            {
                _currentHoverCell = cellPosition;
                
                UpdateHightlight(_currentHoverCell);
            }
        }
    }

    private void UpdateHightlight(Vector3Int cellPosition)
    {
        _highlightTilemap.ClearAllTiles();
        _highlightTilemap.SetTile(cellPosition, _highlightPrefab);
    }
}