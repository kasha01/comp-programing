#ifndef _609_TWO_SUM_LESS_THAN_OR_EQUAL_TO_TARGET_H_INCLUDED
#define _609_TWO_SUM_LESS_THAN_OR_EQUAL_TO_TARGET_H_INCLUDED

// https://leetcode.com/problems/two-sum-less-than-k/
// https://www.lintcode.com/problem/609/

int twoSum5(vector<int> &nums, int target) {
	// write your code here
	int n = nums.size();

	if(n<=1) return 0;

	sort(nums.begin(), nums.end());

	int i=0; int j=1; int sum=0;

	while(j<n){
		if(nums[i] + nums[j] <= target){
			sum = sum + (i+1); ++j; ++i;
		}
		else{
			while(i>=0 && nums[i]+nums[j] > target){
				--i;
			}

			if(i<0) break;
		}
	}

	return sum;
}

#endif // _609_TWO_SUM_LESS_THAN_OR_EQUAL_TO_TARGET_H_INCLUDED
