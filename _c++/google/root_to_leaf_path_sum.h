#ifndef ROOT_TO_LEAF_PATH_SUM_H_INCLUDED
#define ROOT_TO_LEAF_PATH_SUM_H_INCLUDED

//  Find the sum of all the numbers which are formed from root to leaf paths.
// Answer = 632 + 6357 + 6354 + 654 = 13997
// http://practice.geeksforgeeks.org/problems/root-to-leaf-paths-sum/1
class Node{
public:
    Node* left;
    Node* right;
    int value;

    Node(int v){
        this->right = nullptr;
        this->left = nullptr;
        this->value = v;
    }
};

int order(Node* n, int rv){
    if(n == nullptr){
        return 0;
    }
    if(n->left == nullptr && n->right == nullptr){
        return (rv*10)+n->value;
    }
    // sum of leaves on left subtree + sum of leaves on right subtree
    return order(n->left, (rv*10)+n->value) + order(n->right, (rv*10)+n->value);
}

void driver()
{
    Node* root = new Node(6);
    root->left = new Node(3);
    root->right = new Node(5);
    root->right->right = new Node(4);
    root->left->left = new Node(2);
    root->left->right = new Node(5);
    root->left->right->right = new Node(4);
    root->left->right->left = new Node(7);

    int res = order(root,0);
    cout << res;
    return 0;
}

#endif // ROOT_TO_LEAF_PATH_SUM_H_INCLUDED
