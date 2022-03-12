#ifndef _1425_CONSTRAINED_SUBSEQUENCE_SUM_H_INCLUDED
#define _1425_CONSTRAINED_SUBSEQUENCE_SUM_H_INCLUDED

// https://leetcode.com/problems/constrained-subsequence-sum/

class Solution {
public:
    int constrainedSubsetSum(vector<int>& nums, int k) {
        // pair==> first:index at which sum is valid | second:value of sum
        deque<pair<int,int>> dq;
        int n = nums.size();
        int max_sum_global = INT_MIN;

        int i = 0;
        while(i<n){
            int x = nums[i];

            // clean out of bound sums from deque
            while(!dq.empty() && dq.front().first < i-k){
                dq.pop_front();
            }

            int sum_at_i = x + (dq.empty() ? 0 : dq.front().second);
            int max_sum_at_i = max(x,sum_at_i);

            // before inserting, clear sums that are smaller than to be inserted value.
            while(!dq.empty() && dq.back().second < max_sum_at_i){
                dq.pop_back();
            }
            dq.push_back(make_pair(i,max_sum_at_i));

            max_sum_global = max(max_sum_global,max_sum_at_i);

            ++i;
        }

        return max_sum_global;
    }
};

#endif // _1425_CONSTRAINED_SUBSEQUENCE_SUM_H_INCLUDED
