#include <bits/stdc++.h>

using namespace std;

struct Node{
    int data;
    Node* right;
    Node* left;

    Node(int d){
        this->data = d;
        this->right = nullptr;
        this->left = nullptr;
    }
};

void delete_node(Node* p, Node* n){
	if(n->left == nullptr && n->right == nullptr){
		delete n;
	}
	else if(n->right == nullptr){
	}
}

void bst(int& x,Node* n, Node* p, char d){
    if(x>n->data){
		// go right
		bst(x,n->right, n,'r');
    }
    else if(x<n->left){
		// go left
		bst(x,n->left,n,'l');
    }
    else{
		// this is my node - delete node
		delete_node(p,n);
    }
}
