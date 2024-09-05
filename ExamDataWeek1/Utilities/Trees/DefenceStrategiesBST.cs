using ExamDataWeek1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExamDataWeek1.Service.ThreatUtils;


namespace ExamDataWeek1.Service.Trees
{
    internal class DefenceStrategiesBST
    {
        private TreeNode? _root;

        public void Insert(DefenseModel defenseStrategy)
        {
            _root = RecursiveInsert(_root, defenseStrategy);
        }

        private TreeNode? RecursiveInsert(TreeNode? node, DefenseModel defenseStrategy)
        {
            if (node == null || node.DefenseStrategy == null)
            {
                return new() { DefenseStrategy = defenseStrategy };
            }
            if (node.DefenseStrategy <= defenseStrategy)
            {
                node.Right = RecursiveInsert(node.Right, defenseStrategy);
            }
            else
            {
                node.Left = RecursiveInsert(node.Left, defenseStrategy);
            }
            return node;
        }

        public DefenseModel? SearchForDefense(ThreatModel threat)
        {
            int severity = EvaluateSeverity(threat);
            return RecursiveSearchForDefense(_root, severity);
        }

        private DefenseModel? RecursiveSearchForDefense(TreeNode? node, int severity)
        {
            if (node == null || node.DefenseStrategy == null)
            {
                return null;
            }
            if (node.DefenseStrategy.MinSeverity == severity || node.DefenseStrategy.MaxSeverity == severity)
            {
                return node.DefenseStrategy;
            }

            DefenseModel? leftResult = RecursiveSearchForDefense(node.Left, severity);
            if (leftResult != null)
            {
                return leftResult;
            }
            return RecursiveSearchForDefense(node.Right, severity);
        }

        public int? FindMinSeverity()
        {
            if (_root == null)
            {
                return null;
            }

            TreeNode? tempNode = _root;
            while (tempNode.Left != null)
            {
                tempNode = tempNode.Left;
            }
            return tempNode.DefenseStrategy!.MinSeverity;
        }

        public void PrintPreOrder() => PrintPreOrderRecursive(_root);

        private void PrintPreOrderRecursive(TreeNode? node, int level = 0)
        {
            if (node == null || node.DefenseStrategy == null) return;
            Console.WriteLine(new string(' ', level * 4) + $"[{node.DefenseStrategy.MinSeverity}, {node.DefenseStrategy.MaxSeverity}]");
            Console.WriteLine(new string(' ', level * 4) + "Defenses: " + string.Join(", ", node.DefenseStrategy.Defenses));
            PrintPreOrderRecursive(node.Left, level + 1);
            PrintPreOrderRecursive(node.Right, level + 1);
        }

        public void Balance()
        {
            List<DefenseModel> sortedList = BSTToList();  // Get the sorted list
            _root = RebuildTreeFromList(sortedList, 0, sortedList.Count - 1);  // Rebuild the tree
        }

        // Helper function to rebuild a balanced tree from the sorted list
        private TreeNode? RebuildTreeFromList(List<DefenseModel> sortedList, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;
            TreeNode node = new() { DefenseStrategy = sortedList[mid] };

            node.Left = RebuildTreeFromList(sortedList, start, mid - 1);
            node.Right = RebuildTreeFromList(sortedList, mid + 1, end);

            return node;
        }

        // Converts the BST to a sorted list using in-order traversal
        private List<DefenseModel> BSTToList()
        {
            List<DefenseModel> list = new();
            return InOrderTraversal(_root, list);
        }

        private List<DefenseModel> InOrderTraversal(TreeNode? node, List<DefenseModel> list)
        {
            if (node == null || node.DefenseStrategy == null)
                return list;

            InOrderTraversal(node.Left, list);
            list.Add(node.DefenseStrategy);
            InOrderTraversal(node.Right, list);

            return list;
        }
    }
}
