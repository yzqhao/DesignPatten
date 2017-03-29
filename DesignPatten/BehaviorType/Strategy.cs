using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.BehaviorType
{
    /*
    //策略
    public static void testStrategy()
    {
        SortedList studentRecords = new SortedList();
        studentRecords.Add("Samual");
        studentRecords.Add("Jimmy");
        studentRecords.Add("Sandra");
        studentRecords.Add("Anna");
        studentRecords.Add("Vivek");

        studentRecords.SetSortStrategy(new QuickSort());
        studentRecords.Sort();
        studentRecords.Display();

        Console.Read();
    }
     */

    // "Strategy"
    abstract class SortStrategy
    {
        abstract public void Sort(ArrayList list);
    }

    // "ConcreteStrategy"
    class QuickSort : SortStrategy
    {
        public override void Sort(ArrayList list)
        {
            list.Sort(); // Default is Quicksort
            Console.WriteLine("QuickSorted list ");
        }
    }

    // "ConcreteStrategy"
    class ShellSort : SortStrategy
    {
        public override void Sort(ArrayList list)
        {
            //list.ShellSort();
            Console.WriteLine("ShellSorted list ");
        }
    }

    // "ConcreteStrategy"
    class MergeSort : SortStrategy
    {
        public override void Sort(ArrayList list)
        {
            //list.MergeSort();
            Console.WriteLine("MergeSorted list ");
        }
    }

    // "Context"
    class SortedList
    {
        private ArrayList list = new ArrayList();
        private SortStrategy sortstrategy;

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this.sortstrategy = sortstrategy;
        }

        public void Sort()
        {
            sortstrategy.Sort(list);
        }

        public void Add(string name)
        {
            list.Add(name);
        }

        public void Display()
        {
            foreach (string name in list)
                Console.WriteLine(" " + name);
        }
    }
}
