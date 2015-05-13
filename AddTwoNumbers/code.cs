using System;
using System.Collections.Generic;
using System.Linq;
namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
           //543+654=1197
            var number1 = new ListNode(2);
            number1.next = new ListNode(4);
            number1.next.next = new ListNode(3);

            var number2 = new ListNode(5);
            number2.next=new ListNode(6);
            number2.next.next = new ListNode(4);

            var result = AddTwoNumbers(number1, number2);
            while (result != null)
            {
                Console.Write(result.val);
                if (result.next != null)
                {
                    Console.Write("->");
                }
                result = result.next;
            }
            Console.ReadKey();
        }

       	/// <summary>
        /// 单链表节点类
        /// </summary>
        public class ListNode
        {
            public int val { get; private set; }
            public ListNode next { get; set; }

            public ListNode(int val)
            {
                this.val = val;
            }
        }
        /// <summary>
        /// 2个单链表相加
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var sum = 0;//两个节点的和
            ListNode head = null;//头结点
            ListNode pre = null;//头结点的下一个节点
            while (l1 != null || l2 != null)
            {
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }
                var newNode = new ListNode(sum % 10);
                if (head == null) //如果头结点是空节点
                    head = newNode;
                else
                    pre.next = newNode;
                pre = newNode;
                sum /= 10;
            }

            if (sum <= 0) return head;
            var newHead = new ListNode(sum % 10);
            if (head == null)
            {
                head = newHead;
            }
            else
            {
                pre.next = newHead;
            }
            return head;
        }
    }
}