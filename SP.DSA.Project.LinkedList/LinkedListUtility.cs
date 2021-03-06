﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LinkedList
{
    public class LinkedListUtility
    {
        public LinkNode intersectin(LinkNode head1, LinkNode head2)
        {
            LinkNode l1 = head1, l2 = head2;
            while (l1 != l2)
            {
                l1 = l1 != null ? l1.Next : head2;
                l2 = l2 != null ? l2.Next : head1;
            }
            return l1;
        }

        public void DetectAndRemoveLoop(LinkNode head)
        {
            if (head == null && head.Next == null)
            {
                return;
            }

            LinkNode slow = head;
            LinkNode fast = head;
            bool isLoop = false;

            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
                if (fast == slow)
                {
                    isLoop = true;
                    break;
                }
            }

            if (isLoop)
            {
                slow = head;
                while (slow.Next != fast.Next)
                {
                    slow = slow.Next;
                    fast = fast.Next;
                }
                fast.Next = null;
            }
        }
        public static void MergeTwoSorted()
        {
            LinkNode h1 = null;
            LinkNode h2 = null;
            LinkNode merged = MergeSorted(h1, h2);
        }

        private static LinkNode MergeSortedRecursion(LinkNode h1, LinkNode h2)
        {
            if (h1 == null) return h2;
            if (h2 == null) return h1;
            if (h1.Val <= h2.Val)
            {
                h1.Next = MergeSortedRecursion(h1.Next, h2);
                return h1;
            }
            else
            {
                h2.Next = MergeSortedRecursion(h1, h2.Next);
                return h2;
            }
        }
        private static LinkNode MergeSorted(LinkNode h1, LinkNode h2)
        {
            LinkNode dummyHead = new LinkNode(0);
            LinkNode curr = dummyHead;
            while (h1 != null && h2 != null)
            {
                if (h1 == null)
                {
                    curr.Next = h2;
                    break;
                }
                if (h2 == null)
                {
                    curr.Next = h1;
                    break;
                }

                if (h1.Val <= h2.Val)
                {
                    curr.Next = h1;
                    h1 = h1.Next;
                }
                else
                {
                    curr.Next = h2;
                    h2 = h2.Next;
                }

                curr = curr.Next;
            }
            return dummyHead.Next;
        }

        public static void LinkedListUtilityDemo()
        {
            AdditionOfTwoListDemo();
        }

        private static void AdditionOfTwoListDemo()
        {
            LinkNode h1 = new LinkNode(2);
            h1.Next = new LinkNode(3);
            h1.Next.Next = new LinkNode(4);
            h1.Next.Next.Next = new LinkNode(4);
            Console.WriteLine("head 1");
            Traverse(h1);

            LinkNode h2 = new LinkNode(3);
            h2.Next = new LinkNode(4);
            h2.Next.Next = new LinkNode(5);
            h2.Next.Next.Next = new LinkNode(5);
            Console.WriteLine("head 2");
            Traverse(h2);

            LinkNode result = GetSum(h1, h2);
            Traverse(result);

            //ReverseList(h1);
            //Console.WriteLine("head 1");
            //Traverse(h1);

            //ReverseList(h2);
            //Console.WriteLine("head 2");
            //Traverse(h2);

            LinkNode reverseresult = GetSumReverse(h1, h2);
            Traverse(reverseresult);
        }

        private static LinkNode GetSumReverse(LinkNode h1, LinkNode h2)
        {
            if (h1 == null) return h2;
            if (h2 == null) return h1;
            h1 = ReverseList(h1);
            h2 = ReverseList(h2);
            return GetSum(h1, h2);
        }

        private static LinkNode ReverseList(LinkNode head)
        {
            LinkNode currNode = head, prev = null, next = null;

            while (currNode != null)
            {
                next = currNode.Next;
                currNode.Next = prev;
                prev = currNode;
                currNode = next;
            }
            head = prev;
            return head;
        }

        private static LinkNode GetSum(LinkNode h1, LinkNode h2)
        {
            LinkNode dummyNode = new LinkNode(0);
            LinkNode sumNode = null;
            sumNode = dummyNode;

            LinkNode currH1 = h1;
            LinkNode currH2 = h2;
            int rem = 0, sum = 0;

            while (currH1 != null || currH2 != null)
            {
                int digit1 = h1 == null ? 0 : currH1.Val;
                int digit2 = h2 == null ? 0 : currH2.Val;
                sum = digit1 + digit2 + rem;

                sumNode.Next = new LinkNode(sum % 10);
                sumNode = sumNode.Next;
                rem = sum / 10;
                //move to next node.
                if (currH1 != null)
                    currH1 = currH1.Next;
                if (currH2 != null)
                    currH2 = currH2.Next;
            }
            if (rem > 0)
                sumNode.Next = new LinkNode(rem);
            return dummyNode.Next;
        }

        private static void Traverse(LinkNode head)
        {
            Console.WriteLine();
            LinkNode currNode = head;
            while (currNode != null)
            {
                Console.Write(currNode.Val + " ");
                currNode = currNode.Next;
            }
            Console.WriteLine();
        }
    }
}
