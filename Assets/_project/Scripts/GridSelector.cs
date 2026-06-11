using UnityEngine;
using UnityEngine.Tilemaps;

public class GridSelector : MonoBehaviour
{
    [SerializeField] private Tilemap _groundTilemap;

    private Camera _camera;
    private Color _highlightColor = new(1f, 1f, 0.5f, 0.7f);
    private Color _originalColor;
    private TileBase _lastHighlightTile;
    private Vector3Int _currentHighlightCell;

    private void Start()
    {
        _camera = Camera.main;
        _originalColor = Color.white;
        _currentHighlightCell = new Vector3Int(-999, -999, -999);
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        Vector3Int cellPosition = _groundTilemap.WorldToCell(mouseWorldPosition);

        if (_currentHighlightCell != cellPosition)
        {
            if (_groundTilemap.HasTile(_currentHighlightCell))
            {
                _groundTilemap.SetColor(_currentHighlightCell, _originalColor);
            }

            if (_groundTilemap.HasTile(cellPosition))
            {
                _groundTilemap.SetColor(cellPosition, _highlightColor);
                _currentHighlightCell = cellPosition;
            }
            else
            {
                _currentHighlightCell = new Vector3Int(-999, -999, -999);
            }
        }
    }
}