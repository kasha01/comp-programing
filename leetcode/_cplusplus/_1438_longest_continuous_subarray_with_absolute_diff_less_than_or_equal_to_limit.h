#ifndef _1438_LONGEST_CONTINUOUS_SUBARRAY_WITH_ABSOLUTE_DIFF_LESS_THAN_OR_EQUAL_TO_LIMIT_H_INCLUDED
#define _1438_LONGEST_CONTINUOUS_SUBARRAY_WITH_ABSOLUTE_DIFF_LESS_THAN_OR_EQUAL_TO_LIMIT_H_INCLUDED

// https://leetcode.com/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/

class Solution {
public:
    int longestSubarray(vector<int>& nums, int limit) {
        int l = 0; int r = 0; int n = nums.size(); int ans = -1;
        deque<int> max_qu; deque<int> min_qu;
        while(r<n){
            int x = nums[r];

            // clear items from max_qu that are smaller than x
            while(!max_qu.empty() && nums[max_qu.back()] < x){
                max_qu.pop_back();
            }

            // clear items from min_qu that are bigger than x
            while(!min_qu.empty() && nums[min_qu.back()] > x){
                min_qu.pop_back();
            }

            max_qu.push_back(r);
            min_qu.push_back(r);

            // get distance
            while(!max_qu.empty() && !min_qu.empty() && (nums[max_qu.front()] - nums[min_qu.front()]) > limit){
                // i need to shrink window from left, which means I may need to update one/both queues to reflect shrinked window
                if(max_qu.front() == l)
                    max_qu.pop_front();

                if(min_qu.front() == l)
                    min_qu.pop_front();

                ++l;
            }

            ans = max(ans, r-l+1);
            ++r;
        }

        return ans;
    }
};

#endif // _1438_LONGEST_CONTINUOUS_SUBARRAY_WITH_ABSOLUTE_DIFF_LESS_THAN_OR_EQUAL_TO_LIMIT_H_INCLUDED
