#ifndef _431_CONNECTED_COMPONENT_IN_UNDIRECTED_GRAPH_H_INCLUDED
#define _431_CONNECTED_COMPONENT_IN_UNDIRECTED_GRAPH_H_INCLUDED

// https://www.lintcode.com/problem/431/

/**
 * Definition for undirected graph.
 * struct UndirectedGraphNode {
 *     int label;
 *     vector<UndirectedGraphNode *> neighbors;
 *     UndirectedGraphNode(int x) : label(x) {};
 * };
 */

class Solution {
public:
    /**
     * @param nodes: a array of Undirected graph node
     * @return: a connected set of a Undirected graph
     */
    set<int> visited;
    vector<vector<int>> connectedSet(vector<UndirectedGraphNode*> nodes) {
        // write your code here

        vector<vector<int>> ans;
        for(int i=0;i<nodes.size();++i){
            if(visited.find(nodes[i]->label) == visited.end())
            {
                vector<int> v; v.push_back(nodes[i]->label); visited.insert(nodes[i]->label);
                dfs(nodes[i],v);
                sort(v.begin(),v.end());
                ans.push_back(v);
            }
        }

        return ans;
    }

    void dfs(UndirectedGraphNode* node, vector<int>& v){
        auto adj = node->neighbors;
        for(int i=0;i<adj.size();++i){
            if(visited.find(adj[i]->label) != visited.end())
                continue;

            visited.insert(adj[i]->label);
            v.push_back(adj[i]->label);
            dfs(adj[i],v);
        }
    }
};


#endif // _431_CONNECTED_COMPONENT_IN_UNDIRECTED_GRAPH_H_INCLUDED
