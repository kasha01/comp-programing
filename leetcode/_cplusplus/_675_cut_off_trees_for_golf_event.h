#ifndef _675_CUT_OFF_TREES_FOR_GOLF_EVENT_H_INCLUDED
#define _675_CUT_OFF_TREES_FOR_GOLF_EVENT_H_INCLUDED

// https://leetcode.com/problems/cut-off-trees-for-golf-event/
class Solution {
    class MyComparer {
    public:
    bool operator() (const vector<int>& a, const vector<int>& b){
            return a[2]>b[2];
    }
};

public:
static bool MySort (vector<int>& a, vector<int>& b){
    return a[2] < b[2];
};

int bfs(int i, int j, int target_i, int target_j, int n, int m, vector<vector<int>> forest){
        if(i==target_i && j==target_j)
            return 0;

        vector<vector<int> > directions = {{-1,0},{1,0},{0,-1},{0,1}};
        vector<vector<int>> visited(n,vector<int>(m,0));
        queue<pair<int,int>> qu;
        qu.push({i,j});

        visited[i][j] = 1;
        int distance = 0;

        while(!qu.empty()) {
                int k = qu.size();

                for(int x=0; x<k; ++x) {
                        auto node = qu.front();
                        qu.pop();

                        for(int d=0; d<4; ++d) {
                                int r = node.first + directions[d][0];
                                int c = node.second + directions[d][1];

                                if(r<0 || r>=n || c<0 || c>=m) continue;
                                if(forest[r][c]==0 || visited[r][c]==1) continue;

                                if(r == target_i && c == target_j)
                                    return distance+1;

                                visited[r][c] = 1;
                                qu.push({r,c});
                        }
                }

                ++distance;
        }

        return -1;
}


int cutOffTree(vector<vector<int> >& forest) {
        priority_queue<vector<int>,vector<vector<int> >,MyComparer> pq;
        int n = forest.size(); int m = forest[0].size();

        for(int i=0; i<n; ++i) {
                for(int j=0; j<m; ++j) {
                        if(forest[i][j] > 1)
                        {
                                pq.push({i,j,forest[i][j]});
                        }
                }
        }

        int start_i=0; int start_j=0;
        int total_distance=0;

        while(!pq.empty()) {
                auto target_tree = pq.top(); pq.pop();

                int target_tree_i = target_tree[0];
                int target_tree_j = target_tree[1];

                int distance_to_cut_tree = bfs(start_i,start_j,target_tree_i,target_tree_j,n,m,forest);
                if(distance_to_cut_tree == -1){
                    return -1;
                }

                total_distance = total_distance + distance_to_cut_tree;
                start_i = target_tree_i;
                start_j = target_tree_j;

                // mark tree as cut
                forest[target_tree_i][target_tree_j]=1;
        }

        return total_distance;
    }
};

#endif // _675_CUT_OFF_TREES_FOR_GOLF_EVENT_H_INCLUDED
