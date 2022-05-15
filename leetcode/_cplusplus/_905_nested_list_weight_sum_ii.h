#ifndef _905_NESTED_LIST_WEIGHT_SUM_II_H_INCLUDED
#define _905_NESTED_LIST_WEIGHT_SUM_II_H_INCLUDED

// https://www.lintcode.com/problem/905/

class Solution {
public:
    /**
	 * // This is the interface that allows for creating nested lists.
	 * // You should not implement it, or speculate about its implementation
	 * class NestedInteger {
	 *   public:
	 *     // Return true if this NestedInteger holds a single integer,
	 *     // rather than a nested list.
	 *     bool isInteger() const;
	 *
	 *     // Return the single integer that this NestedInteger holds,
	 *     // if it holds a single integer
	 *     // The result is undefined if this NestedInteger holds a nested list
	 *     int getInteger() const;
	 *
	 *     // Return the nested list that this NestedInteger holds,
	 *     // if it holds a nested list
	 *     // The result is undefined if this NestedInteger holds a single integer
	 *     const vector<NestedInteger> &getList() const;
	 * };
	 */
    map<int,vector<int>> mp;
    int maxLevel=-1;
    void rc(vector<NestedInteger> nestedList, int level){
        int n = nestedList.size();

        maxLevel = max(maxLevel,level);
        for(int i=0;i<n;++i){
            NestedInteger nested_item = nestedList[i];

            if(nestedList[i].isInteger()){
                // no more nested
                mp[level].push_back(nested_item.getInteger());
            }
            else{
                rc(nested_item.getList(), level+1);
            }
        }
    }

    int depthSumInverse(vector<NestedInteger> nestedList) {
        // Write your code here.
        rc(nestedList, 0);

        int sum = 0;
        for(map<int,vector<int>>::iterator it=mp.begin(); it!=mp.end(); ++it){
            int level = maxLevel - it->first + 1;
            vector<int> v = it->second;
            for(int i=0;i<v.size();++i){
                sum = sum + (v[i]*level);
            }
        }

        return sum;
    }
};

#endif // _905_NESTED_LIST_WEIGHT_SUM_II_H_INCLUDED
