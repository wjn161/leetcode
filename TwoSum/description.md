## Two Sum

**问题**

Given an array of integers, find two numbers such that they add up to a specific target number.

The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.

You may assume that each input would have exactly one solution.

Input: numbers={2, 7, 11, 15}, target=9
Output: index1=1, index2=2

**问题理解**

需要构造一个函数twoSum，要求在一个整数数组中找到两个数字，相加后得到一个特定的数字，返回这两个数字在数组中的索引，第一个索引(index1)必须小于第二个(index2)，且两个索引都是从非0开始的，而是从1开始。

例如：输入数组为｛2,7,11,15｝,目标数字为9，那么输出应该是 index1=1,index2=2，即2+7=9

```C#
public class Solution {
    public int[] TwoSum(int[] nums, int target) {

    }
}
```

**问题分析**

这个题目有三种思路
1. 【O(n*n)】 直接暴力遍历相加，直到找到等于target的数字为止
2. 【O(n*log(n))】 先排序，然后前后取一个数字分别相加，判断是否等于target，等于的话就取出索引
3. 【O(n)】 使用字典，遍历数组，把元素和索引都放入字典中，找到与其相加等于target的元素的时候，从字典中取出索引。

**问题答案**

![ac](http://7tsy9a.com1.z0.glb.clouddn.com/mewujnleetcode/twosum.png)

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
            var nums = new[] { 0, 4, 3, 0 };
            const int target = 0;
            Console.WriteLine(string.Join(",", TwoSum2(nums, target)));
            Console.ReadKey();
        }
        /// <summary>
        /// 暴力遍历数组 n*(n-1) => O(n*n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum1(int[] nums, int target)
        {
            if (nums == null || nums.Length <= 0)
            {
                throw new ArgumentNullException("nums");
            }
            var result = new int[2];
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] != target) continue; //not found
                    result[0] = i + 1;
                    result[1] = j + 1;
                    return result;
                }
            }
            return null;
        }


        /// <summary>
        /// O(n*log(n)) 难点在于排序后的数组索引被打乱了，需要还原原始数组的索引。
		///先从小到大排序，然后从两边向中间分别取值相加，判断是否等于target.如果和小于target，那么左边移动一格，取更大一点的值，如果大于target，那么右边移动一格，取更小一点的值
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum2(int[] nums, int target)
        {
            if (nums == null || nums.Length <= 0)
            {
                throw new ArgumentNullException("nums");
            }
            var result = new int[2];
            var tuples = new Tuple<int, int>[nums.Length]; //2元组数组来存储原数组的索引和值，Item1是值，Item2是索引
            for (var i = 0; i < nums.Length; i++)
            {
                tuples[i] = new Tuple<int, int>(nums[i], i);
            }

            var sortedNums = tuples.OrderBy(item => item.Item1).ToArray(); //从小到大排序，但是需要保留排序前的索引，索引保存在Item2中

            for (int i = 0, j = sortedNums.Length - 1; i != j; ) //从头和尾分别取值
            {
                var sum = sortedNums[i].Item1 + sortedNums[j].Item1; //值相加
                if (sum == target) //满足条件
                {
                    if (sortedNums[i].Item2 < sortedNums[j].Item2) //取出对应的原数组的索引，按题意，加上1之后把小的放前面，大的放后面
                    {
                        result[0] = sortedNums[i].Item2 + 1;
                        result[1] = sortedNums[j].Item2 + 1;
                    }
                    else
                    {
                        result[0] = sortedNums[j].Item2 + 1;
                        result[1] = sortedNums[i].Item2 + 1;
                    }
                    return result;
                }
                if (sum < target)//小的话左边移动一格
                {
                    i++;
                }
                else//大的话右边移动一格
                {
                    j--;
                }
            }
            return null;

        }
        /// <summary>
        /// O(n)准备一个字典，然后遍历数组，如果数字不在字典中，那么把target与当前数字的差(需要查找的值)存入字典
        /// 循环到下一个数字时，如果它已经在字典中了，就证明他和当前值的和为target，于是从字典中取出结果。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum3(int[] nums, int target)
        {
            if (nums == null || nums.Length <= 0)
            {
                throw new ArgumentNullException("nums");
            }
            var dic = new Dictionary<int, int>();
            var result = new int[2];
            for (var i = 0; i < nums.Length; i++)
            {
                if (!dic.ContainsKey(nums[i]))//字典中不存在
                {
                    var lookingFor = target - nums[i]; //待查找的值
                    dic[lookingFor] = i;
                }
                else //存在，那么
                {
                    result[0] = dic[nums[i]] + 1;
                    result[1] = i + 1;
                }
            }
            return result;
        }
    }
}

```