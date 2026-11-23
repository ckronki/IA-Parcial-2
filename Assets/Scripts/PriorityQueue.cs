using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue <T>
{
    Dictionary<T, float> _elements = new Dictionary<T, float>();

    public float Count {  get { return _elements.Count; } }

    public void Enqueue(T element, float cost)
    {
        if (!_elements.ContainsKey(element))
        {
            _elements.Add(element, cost);
        }
        else
        {
            _elements[element] = cost;
        }
    }

    public T Dequeue()
    {
        T minElement = default;
        float minCost = Mathf.Infinity;

        foreach (var element in _elements)
        {
            if (element.Value < minCost)
            {
                minElement = element.Key;
                minCost = element.Value;
            }
        }

        _elements.Remove(minElement);
        return minElement;
    }
}
