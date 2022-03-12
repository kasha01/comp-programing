#ifndef _1160_CAMPUS_BIKES_H_INCLUDED
#define _1160_CAMPUS_BIKES_H_INCLUDED

// https://www.lintcode.com/problem/1160/solution

class Solution {
    class MyCompareClass{
    public:
        bool operator()(const vector<int>& a, const vector<int>& b){
            int d_a=a[0]; int wi_a=a[1]; int bi_a=a[2];
            int d_b=b[0]; int wi_b=b[1]; int bi_b=b[2];

            if(d_a==d_b){
                if(wi_a == wi_b){
                    return bi_a < bi_b;
                }
                return wi_a < wi_b;
            }

            return d_a < d_b;
        }
    } MyCompare;

public:
    vector<int> assignBikes(vector<vector<int>> &workers, vector<vector<int>> &bikes) {
        int n = workers.size(); int m = bikes.size();
        vector<pair<int, pair<int, int> > > v;      // had to change it vector of pairs. if I use vector<vector<int>> I get TLE!!

        for(int i=0;i<n;++i){
            int wx = workers[i][0];
            int wy = workers[i][1];
            for(int j=0;j<m;++j){
                int bx = bikes[j][0];
                int by = bikes[j][1];

                int dist = abs(wx-bx) + abs(wy-by);
                v.push_back(make_pair(dist,make_pair(i,j)));
            }
        }

        std::sort(v.begin(),v.end());

        int k = 0; int workers_assigned=0;
        set<int> bikes_set; set<int> workers_set; vector<int> ans(n,0);
        while(workers_assigned<n){
            int cost = v[k].first;
            int wi = v[k].second.first;
            int bi = v[k].second.second;
            ++k;

            // bikes was assigned or worker was assigned...skip
            if(bikes_set.find(bi) != bikes_set.end() || workers_set.find(wi) != workers_set.end())
                continue;

            bikes_set.insert(bi); workers_set.insert(wi);
            ans[wi] = bi; ++workers_assigned;
        }

        return ans;
    }
};

#endif // _1160_CAMPUS_BIKES_H_INCLUDED
