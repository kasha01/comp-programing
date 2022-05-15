#ifndef _1311_LOWEST_COMMON_ANCESTOR_OF_A_BINARY_SEARCH_TREE_H_INCLUDED
#define _1311_LOWEST_COMMON_ANCESTOR_OF_A_BINARY_SEARCH_TREE_H_INCLUDED

// https://www.lintcode.com/problem/1311/description
TreeNode * lowestCommonAncestor(TreeNode * root, TreeNode * p, TreeNode * q) {
	// write your code here
	if(!root)
		return root;

	int rv = root->val;
	int pv = p->val;
	int qv = q->val;

	if(pv > rv && qv > rv)
		return lowestCommonAncestor(root->right,p,q);

	if(pv < rv && qv < rv)
		return lowestCommonAncestor(root->left,p,q);

	// return the split point
	return root;
}

#endif // _1311_LOWEST_COMMON_ANCESTOR_OF_A_BINARY_SEARCH_TREE_H_INCLUDED
