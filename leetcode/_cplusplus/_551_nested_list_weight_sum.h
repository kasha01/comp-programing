#ifndef _551_NESTED_LIST_WEIGHT_SUM_H_INCLUDED
#define _551_NESTED_LIST_WEIGHT_SUM_H_INCLUDED

// https://www.lintcode.com/problem/551/

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
class Solution {
public:
    int depthSum(const vector<NestedInteger>& nestedList) {
        // Write your code here
        return rc(1,nestedList);
    }

    int rc(int level,const vector<NestedInteger>& nestedList){
        int n = nestedList.size();

        int sum = 0;
        for(int i=0;i<n;++i){
            auto nestedInt = nestedList[i];
            if(nestedInt.isInteger()){
                sum = sum + (level * nestedInt.getInteger());
            }
            else{
                sum = sum + rc(level+1,nestedInt.getList());
            }
        }

        return sum;
    }
};

#endif // _551_NESTED_LIST_WEIGHT_SUM_H_INCLUDED
