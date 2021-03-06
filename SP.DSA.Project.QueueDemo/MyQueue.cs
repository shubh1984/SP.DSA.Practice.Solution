﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.QueueDemo
{
    public class MyQueueDemo
    {
        public static void MyQueueDemoStart()
        {
            MyQueue queue = new MyQueue(1000);
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);

            Console.WriteLine("dequed :" + queue.Dequeue());
        }
    }
    public class MyQueue
    {
        int Front, Rear;
        int Capacity;
        int[] Arr;

        public int Size { get; set; }
        public MyQueue(int capacity)
        {
            this.Capacity = capacity;
            this.Front = this.Size = 0;
            this.Rear = this.Capacity - 1;
            this.Arr = new int[this.Capacity];
        }


        public bool isFull()
        {
            return this.Size == this.Capacity;
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }


        public void Enqueue(int val)
        {
            if (isFull())
                throw new Exception("Queue is Full.");
            this.Rear = (this.Rear + 1) % this.Capacity;
            this.Arr[this.Rear] = val;
            this.Size++;
            Console.WriteLine(val + "item isnserted.");
        }
        public int Dequeue()
        {
            if (IsEmpty())
                throw new Exception("Queue is empty.");
            int item = Arr[this.Front];
            this.Front = (this.Front + 1) % this.Capacity;
            this.Size--;
            return item;
        }
    }
}
