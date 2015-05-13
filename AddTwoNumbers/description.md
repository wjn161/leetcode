## Add Two Numbers 

**问题**

You are given two linked lists representing two non-negative numbers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 0 -> 8

**问题理解**

有2个存储着非负数字的链表，每个节点中有一个数字，是反序排列的，把两个链表相加，得到一个新的链表。

```C#
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
	
	}
}
```

**问题分析**

这个问题其实就是两个单链表相加的问题，还可以被用作大数运算，类似java中的`BigInteger`类(BigInteger也可以用数组实现)，关键的难点就是需要处理进位的问题，实际上就是在链表中插入节点的操作，时间复杂度是O(n)

**问题答案**

![ac](http://7tsy9a.com1.z0.glb.clouddn.com/mewujnleetcode/addtwonumbers.png)

```C#
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

```