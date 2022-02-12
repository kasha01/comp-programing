#ifndef _703_KTH_LARGEST_ELEMENT_IN_A_STREAM_H_INCLUDED
#define _703_KTH_LARGEST_ELEMENT_IN_A_STREAM_H_INCLUDED

// https://leetcode.com/problems/kth-largest-element-in-a-stream/

class KthLargest {
    class MyCompare{
        public:
        bool operator()(const int& a, const int& b){
            return a>b;
        }
    };

public:
    priority_queue<int,vector<int>,MyCompare> pq;
    int kk;

    KthLargest(int k, vector<int>& nums) {
        kk = k;
        for(int i=0;i<nums.size();++i){
            pq.push(nums[i]);
            if(pq.size() > k)
                pq.pop();
        }
    }

    int add(int val) {
        pq.push(val);
        if(pq.size() > kk)
            pq.pop();

        return pq.top();
    }
};


#endif // _703_KTH_LARGEST_ELEMENT_IN_A_STREAM_H_INCLUDED
