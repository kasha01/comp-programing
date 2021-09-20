using System;
using System.Collections.Generic;

// https://leetcode.com/problems/combination-sum/
namespace _csharp
{
	public class _39_combination_sum
	{
		List<List<int>> finalResult = new List<List<int>>();
		public IList<IList<int>> CombinationSum(int[] candidates, int target) {
			rc(0,0,candidates,target,new List<int>());
			return finalResult.ToArray();
		}

		private void rc(int i, int sum, int[] candidates, int target, List<int> result){
			if(i>= candidates.Length)
				return;

			if(sum > target)
				return;

			if(sum == target){
				var newList = new List<int> ();
				newList.AddRange (result);
				finalResult.Add (newList);
			}

			for(int x=i;x<candidates.Length;++x){
				result.Add(candidates[x]);
				rc(x,sum+candidates[x], candidates, target, result);
				result.RemoveAt(result.Count -1);
			}
		}
	}
}

