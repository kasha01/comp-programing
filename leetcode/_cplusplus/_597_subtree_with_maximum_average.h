#ifndef _597_SUBTREE_WITH_MAXIMUM_AVERAGE_H_INCLUDED
#define _597_SUBTREE_WITH_MAXIMUM_AVERAGE_H_INCLUDED

// https://www.lintcode.com/problem/597/

class Solution {
public:
    /**
     * @param root: the root of binary tree
     * @return: the root of the maximum average of subtree
     */

    TreeNode* max_avg_root;
    double max_avg = std::numeric_limits<double>::lowest();

    // pair: sum | count
    pair<int,int> rc(TreeNode* node){
        if(!node)
            return make_pair(0,0);

        auto p_left = rc(node->left);
        auto p_right = rc(node->right);

        int sum = p_left.first + p_right.first + node->val;
        int cnt = p_left.second + p_right.second + 1;
        double avg = (double)sum/cnt;

        if(avg > max_avg){
            max_avg = avg;
            max_avg_root = node;
        }

        pair<int,int> p = make_pair(sum,cnt);
        return p;
    }

    TreeNode* findSubtree2(TreeNode *root) {
        if(!root)
            return root;

        max_avg_root = root;
        rc(root);
        return max_avg_root;
    }
};

#endif // _597_SUBTREE_WITH_MAXIMUM_AVERAGE_H_INCLUDED
