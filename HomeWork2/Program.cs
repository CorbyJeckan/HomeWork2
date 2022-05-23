using System;
using System.Collections;
using System.Configuration;
using System.Data;


namespace LinkedLists
{
    /// <summary>Класс узла двусвязного списка.</summary>
    public class Node
    {
        /// <summary>Значение узла.</summary>
        public int Value { get; set; }

        /// <summary>Следующий Узел.</summary>
        public Node NextNode { get; set; }

        /// <summary>Предыдущий узел.</summary>
        public Node PrevNode { get; set; }
    }
    static public class NodeFactory
    {

    }

    
}