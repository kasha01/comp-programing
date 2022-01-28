#ifndef _663_WALLS_AND_GATES_H_INCLUDED
#define _663_WALLS_AND_GATES_H_INCLUDED

// https://www.lintcode.com/problem/663/
class Solution {
    class Node{
        public:
            int i;
            int j;
            int d;
    };

public:
    /**
     * @param rooms: m x n 2D grid
     * @return: nothing
     */
    void wallsAndGates(vector<vector<int>> &rooms) {
        int inf = 2147483647;
        int n = rooms.size(); int m = rooms[0].size();
        bool visited[n][m];
        // r / c. up down left right
        int direction[4][2] = {{-1,0}, {1,0}, {0,-1}, {0,1}};

        queue<Node> qu;
        for(int i=0;i<n;++i){
            for(int j=0;j<m;++j){
                visited[i][j] = false;
                if(rooms[i][j]==0){
                    Node nd; nd.i=i; nd.j=j; nd.d=0;
                    qu.push(nd);
                    visited[i][j] = true;
                }
            }
        }

        while(!qu.empty()){
            int q_size = qu.size();
            for(int a=0;a<q_size;++a){
                Node node = qu.front(); qu.pop();
                int ii=node.i; int jj=node.j; int dd=node.d;

                for(int b=0;b<4;++b){
                    int new_i = ii + direction[b][0];
                    int new_j = jj + direction[b][1];

                    if(new_i<0 || new_j<0 || new_i>=n || new_j>=m) continue;
                    if(visited[new_i][new_j] || rooms[new_i][new_j] <=0) continue;

                    Node new_node; new_node.i=new_i; new_node.j=new_j; new_node.d=dd+1;
                    rooms[new_i][new_j] = dd+1;
                    qu.push(new_node);
                    visited[new_i][new_j]=true;
                }
            }
        }
    }
};

#endif // _663_WALLS_AND_GATES_H_INCLUDED
