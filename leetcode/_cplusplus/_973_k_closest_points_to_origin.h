#ifndef _973_K_CLOSEST_POINTS_TO_ORIGIN_H_INCLUDED
#define _973_K_CLOSEST_POINTS_TO_ORIGIN_H_INCLUDED

// https://leetcode.com/problems/k-closest-points-to-origin/
class Solution {
public:
    class MyComparer{
        public:
        bool operator()(const vector<int>& a, const vector<int>& b){
            auto da = a[0]*a[0] + a[1]*a[1];
            auto db = b[0]*b[0] + b[1]*b[1];
            return da<db;
        }
    };

    vector<vector<int>> kClosest(vector<vector<int>>& points, int k) {
        priority_queue<vector<int>, vector<vector<int>>, MyComparer>  pq;

        int n = points.size();
        for(int i=0;i<n;++i){
            pq.push(points[i]);
            if(pq.size() > k){
                pq.pop();
            }
        }

        vector<vector<int>> ans;
        while(!pq.empty()){
            ans.push_back(pq.top());
            pq.pop();
        }

        return ans;
    }
};

#endif // _973_K_CLOSEST_POINTS_TO_ORIGIN_H_INCLUDED
