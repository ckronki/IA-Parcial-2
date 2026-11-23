using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Node : MonoBehaviour
{
    List<Node> _neighbors = new List<Node>();
    int _x, _z;
    Grid _grid;

    public float Cost {  get; private set; }
    public bool Block { get; private set; }

    [SerializeField] TextMeshProUGUI _costText;
    [SerializeField] Material _baseMaterial, _blockMaterial, _startMaterial, _goalMaterial;
    [SerializeField] MeshRenderer _myMeshForMaterials;

    public void Initialize(Grid grid, int x, int z)
    {
        if (_myMeshForMaterials == null) _myMeshForMaterials = GetComponent<MeshRenderer>();
        if (_costText == null) _costText = GetComponentInChildren<Canvas>().GetComponentInChildren<TextMeshProUGUI>();

        grid = _grid;
        _x = x;
        _z = z;
        Cost = 1;

        _costText.text = Cost.ToString();
        _myMeshForMaterials.material = _baseMaterial;
    }

    void ResetNode()
    {

    }

    public List<Node> GetNeighbors
    {
        get
        {
            if (_neighbors.Count > 0) return _neighbors;


            var leftNode = _grid.GetNode(_x - 1, _z);
            if (leftNode != null) _neighbors.Add(leftNode);

            var rightNode = _grid.GetNode(_x + 1, _z);
            if (rightNode != null) _neighbors.Add(rightNode);

            var upNode = _grid.GetNode(_x, _z + 1);
            if (upNode != null) _neighbors.Add(upNode);

            var downNode = _grid.GetNode(_x, _z - 1);
            if (downNode != null) _neighbors.Add(downNode);

            return _neighbors;
        }
    }
}
