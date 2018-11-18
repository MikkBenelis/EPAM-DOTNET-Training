namespace Logic.Generic
{
    using System.Collections.Generic;

    public class BinarySearchTree<T>
    {
        #region Fields

        private Node root = null;
        private IComparer<T> _comparer;

        #endregion Fields

        #region Constructors

        /// <summary>Create BST instance</summary>
        public BinarySearchTree()
        {
            _comparer = Comparer<T>.Default;
        }

        /// <summary>Create BST instance</summary>
        /// <param name="comparer">Value comparer</param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        #endregion Constructors

        #region PublicAPI

        /// <summary>Insert node to BST</summary>
        /// <param name="value">Value of node</param>
        public void Insert(T value)
        {
            if (root == null)
            {
                root = new Node(value);
            }
            else
            {
                Insert(root, value);
            }
        }

        /// <summary>Preorder BST traversee</summary>
        public IEnumerable<T> PreorderTraversee()
        {
            foreach (T element in PreorderTraversee(root))
            {
                yield return element;
            }
        }

        /// <summary>Inorder BST traversee</summary>
        public IEnumerable<T> InorderTraversee()
        {
            foreach (T element in InorderTraversee(root))
            {
                yield return element;
            }
        }

        /// <summary>Postorder BST traversee</summary>
        public IEnumerable<T> PostorderTraversee()
        {
            foreach (T element in PostorderTraversee(root))
            {
                yield return element;
            }
        }

        #endregion PublicAPI

        #region PrivateAPI

        /// <summary>Insert node to BST</summary>
        /// <param name="node">Node to insert</param>
        /// <param name="value">Value of node</param>
        /// <param name="comparer">Value comparer</param>
        private Node Insert(Node node, T value)
        {
            if (node == null)
            {
                node = new Node(value);
            }
            else
            {
                if (_comparer.Compare(value, node.Value) < 0)
                {
                    node.Left = Insert(node.Left, value);
                }
                else if (_comparer.Compare(value, node.Value) > 0)
                {
                    node.Right = Insert(node.Right, value);
                }
            }

            return node;
        }

        /// <summary>Preorder BST traversee</summary>
        private IEnumerable<T> PreorderTraversee(Node node)
        {
            if (node == null)
            {
                yield break;
            }

            yield return node.Value;

            foreach (var element in PreorderTraversee(node.Left))
            {
                yield return element;
            }

            foreach (var element in PreorderTraversee(node.Right))
            {
                yield return element;
            }
        }

        /// <summary>Inorder BST traversee</summary>
        private IEnumerable<T> InorderTraversee(Node node)
        {
            if (node == null)
            {
                yield break;
            }

            foreach (var element in InorderTraversee(node.Left))
            {
                yield return element;
            }

            yield return node.Value;

            foreach (var element in InorderTraversee(node.Right))
            {
                yield return element;
            }
        }

        /// <summary>Postorder BST traversee</summary>
        private IEnumerable<T> PostorderTraversee(Node node)
        {
            if (node == null)
            {
                yield break;
            }

            foreach (var element in PostorderTraversee(node.Left))
            {
                yield return element;
            }

            foreach (var element in PostorderTraversee(node.Right))
            {
                yield return element;
            }

            yield return node.Value;
        }

        #endregion PrivateAPI

        public class Node
        {
            public Node(T value)
            {
                Value = value;
                Left = null;
                Right = null;
            }

            public T Value { get; private set; }

            public Node Left { get; set; }

            public Node Right { get; set; }
        }
    }
}
