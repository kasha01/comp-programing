#ifndef _1872_MINIMUM_COST_TO_CONNECT_STICKS_H_INCLUDED
#define _1872_MINIMUM_COST_TO_CONNECT_STICKS_H_INCLUDED

// https://www.lintcode.com/problem/1872/
class Solution {
    class MyCompare{
        public:
        bool operator()(const int& a, const int& b){
            return a>=b;
        }
    };

public:
    /**
     * @param sticks: the length of sticks
     * @return: Minimum Cost to Connect Sticks
     */
    int MinimumCost(vector<int> &sticks) {
        // write your code here
        int n = sticks.size();
        if(n==1) return 0;

        priority_queue<int, vector<int>, MyCompare> pq;

        for(int i=0;i<n;++i){
            pq.push(sticks[i]);
        }

        int sum=0;
        while(pq.size() > 1){
            int a = pq.top();
            pq.pop();
            int b = pq.top();
            pq.pop();

            sum = sum + a+b;
            pq.push(a+b);
        }

        return sum;
    }
};

#endif // _1872_MINIMUM_COST_TO_CONNECT_STICKS_H_INCLUDED
