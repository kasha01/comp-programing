#ifndef ADD_GREATER_VALUES_NODE_BST_H_INCLUDED
#define ADD_GREATER_VALUES_NODE_BST_H_INCLUDED

// http://www.geeksforgeeks.org/add-greater-values-every-node-given-bst/
class Node{
public:
    Node* left;
    Node* right;
    int data;
    Node(int d){
        this->left = nullptr;
        this->right = nullptr;
        this->data = d;
    }
};

void inorder(Node* n, int& s){
    if(n==nullptr){return;}

    inorder(n->right,s);
    s = n->data + s;
    n->data = s;
    inorder(n->left,s);
}


void inorder(Node* n){
    if(n==nullptr){return;}

    inorder(n->left);
    cout << n->data << " ";
    inorder(n->right);
}

void mt(){
    Node* root = new Node(50);
    root->left = new Node(30);
    root->right = new Node(70);

    root->left->left = new Node(20);
    root->left->right = new Node(40);

    root->right->left = new Node(60);
    root->right->right = new Node(80);

    int s = 0;
    inorder(root,s);

    inorder(root);
}

#endif // ADD_GREATER_VALUES_NODE_BST_H_INCLUDED
