#ifndef FIND_K_SMALLEST_ELEMENT_IN_BST_H_INCLUDED
#define FIND_K_SMALLEST_ELEMENT_IN_BST_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/find-k-th-smallest-element-in-bst/1
struct Node{
public:
    int data = 0;
    Node* left = nullptr;
    Node* right = nullptr;

    Node(int d){
        this->data = d;
        this->left = nullptr;
        this->right = nullptr;
    }
};

class Tree{
public:
    Node* root = nullptr;
    int k_smallest_element(Node* n, int& k);
};

// I have NO idea what was I thinking????????!!!!!!!!
// a simpler solution, do a post order iterative, on the K pop, this is the k smallest.
int Tree::k_smallest_element(Node* root, int& k){
    if (k < 0) { return 0; }
    int s = 0;
    if (root == nullptr) { return 0; }
    s = s + k_smallest_element(root->left, k);
    k--; if (k == 0) { return root->data; }
    s = s + k_smallest_element(root->right, k);
    return s;
}

void driver(){

    // Driver
    Tree t;
    Node* root = new Node(20);
    root->left = new Node(8);
    root->right = new Node(22);
    root->left->left = new Node(4);
    root->left->right = new Node(12);

    t.root = root;

    int k = 3;
    int res = t.k_smallest_element(root,k);
    cout << res;
}

#endif // FIND_K_SMALLEST_ELEMENT_IN_BST_H_INCLUDED
