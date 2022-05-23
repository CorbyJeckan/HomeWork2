using HomeWork2;
using System;
using System.Collections.Generic;

namespace LinkedLists
{

    public class DoublyLinkedList : LinkedList
    {
       
        private readonly Node head = new Node();
        private readonly Node tail = new Node();

        public DoublyLinkedList()
        {
            head.NextNode = tail;
            tail.PrevNode = head;
        }

        public void AddNode(int value)
        {
            tail.PrevNode = new()
            {
                Value = value,
                PrevNode = tail.PrevNode
            };
        }

        public void AddNodeAfter(Node node, int value)
        {
            Node current = head.NextNode;
            while (current != tail && current != node)
            {
                current = current.NextNode;
            }
            if (current != tail)
            {
                current.NextNode = new()
                {
                    Value = value,
                    PrevNode = current,
                    NextNode = current.NextNode
                };
            }
            else
            {
                throw new ArgumentException("Такого Узла нет в списке.", nameof(node));
            }
        }

        public Node FindNode(int searchValue)
        {
            Node current = head.NextNode;
            while (current != tail && current.Value != searchValue)
            {
                current = current.NextNode;
            }
            if (current != tail)
            {
                return current;
            }
            else
            {
                return null;
            }
        }

        public int GetCount()
        {
            int count = 0;
            Node current = head.NextNode;
            while (current != tail)
            {
                current = current.NextNode;
                count++;
            }
            return count;
        }

        public void RemoveNode(int index)
        {
            int count = 0;
            Node current = head.NextNode;
            while (current != tail && count < index)
            {
                current = current.NextNode;
                count++;
            }
            if (count == index)
            {
                RemoveNode(current);
            }
            else
            {
                throw new ArgumentException("Узла с таким индексом нет в списке.", nameof(index));
            }
        }

        public void RemoveNode(Node node)
        {
            Node next = node.NextNode;
            Node prev = node.PrevNode;

            next.PrevNode = prev;
            prev.NextNode = next;

            // Можно не делать.  Но на всякий случай.
            node.NextNode = null;
            node.PrevNode = null;
        }
      
    }
    
     
}

namespace HomeWork2
{
    public class LinkedList
    {
    }
}