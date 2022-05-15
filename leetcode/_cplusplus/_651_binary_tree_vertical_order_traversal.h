#ifndef _651_BINARY_TREE_VERTICAL_ORDER_TRAVERSAL_H_INCLUDED
#define _651_BINARY_TREE_VERTICAL_ORDER_TRAVERSAL_H_INCLUDED

// https://www.lintcode.com/problem/651/

/**
 * Definition of TreeNode:
 * class TreeNode {
 * public:
 *     int val;
 *     TreeNode *left, *right;
 *     TreeNode(int val) {
 *         this->val = val;
 *         this->left = this->right = NULL;
 *     }
 * }
 */

class Solution {
public:
    /**
     * @param root: the root of tree
     * @return: the vertical order traversal
     */
    map<int,vector<int>> mp;
    vector<vector<int>> verticalOrder(TreeNode *root) {
        // write your code here
        vector<vector<int>> ans;
        if(!root)
            return ans;

        queue<pair<TreeNode*,int>> qu;
        qu.push(make_pair(root,0));

        while(!qu.empty()){
            int n = qu.size();
            for(int i=0;i<n;++i){
                auto qu_node = qu.front(); qu.pop();
                auto node = qu_node.first;
                auto level = qu_node.second;

                mp[level].push_back(node->val);

                if(node->left) qu.push(make_pair(node->left,level-1));
                if(node->right) qu.push(make_pair(node->right,level+1));
            }
        }

        for(map<int,vector<int>>::iterator it=mp.begin(); it!=mp.end(); ++it){
            ans.push_back(it->second);
        }

        return ans;
    }

    void dfs(TreeNode* root, int column){
        if(root == nullptr) return;

        mp[column].push_back(root->val);

        dfs(root->left, column-1);
        dfs(root->right, column+1);
    }
};

#endif // _651_BINARY_TREE_VERTICAL_ORDER_TRAVERSAL_H_INCLUDED
