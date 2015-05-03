using System;

namespace LeetCode
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var nums = new []{2,7,11,15 };
			const int target = 13;
			var result=TwoSum (nums, target);
			Console.WriteLine ("index1={0}",result[0]);
			Console.WriteLine ("index2={0}",result[1]);
			Console.ReadKey ();
		}

		public  static int[] TwoSum(int[] nums, int target) {
			if (nums == null || nums.Length <= 0) {
				throw new ArgumentException ("nums is null");
			}
			if (target <= 0) {
				throw new ArgumentException ("target must more than 0");
			}
			var result=new int[2];
			for (var i=0;i<nums.Length;i++) {
				for (var j=0;j<nums.Length;j++) {
					if (nums[i] + nums[j] == target) {
						result[0]=i+1;
						result[1]=j+1;
						return result;
					}
				}
			}
			return result;
		}
	}
}
