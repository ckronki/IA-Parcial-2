using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] Node _prefabNode;
    [SerializeField] int _width, _height;
    Node[,] _grid;

    private void Start()
    {
        _grid = new Node[_width, _height];

        for (int w = 0; w < _width; w++)
        {
            for (int h = 0; h < _height; h++)
            {
                var node = Instantiate(_prefabNode);
                node.transform.position = new Vector3(w, 0, h);
                node.Initialize(this, w, h);

                _grid[w, h] = node;
            }
        }

    }

    public Node GetNode(int x, int z)
    {
        if (x < 0 || z < 0 || x >= _width || z >= _height)
            return null;

        return _grid[x, z];
    }
}
