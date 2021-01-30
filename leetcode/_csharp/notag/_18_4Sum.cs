using System;
using System.Collections.Generic;

// https://leetcode.com/problems/4sum/
namespace _csharp
{
	// my solution specific to 4sum
	public class _18_4Sum
	{
		public IList<IList<int>> FourSum(int[] nums, int target) {
			Array.Sort(nums);
			List<List<int>> result = new List<List<int>>();
			var set = new HashSet<string>();

			int n = nums.Length;

			for(int a=0;a<n-1;++a){
				for(int b=a+1;b<n;++b){
					int sum = nums[a] + nums[b];
					int c = 0; int d=n-1;
					while(c<d){
						if(c==a || c==b){
							++c; continue;
						}

						if(d==a || d==b){
							--d; continue;
						}

						int s = sum + nums[c] + nums[d];
						if(s>target){
							--d;
						}
						else if(s<target){
							++c;
						}
						else{
							var ls = new List<int>(){nums[a], nums[b], nums[c], nums[d]};
							ls.Sort();

							string st = ls[0].ToString() + ls[1].ToString() + ls[2].ToString() + ls[3].ToString();

							if(!set.Contains(st)){
								result.Add(ls);                            
								set.Add(st);
							}                      

							++c; --d;
						}
					}
				}
			}

			return result.ToArray();
		}


		// leetcode solution - generic for xSum
		public List<List<int>> fourSum(int[] nums, int target) {
			Array.Sort(nums);
			return kSum(nums, target, 0, 4);
		}
		public List<List<int>> kSum(int[] nums, int target, int start, int k) {
			List<List<int>> res = new List<List<int>>();
			if (start == nums.Length || nums[start] * k > target || target > nums[nums.Length - 1] * k)
				return res;
			if (k == 2)
				return twoSum(nums, target, start);
			for (int i = start; i < nums.Length; ++i)
				if (i == start || nums[i - 1] != nums[i])
					foreach (var set in kSum(nums, target - nums[i], i + 1, k - 1)) {
						res.Add(new List<int>(){nums[i]});
						res[res.Count - 1].AddRange(set);
					}
			return res;
		}
		public List<List<int>> twoSum(int[] nums, int target, int start) {
			List<List<int>> res = new List<List<int>>();
			int lo = start, hi = nums.Length - 1;
			while (lo < hi) {
				int sum = nums[lo] + nums[hi];
				if (sum < target || (lo > start && nums[lo] == nums[lo - 1]))
					++lo;
				else if (sum > target || (hi < nums.Length - 1 && nums[hi] == nums[hi + 1]))
					--hi;
				else
					res.Add(new List<int>(){nums[lo++], nums[hi--]});
			}
			return res;
		}
	}
}

