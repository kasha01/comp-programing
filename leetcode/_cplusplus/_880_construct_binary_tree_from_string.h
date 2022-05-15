#ifndef _880_CONSTRUCT_BINARY_TREE_FROM_STRING_H_INCLUDED
#define _880_CONSTRUCT_BINARY_TREE_FROM_STRING_H_INCLUDED

// https://www.lintcode.com/problem/880/description

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
     * @param s: a string
     * @return: a root of this tree
     */
    TreeNode* str2tree(string &s) {
        // write your code here
        int n = s.size();
        stack<TreeNode*> st;
        int i=0;
        while(i<n){
            if(s[i]=='-' || (s[i] >='0' && s[i] <='9')){
                int x = 0;
                bool isNegative=s[i] == '-';
                if(s[i] == '-'){
                    ++i;
                }

                while(i<n && s[i] != ')' && s[i] != '('){
                    x = x*10 + (s[i]-'0');
                    ++i;
                }

                if(isNegative) x = x * (-1);

                auto node = new TreeNode(x);
                st.push(node);
            }
            else if(s[i] == ')'){
                TreeNode* leaf = st.top(); st.pop();
                TreeNode* parent = st.top();

                if(!parent->left){
                    parent->left = leaf;
                }
                else{
                    parent->right = leaf;
                }

                ++i;
            }
            else{
                ++i;
            }
        }

        return st.top();
    }
};

#endif // _880_CONSTRUCT_BINARY_TREE_FROM_STRING_H_INCLUDED
