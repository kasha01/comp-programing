using System;
using System.Collections.Generic;

// https://leetcode.com/problems/contains-duplicate/
namespace _csharp
{
	public class _217_contains_duplicate
	{
		public bool ContainsDuplicate(int[] nums) {
			HashSet<int> set = new HashSet<int>();

			for(int i=0;i<nums.Length;++i){
				if(set.Contains(nums[i]))
					return true;

				set.Add(nums[i]);
			}

			return false;
		}
	}
}