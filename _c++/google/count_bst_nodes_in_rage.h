#ifndef COUNT_BST_NODES_IN_RAGE_H_INCLUDED
#define COUNT_BST_NODES_IN_RAGE_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/count-bst-nodes-that-lie-in-a-given-range/1
class Node{
public:
    Node* left;
    Node* right;
    int data;

    Node(int v){
        this->right = nullptr;
        this->left = nullptr;
        this->data = v;
    }
};

int getCount(Node* root, int l, int h){
    if(root == nullptr){
        return 0;
    }
    else if(root->data < h && root->data > l){
        return 1 + getCount(root->right,l,h) + getCount(root->left,l,h);
    }
    else if(root->data == l){
        return 1 + getCount(root->right,l,h);
    }
    else if(root->data == h){
        return 1 + getCount(root->left,l,h);
    }
    else if(root->data < l){
        return getCount(root->right,l,h);
    }
    else if(root->data > h){
        return getCount(root->left,l,h);
    }
    else{
        return 0;
    }
}

void driver(){
    Node* root = new Node(10);
    root->left = new Node(5);
    root->right = new Node(50);
    root->right->right = new Node(100);
    root->right->left = new Node(40);
    root->left->left = new Node(1);

    int g = getCount(root,5,45);
    cout << g;
}

#endif // COUNT_BST_NODES_IN_RAGE_H_INCLUDED
