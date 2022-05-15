#ifndef _641_MISSING_RANGES_H_INCLUDED
#define _641_MISSING_RANGES_H_INCLUDED

//https://www.lintcode.com/problem/641/solution
class Solution {
public:
    /**
     * @param nums: a sorted integer array
     * @param lower: An integer
     * @param upper: An integer
     * @return: a list of its missing ranges
     */

    void addRange(long long lo, long long up, vector<string>& v){
        if(lo>up) return;
        if(lo==up) return v.push_back(to_string(lo));
        v.push_back(to_string(lo) + "->" + to_string(up));
    }

    vector<string> findMissingRanges(vector<int> &nums, int lower, int upper) {
        vector<string> v;
        int n = nums.size();

        if(n==0){
            addRange(lower,upper,v);
            return v;
        }

        addRange(lower,(long long)nums[0]-1,v);

        for(int i=1;i<n;++i){
            addRange((long long)nums[i-1]+1, (long long)nums[i]-1, v);
        }

        addRange((long long)nums[n-1] + 1, upper, v);

        return v;
    }
};

#endif // _641_MISSING_RANGES_H_INCLUDED
