#ifndef BOTTOM_VIEW_BINARY_TREE_H_INCLUDED
#define BOTTOM_VIEW_BINARY_TREE_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/bottom-view-of-binary-tree/1
struct Node
{
    int data;
    Node *left, *right;
    Node(int d){
        this->data = d;
        this->left = nullptr;
        this->right = nullptr;
    }
};

map<int,int> mp;
void inorder(Node* root,int column){
    if(root == nullptr){
        return;
    }
    mp[column] = root->data;
    inorder(root->left,column-1);
    inorder(root->right,column+1);
}

void driver(){

    for(std::map<int,int>::iterator it = mp.begin(); it != mp.end(); ++it){
        cout << it->second << " ";
    }

    return 0;
}

#endif // BOTTOM_VIEW_BINARY_TREE_H_INCLUDED
