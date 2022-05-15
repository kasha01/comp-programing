#ifndef _88_LOWEST_COMMON_ANCESTOR_OF_A_BINARY_TREE_H_INCLUDED
#define _88_LOWEST_COMMON_ANCESTOR_OF_A_BINARY_TREE_H_INCLUDED

// https://www.lintcode.com/problem/88
TreeNode * lca = nullptr;
TreeNode * lowestCommonAncestor(TreeNode * root, TreeNode * A, TreeNode * B) {
	// write your code here
	findLCA(root, A, B);
	return lca;
}

bool findLCA(TreeNode* root, TreeNode* a, TreeNode* b){
	if(root == nullptr) return false;

	int l = findLCA(root->left, a, b);
	int r = findLCA(root->right, a, b);

	if(root->val == a->val && root->val == b->val){
		// edge case if there is only 1 node
		lca=root;
		return true;
	}

	bool isMatch = root->val == a->val || root->val == b->val;

	if((l && r) || (l && isMatch) || (r && isMatch))
		lca = root;

	if(l || r || isMatch) return true;
}

#endif // _88_LOWEST_COMMON_ANCESTOR_OF_A_BINARY_TREE_H_INCLUDED
