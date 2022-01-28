using System;
using System.Collections.Generic;

// https://leetcode.com/problems/3sum/
namespace _csharp
{
	public class _15_3sum
	{
		public IList<IList<int>> ThreeSum(int[] nums) {
			int n = nums.Length;
			Array.Sort(nums);
			List<List<int>> list = new List<List<int>>();

			int start = 0;
			while(start < n-2 && nums[start] <= 0){
				if(start>0 && nums[start-1] == nums[start]){
					++start;
					continue;
				}

				calc(start, start+1, n-1, nums, list);

				++start;
			}

			return list.ToArray();
		}

		private void calc(int start, int i, int j, int[] nums, List<List<int>> list){
			while(i<j){
				int sum = nums[start] + nums[i] + nums[j];
				if(sum > 0){
					--j;
				}
				else if(sum < 0){
					++i;
				}
				else{
					list.Add(new List<int>(){ nums[start], nums[i], nums[j] });
					int prev_i = nums[i]; int prev_j = nums[j];
					while(i<j && nums[i] == prev_i){
						++i;
					}
					while(i<j && nums[j] == prev_j){
						--j;
					}
				}
			}
		}
	}
}