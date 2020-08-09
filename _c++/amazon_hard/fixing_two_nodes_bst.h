#ifndef FIXING_TWO_NODES_BST_H_INCLUDED
#define FIXING_TWO_NODES_BST_H_INCLUDED


// this test case fails for some reason, but works when compile tested. something is wrong with geeks.
// https://practice.geeksforgeeks.org/problems/fixed-two-nodes-of-a-bst/1
struct node
{
    int data;
    struct node *left, *right;
    node(int d){
        this->data = d;
        this->left = nullptr;
        this->right = nullptr;
    }
};

vector<node*> vec;

void inorder(node* n){
    if(!n){return;}

    inorder(n->left);
    cout << n->data << " ";
    vec.push_back(n);
    inorder(n->right);
}

void mt()
{
    node* root = new node(10);
    root->left = new node(3);
    root->right = new node(17);
    root->right->left = new node(4);
    root->left->right = new node(11);

    inorder(root);

    int i1 = -1; int i2=-1;
    int prev=vec[0]->data;
    for(int i=1;i<vec.size(); ++i){
        if(prev > vec[i]->data){
            // out of order
            if(i1==-1){
                i1=i-1;
            }
            i2=i;
        }
        prev=vec[i]->data;
    }

    if(i1!=-1){
        // swap
        int temp = vec[i1]->data;
        vec[i1]->data = vec[i2]->data;
        vec[i2]->data = temp;
    }

    cout << endl;
    inorder(root);
}


#endif // FIXING_TWO_NODES_BST_H_INCLUDED
