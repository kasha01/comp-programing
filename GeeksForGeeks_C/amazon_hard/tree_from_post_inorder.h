#ifndef TREE_FROM_POST_INORDER_H_INCLUDED
#define TREE_FROM_POST_INORDER_H_INCLUDED


// THANKS TO GEEKSFORGEEKS - NOT MY SOLUTION O(N)
// https://www.geeksforgeeks.org/construct-a-binary-tree-from-postorder-and-inorder/
int search(int arr[], int strt, int end, int value)
{
    int i;
    for (i = strt; i <= end; i++)
    {
        if (arr[i] == value)
            break;
    }
    return i;
}

Node* buildUtil(int in[], int post[], int inStrt,
                int inEnd, int *pIndex)
{
    // Base case
    if (inStrt > inEnd)
        return NULL;

    /* Pick current node from Preorder traversal using
       postIndex and decrement postIndex */
    Node *node = newNode(post[*pIndex]);
    (*pIndex)--;

    /* If this node has no children then return */
    if (inStrt == inEnd)
        return node;

    /* Else find the index of this node in Inorder
       traversal */
    int iIndex = search(in, inStrt, inEnd, node->data);

    /* Using index in Inorder traversal, construct left and
       right subtress */
    node->right= buildUtil(in, post, iIndex+1, inEnd, pIndex);
    node->left = buildUtil(in, post, inStrt, iIndex-1, pIndex);

    return node;
}

// This function mainly initializes index of root
// and calls buildUtil()
Node *buildTree(int in[], int post[], int n)
{
    int pIndex = n-1;
    return buildUtil(in, post, 0, n - 1, &pIndex);
}

#endif // TREE_FROM_POST_INORDER_H_INCLUDED
