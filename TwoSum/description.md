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

