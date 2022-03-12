#ifndef _878_BOUNDARY_OF_BINARY_TREE_H_INCLUDED
#define _878_BOUNDARY_OF_BINARY_TREE_H_INCLUDED

// https://www.lintcode.com/problem/878/
class Solution {
public:
    vector<int> boundary;

    void printLeft(TreeNode* node){
        if(!node) return;

        if(node->left){
            boundary.push_back(node->val);
            printLeft(node->left);
        }
        else if(node->right){
            boundary.push_back(node->val);
            printLeft(node->right);
        }
    }

    void printRight(TreeNode* node){
        if(!node) return;

        if(node->right){
            printRight(node->right);
            boundary.push_back(node->val);
        }
        else if(node->left){
            printRight(node->left);
            boundary.push_back(node->val);
        }
    }

    void printBottom(TreeNode* node){
        if(!node) return;

        if(!node->left && !node->right){
            boundary.push_back(node->val);
            return;
        }

        printBottom(node->left);
        printBottom(node->right);
    }

    vector<int> boundaryOfBinaryTree(TreeNode * root) {
        if(!root) return boundary;

        boundary.push_back(root->val);

        printLeft(root->left);
        printBottom(root->left);
        printBottom(root->right);
        printRight(root->right);

        return boundary;
    }
};

#endif // _878_BOUNDARY_OF_BINARY_TREE_H_INCLUDED
