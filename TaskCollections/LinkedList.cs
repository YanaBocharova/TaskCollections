using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCollections
{
	class LinkedList<T>
	{
		public Node<T> Head { get; private set; }
		public Node<T> Tail { get; private set; }
		public int Count { get; private set; }
		public void AddToTail(T value)
		{
			Node<T> node = new Node<T>();
			node.Value = value;

			if (isEmpty())
			{
				Head = Tail = node;
			}
			else
			{
				if (Tail == null)
				{
					Head = Tail = node;
				}
				else
				{
					Tail.Next = node;
					node.Previous = Tail;
					Tail = node;
				}
			}
			Count++;
		}
		public void AddToHead(T value)
		{
			Node<T> node = new Node<T>();
			node.Value = value;

			if (isEmpty())
			{
				Head = Tail = node;
			}
			else
			{
				if (Head == null)
				{
					Head = Tail = node;
				}
				else
				{
					node.Next = Head;
					Head.Previous = node;
					Head = node;
				}
			}
			Count++;
		}
		public void Insert(T value, int number)
		{
			if (number == 1)
			{
				AddToHead(value);
				Count++;
			}
			else
			{
				if (Head == null)
				{
					Head = new Node<T>();
				}
				Node<T> tmp = Head;
				int counter = 0;
				while (counter < number - 2 && tmp != null)
				{
					tmp = tmp.Next;
					counter++;
				}
				if (tmp != null)
				{
					Node<T> right = tmp.Next;
					Node<T> node = new Node<T>();
					node.Value = value;
					tmp.Next = node;
					node.Previous = tmp;
					node.Next = right;
					right.Previous = node;
					Count++;
				}
			}
		}
		public void Remove(Node<T> node)
		{
			if (node == Head)
				Head = Head.Next;
			else
			{
				Node<T> current = Head;

				while (current.Next != null)
				{
					if (current.Next == node)
					{
						if (current.Next.Next == null)
						{
							current.Next = null;
							break;
						}
						current.Next = current.Next.Next;
						break;
					}
					current = current.Next;
				}
			}
			Count--;
		}
		public void Remove(T val)
		{
			if (Head != null)
			{
				Node<T> current = Head;
				while (current.Next != null)
				{
					if (current.Value.Equals(val))
					{
						break;
					}
					current = current.Next;
				}
				Remove(current);
			}
		}
		public IEnumerator<T> GetEnumerator()
		{
			Node<T> current = Head;
			while (current != null)
			{
				yield return current.Value;
				current = current.Next;
			}
		}
		public void Clear()
		{
			Head = Tail = null;
			Count = 0;
		}
		bool isEmpty()
		{
			return Head == Tail == null;
		}
		public bool Contain(T val)
		{
			if (Head != null)
			{
				Node<T> current = Head;
				while (current.Next != null)
				{
					if (current.Value.Equals(val))
					{
						return true;
					}
					current = current.Next;
				}
			}
			return false;
		}
	}
}
