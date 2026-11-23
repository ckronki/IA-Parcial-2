using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class Pathfinding : MonoBehaviour
{
    public List<Node> CalculateBFS(Node startingNode, Node goalNode)
    {
        var frontier = new Queue<Node>();
        frontier.Enqueue(startingNode);
        var cameFrom = new Dictionary<Node, Node>();

        while (frontier.Count > 0)
        {
            var current = frontier.Dequeue();

            if (current == goalNode)
            {
                List<Node> path = new List<Node>();

                while (current != startingNode)
                {
                    path.Add(current);
                    current = cameFrom[current];
                }
                path.Add(current);
                path.Reverse();

                return path;
            }

            foreach (var node in current.GetNeighbors)
            {
                if (!cameFrom.ContainsKey(node))
                {
                    frontier.Enqueue(node);
                    cameFrom.Add(node, current);
                }
            }
        }

        return new List<Node>();
    }

    public List<Node> CalculateDijkstra(Node startingNode, Node goalNode)
    {
        var frontier = new PriorityQueue<Node>();
        frontier.Enqueue(startingNode, 0);
        var cameFrom = new Dictionary<Node, Node>();
        var costSoFar = new Dictionary<Node, float>();

        costSoFar.Add(startingNode, 0);

        while (frontier.Count > 0)
        {
            var current = frontier.Dequeue();

            if (current == goalNode)
            {
                List<Node> path = new List<Node>();

                while (current != startingNode)
                {
                    path.Add(current);
                    current = cameFrom[current];
                }
                path.Add(current);
                path.Reverse();

                return path;
            }

            foreach (var nextNode in current.GetNeighbors)
            {
                float newCost = costSoFar[current] + nextNode.Cost;

                if (!cameFrom.ContainsKey(nextNode))
                {
                    frontier.Enqueue(nextNode);
                    cameFrom.Add(nextNode, current);
                }
            }
        }

        return new List<Node>();
    }
}
