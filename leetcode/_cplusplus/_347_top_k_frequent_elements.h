#ifndef _347_TOP_K_FREQUENT_ELEMENTS_H_INCLUDED
#define _347_TOP_K_FREQUENT_ELEMENTS_H_INCLUDED

// https://leetcode.com/problems/top-k-frequent-elements/
class myComparator{
public:
    int operator() (const pair<int,int> p1, const pair<int,int> p2)
    {
        return p1.second >= p2.second;
    }
};

public:
    vector<int> topKFrequent(vector<int>& nums, int k) {
        map<int,int> mp;

        for(int i=0; i<nums.size(); ++i){
            int x = nums[i];
            if(mp.find(x) == mp.end())
                mp[x]=0;

            mp[x]++;
        }

        priority_queue<pair<int,int>,vector<pair<int,int>>, myComparator> pq;

        map<int,int>::iterator it;
        for(it = mp.begin(); it!=mp.end(); ++it){
            pq.push(make_pair(it->first, it->second));

            if(pq.size() > k)
                pq.pop();
        }

        vector<int> ans(k);
        for(int i=k-1;i>=0;--i){
            ans[i]= pq.top().first;
            pq.pop();
        }

        return ans;
    }

#endif // _347_TOP_K_FREQUENT_ELEMENTS_H_INCLUDED
