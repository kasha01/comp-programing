#ifndef PRINT_ALL_NODES_DISTANCE_K_FROM_TARGET_BST_H_INCLUDED
#define PRINT_ALL_NODES_DISTANCE_K_FROM_TARGET_BST_H_INCLUDED

// Thanks to Prasant Kumar for this solution
// http://www.geeksforgeeks.org/print-nodes-distance-k-given-node-binary-tree/


/* Recursive function to print all the nodes at distance k in the
   tree (or subtree) rooted with given root. See  */
void printkdistanceNodeDown(node *root, int k)
{
    // Base Case - notice the check for k<0, as k is consumed.
    if (root == NULL || k < 0)  return;

    // If we reach a k distant node, print it
    if (k==0)
    {
        cout << root->data << endl;
        return;
    }

    // Recur for left and right subtrees
    printkdistanceNodeDown(root->left, k-1);
    printkdistanceNodeDown(root->right, k-1);
}

// Prints all nodes at distance k from a given target node.
// The k distant nodes may be upward or downward.  This function
// Returns distance of root from target node, it returns -1 if target
// node is not present in tree rooted with root.
int printkdistanceNode(node* root, node* target , int k)
{
    // Base Case 1: If tree is empty, return -1
    if (root == NULL) return -1;

    // If target is same as root.  Use the downward function
    // to print all nodes at distance k in subtree rooted with
    // target or root
    if (root == target)
    {
        printkdistanceNodeDown(root, k);
        // I am the target, so return dl/dr=0 as the distance from me to the target is zero.
        return 0;
    }

    // Recur for left subtree
    int dl = printkdistanceNode(root->left, target, k);

    // Check if target node was found in left subtree
    if (dl != -1 )
    {
         // If root is at distance k from target, print root
         // Note that dl is Distance of root's left child from target
         // dl = is the distance between current node (root) and the target node which lies in the root's
         // left sub tree.
         // if dl+1=k, the means my root/current node is the last/furthest node I can go to upwardly. as k was
         // exhausted. then print the data.
         if (dl + 1 == k)
            cout << root->data << endl;

         // Else go to right subtree and print all k-dl-2 distant nodes
         // Note that the right child is 2 EDGES away from left child.
         // the right child is two edges aways from target
         else
            printkdistanceNodeDown(root->right, k-dl-2);

         // Add 1 to the distance and return value for parent calls
         // The return increments 1 naturally as I am recurssivly being returned to my root. so I am +1 edge
         // way from the target (considering it is on the left subtree), so whatever dl (distance from me to
         // the target on my left subtree is), I increments 1 and return to my root.
         return 1 + dl;
    }

    // MIRROR OF ABOVE CODE FOR RIGHT SUBTREE
    // Note that we reach here only when node was not found in left subtree
    int dr = printkdistanceNode(root->right, target, k);
    if (dr != -1)
    {
         if (dr + 1 == k)
            cout << root->data << endl;
         else
            printkdistanceNodeDown(root->left, k-dr-2);
         return 1 + dr;
    }

    // If target was neither present in left nor in right subtree
    return -1;
}

#endif // PRINT_ALL_NODES_DISTANCE_K_FROM_TARGET_BST_H_INCLUDED
