using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class BinarySearchTree
    {
        class Node
        {
            public readonly int Key;
            public readonly int Value;
            public Node Parent;
            public Node Left;
            public Node Right;

            public Node(int key, int value, Node parent = null)
            {
                Key = key;
                Value = value;
                Parent = parent;
            }

            public void Add(int key, int data)
            {
                if (key < Key)
                {
                    if (Left == null) Left = new Node(key, data, this);
                    else Left.Add(key, data);
                } else
                {
                    if (Right == null) Right = new Node(key, data, this);
                    else Right.Add(key, data);
                }
            }

            public Node Find(int key)
            {
                if (Key == key) return this;
                return key < Key ? Left?.Find(key): Right?.Find(key);
            }

            public int Count()
            {
                return 1 + (Left?.Count() ?? 0) + (Right?.Count() ?? 0);
            }

            public void ReplaceChild(Node? before, Node? after)
            {
                if (Left == before) Left = after;
                else if (Right == before) Right = after;
            }
        }

        private Node root;

        public void Add(int key, int data)
        {
            if (root == null) root = new Node(key, data);
            else root.Add(key, data);
        }

        public int Find(int key)
        {
            return root?.Find(key)?.Value ?? -1;
        }

        private Node FindNode(int key)
        {
            return root?.Find(key);
        }

        public void Remove(int key)
        {
            Node node = FindNode(key);
            Node replace;
            if (node == root)
            {
                if (node.Left != null)
                {
                    root = node.Left;
                    root.Parent = null;
                    
                } else if (node.Right != null)
                {

                }
                root = node.Left != null ? node.Left : node.Right;
            }
            else if (node.Left == null && node.Right == null)
            {
                node.Parent.ReplaceChild(node, null);
            }
            else if (node.Right == null)
            {
                replace = node.Left;
                replace.Parent = node.Parent;
                replace.Parent.ReplaceChild(node, replace);
            }
            else if (node.Right.Left == null)
            {
                replace = node.Right;
                replace.Parent = node.Parent;
                replace.Parent.ReplaceChild(node, replace);
                if (node.Left != null) node.Left.Parent = replace;
            }
            else
            {
                Node mostLeftNode = node.Right;
                while (mostLeftNode.Left != null) mostLeftNode = mostLeftNode.Left;
                replace = mostLeftNode;

                replace = node.Right;
                replace.Parent.Left = null;
                replace.Parent = node.Parent;
                replace.Parent.ReplaceChild(node, replace);
                if (node.Left != null) node.Left.Parent = replace;
                if (node.Right != null) node.Right.Parent = replace;
            }
        }

        public int Count()
        {
            return root?.Count() ?? 0;
        }
    }
}
