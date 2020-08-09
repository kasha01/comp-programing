#ifndef LOWEST_COMMON_ANCESTOR_BINARY_TREE_H_INCLUDED
#define LOWEST_COMMON_ANCESTOR_BINARY_TREE_H_INCLUDED

// http://www.geeksforgeeks.org/lowest-common-ancestor-binary-tree-set-1/
Node* myhead = nullptr;
bool LCA(Node* n, int nv1, int nv2)
{
    if (myhead != nullptr) {
        return false;   // common ancestor was found. just return
    }
    if (n == nullptr) { return false; }

    bool n1Found = false; bool n2Found = false;
    n1Found = LCA(n->left, nv1, nv2);
    n2Found = LCA(n->right, nv1, nv2);

    if ((n1Found && n2Found)    // n1found in left sub-tree and n2found in right sub-tree
        || ((n1Found || n2Found) && (n->data == nv1 || n->data == nv2)) //n1 and n2 are on the same sub-tree (left or right)
        || ((nv1 == n->data) && (nv2 == n->data))   //if n1=n2
        )
    {
        myhead = n;
        return false;
    }
    return n1Found || n2Found || n->data == nv1 || n->data == nv2;
}


#endif // LOWEST_COMMON_ANCESTOR_BINARY_TREE_H_INCLUDED
