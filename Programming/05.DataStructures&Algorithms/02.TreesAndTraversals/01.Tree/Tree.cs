/* You are given a tree of N nodes represented as a set of N-1 pairs 
 * of nodes (parent node, child node), each in the range (0..N-1).
 * Write a program to read the tree and find:
 * 1. the root node
 * 2. all leaf nodes
 * 3. all middle nodes
 * 4. the longest path in the tree
 * 5. all paths in the tree with given sum S of their nodes
 * 6. all subtrees with given sum S of their nodes
 * 
 * Input Example:
 * 7
 * 2 4
 * 3 2
 * 5 0
 * 3 5
 * 5 6
 * 5 1 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tree
{
    // private static int N = 0;
    // private static Node<int>[] nodes;

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        int N = int.Parse(Console.ReadLine());
        Node<int>[] nodes = new Node<int>[N];

        for (int i = 0; i < N; i++)
        {
            nodes[i] = new Node<int>(i);
        }

        // read the input
        for (int i = 1; i <= N - 1; i++)
        {
            string edgeAsString = Console.ReadLine();
            string[] edgeParts = edgeAsString.Split(' ');

            int parentId = int.Parse(edgeParts[0]);
            int childId = int.Parse(edgeParts[1]);

            // link the child to the parrent
            nodes[parentId].Children.Add(nodes[childId]);
            nodes[childId].HasParent = true;
        }

        // 1. Find the root
        Node<int> root = FindRoot(nodes);
        Console.WriteLine("The root of the tree is: {0}", root.Value);

        // 2. Find all leafs
        List<Node<int>> leaves = FindAllLeaves(nodes);

        Console.Write("Leaves:");
        foreach (var leaf in leaves)
        {
            Console.Write(" {0}", leaf.Value);
        }
        Console.WriteLine();

        // 3. Find all middle nodes
        List<Node<int>> middleNodes = FindAllMiddleNodes(nodes);

        Console.Write("Middle nodes:");
        foreach (var node in middleNodes)
        {
            Console.Write(" {0}", node.Value);
        }
        Console.WriteLine();

        // 4. Find the longest path from root
        int longestPath = FindLongestPath(FindRoot(nodes));
        Console.WriteLine("Longest path is: {0}", longestPath);

        // 5.* Find all paths in the tree with given sum S of their nodes
        int sum = 9;
        var pathsWithSum = FindAllPathsWithGivenSum(root, sum);
        Console.WriteLine("Paths in the tree with sum of" +
                                " their nodes equal to {0} are: ", sum);
        PrintPath(pathsWithSum);

        // 6.* Find all subtrees with given sum S of their nodes
        sum = 6;
        pathsWithSum = FindAllPathsWithGivenSum(root, sum);
        Console.WriteLine("Subtrees with sum of" +
                                " their nodes equal to {0} are: ", sum);
        PrintPath(pathsWithSum);
    }    

    static Node<int> FindRoot(Node<int>[] nodes)
    {
        bool[] hasParent = new bool[nodes.Length];

        foreach (var node in nodes)
        {
            foreach (var child in node.Children)
            {
                hasParent[child.Value] = true;
            }
        }

        for (int i = 0; i < hasParent.Length; i++)
        {
            if (!hasParent[i])
            {
                return nodes[i];
            }
        }

        throw new ArgumentException("nodes", "The tree has no root");
    }

    private static List<Node<int>> FindAllLeaves(Node<int>[] nodes)
    {
        List<Node<int>> leaves = new List<Node<int>>();

        foreach (var node in nodes)
        {
            if (node.Children.Count == 0)
            {
                leaves.Add(node);
            }
        }

        return leaves;
    }

    private static List<Node<int>> FindAllMiddleNodes(Node<int>[] nodes)
    {
        List<Node<int>> middleNodes = new List<Node<int>>();

        foreach (var node in nodes)
        {
            if (node.HasParent && node.Children.Count > 0)
            {
                middleNodes.Add(node);
            }
        }

        return middleNodes;
    }

    private static int FindLongestPath(Node<int> root)
    {
        if (root.Children.Count == 0)
        {
            return 0;
        }

        int maxPath = 0;
        foreach (var node in root.Children)
        {
            maxPath = Math.Max(maxPath, FindLongestPath(node));
        }

        return maxPath + 1;
    }

    public static IList<List<Node<int>>> FindAllPathsWithGivenSum(Node<int> root, int sum)
    {
        var result = new List<List<Node<int>>>();

        var queue = new Queue<List<Node<int>>>();
        queue.Enqueue(new List<Node<int>> { root });

        while (queue.Count > 0)
        {
            var currentPath = queue.Dequeue();

            for (int i = 0; i < currentPath.Count - 1; i++)
            {
                var previousPath = currentPath.Skip(i).ToList();

                var previousPathSum = previousPath.Select(x => x.Value).Sum();

                if (previousPathSum == sum)
                {
                    result.Add(previousPath);
                }

                if (previousPathSum > sum)
                {
                    continue;
                }
            }

            foreach (var childNode in currentPath.Last().Children)
            {
                var nextPath = new List<Node<int>>(currentPath);
                nextPath.Add(childNode);

                queue.Enqueue(nextPath);
            }
        }

        return result;
    }

    private static void PrintPath(IList<List<Node<int>>> pathsWithSum)
    {
        if (pathsWithSum.Count != 0)
        {
            foreach (var path in pathsWithSum)
            {
                Console.WriteLine(string.Join(" ", path.Select(node => node.Value)));
            }
        }
        else
        {
            Console.WriteLine("There is not a path with the given sum");
        }
    }
}
