#ifndef CONSTRUCT_BINARY_TREE_FROM_PARENT_ARRAY_H_INCLUDED
#define CONSTRUCT_BINARY_TREE_FROM_PARENT_ARRAY_H_INCLUDED

/*
Given an array that represents a Tree in such a way that array indexes are values in tree nodes and array
values give the parent node of that particular index (or node). The value of the root node index would
always be -1 as there is no parent for root.
*/

// https://practice.geeksforgeeks.org/problems/construct-binary-tree-from-parent-array/1
void buildTree(int p_index, Node* mynode, Node** arr){
    if(!arr[p_index]){
        arr[p_index] = new Node();
        arr[p_index]->left = nullptr;
        arr[p_index]->right = nullptr;
    }

    if(!(arr[p_index]->left)){
        // left is empty
        arr[p_index]->left = mynode;
    }
    else{
        arr[p_index]->right = mynode;
    }
}

// main method
Node* createTree(int parent[], int n)
{
    Node* root = nullptr;
    Node* arr[n] = {};
    // array of pointers, arr[0] is a pointer to Node object

    for(int i=0;i<n;i++){
        if(!arr[i]){
            // not exist
            arr[i] = new Node();
            arr[i]->left = nullptr;
            arr[i]->right = nullptr;
        }
        arr[i]->data = i;

        if(parent[i]==-1){
            root = arr[i];
            continue;
        }
        buildTree(parent[i], arr[i], arr);
    }

    return root;
}


#endif // CONSTRUCT_BINARY_TREE_FROM_PARENT_ARRAY_H_INCLUDED
