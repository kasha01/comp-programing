#ifndef LONGEST_CONSECUTIVE_SEQUENCE_IN_BINARY_TREE_H_INCLUDED
#define LONGEST_CONSECUTIVE_SEQUENCE_IN_BINARY_TREE_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/longest-consecutive-sequence-in-binary-tree/1
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
    int maxLCS = 0;
    void lcs(Node* n, int l, int pd);
};

void Tree::lcs(Node* n, int l, int pd){
    if(n== nullptr){return;}
    if(n->data==pd+1){l++; if(Tree::maxLCS < l){maxLCS = l;} }
    else {l=1;}

    lcs(n->left,l,n->data);
    lcs(n->right,l,n->data);
}

void longest_consecutive_sequence_in_bt(){

    Tree t;
    Node* root = new Node(10);
    root->right = new Node(30);
    root->left = new Node(20);
    root->left->left = new Node(40);
    root->left->right = new Node(60);

    t.root = root;
    t.lcs(root,1,root->data);

    maxLCS = 0; // for multiple test cases

    if(maxLCS == 0){maxLCS = -1;} // if no sequence is possible, return -1!!

    cout << t.maxLCS;
}

#endif // LONGEST_CONSECUTIVE_SEQUENCE_IN_BINARY_TREE_H_INCLUDED
