#ifndef _868_MAXIMUM_AVERAGE_SUBARRAY_H_INCLUDED
#define _868_MAXIMUM_AVERAGE_SUBARRAY_H_INCLUDED

// https://www.lintcode.com/problem/868/
class Solution {
public:
    /**
     * @param nums: an array
     * @param k: an integer
     * @return: the maximum average value
     */
    double findMaxAverage(vector<int> &nums, int k) {
        int n = nums.size();
        if(n<k) return 0;

        int r = 0; int l=0; double maxAvg=std::numeric_limits<double>::lowest();
        double sum = 0;
        while(r<k-1){
            sum = sum + nums[r];
            ++r;
        }

        while(r<n){
            sum = sum + nums[r];
            maxAvg = max(maxAvg, sum/k);

            sum = sum - nums[l];
            ++r; ++l;
        }

        return maxAvg;
    }
};

#endif // _868_MAXIMUM_AVERAGE_SUBARRAY_H_INCLUDED
