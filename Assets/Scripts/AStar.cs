using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Node parent = null;
    public int g = 0;
    public int f = 0;
    public int h = 0;
    public int x = 0;
    public int y = 0;
    public int t = 0;
    public List<Node> neighbors = new();
    public void LoadNodes(Node[,] data)
    {
        if (x > 0)
        {
            Node neighbor = data[y, x - 1];
            if (neighbor.t == 0)
            {
                neighbors.Add(neighbor);
            }
        }
        if (x < 9)
        {
            Node neighbor = data[y, x + 1];
            if (neighbor.t == 0)
            {
                neighbors.Add(neighbor);
            }
        }
        if (y > 0)
        {
            Node neighbor = data[y - 1, x];
            if (neighbor.t == 0)
            {
                neighbors.Add(neighbor);
            }
        }
        if (y < 9)
        {
            Node neighbor = data[y + 1, x];
            if (neighbor.t == 0)
            {
                neighbors.Add(neighbor);
            }
        }
    }
}
public class AStar : MonoBehaviour
{
    public static AStar Instance;
    public Node[,] nodes;
    List<Node> openSet = new();
    public List<Node> closeSet = new();
    public List<Node> path = new();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadNodes()
    {
        nodes = new Node[10, 10];
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                Node node = new()
                {
                    x = x,
                    y = y,
                    t = y == 2 && x == 5 ? 1 : y == 2 && x == 4 ? 1 : y == 2 && x == 6 ? 1 : 0,
                };
                nodes[y, x] = node;
            }
        }

        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                nodes[y, x].LoadNodes(nodes);
            }
        }
    }
    public void FindPath(Node start, Node end)
    {
        closeSet.Clear();
        openSet.Clear();
        openSet.Add(start);

        while (openSet.Count > 0)
        {
            int winner = 0;
            for (int i = 0; i < openSet.Count; i++)
            {
                if (openSet[i].f < openSet[winner].f)
                {
                    winner = i;
                }
            }
            Node current = openSet[winner];
            closeSet.Add(current);
            openSet.Remove(openSet[winner]);
            if (current == end)
            {
                Node n = current;
                Debug.Log("Completed");
                while (n != null)
                {
                    path.Add(n);
                    n = n.parent;
                }
                path.Reverse();
                break;
            }
            else
            {
                for (int j = 0; j < current.neighbors.Count; j++)
                {
                    Node neighbor = current.neighbors[j];
                    if (!closeSet.Contains(neighbor))
                    {
                        int tempG = current.g + Mathf.Abs(neighbor.x - current.x) + Mathf.Abs(neighbor.y - current.y);
                        neighbor.g = tempG;
                        neighbor.h = Mathf.Abs(neighbor.x - end.x) + Mathf.Abs(neighbor.y - end.y);
                        neighbor.f = neighbor.h + neighbor.g;
                        neighbor.parent = current;
                        openSet.Add(neighbor);
                        closeSet.Add(neighbor);
                    }
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (nodes != null)
        {
            foreach (Node c in nodes)
            {
                Gizmos.color = c.t == 1 ? Color.red : Color.green;
                Gizmos.DrawWireCube(new(c.x, c.y), Vector3.one);
            }
        }

        foreach (Node c in path)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(new(c.x, c.y), Vector3.one / 2);
        }
    }
}
