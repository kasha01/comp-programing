#ifndef _578_LOWEST_COMMON_ANCESTOR_III_H_INCLUDED
#define _578_LOWEST_COMMON_ANCESTOR_III_H_INCLUDED

// https://www.lintcode.com/problem/578/
TreeNode * lca = nullptr;
TreeNode * lowestCommonAncestor3(TreeNode * root, TreeNode * A, TreeNode * B) {
	// write your code here
	findLCA(root, A, B);
	return lca;
}

bool findLCA(TreeNode* root, TreeNode* a, TreeNode* b){
	if(root == nullptr) return false;

	int l = findLCA(root->left, a, b);
	int r = findLCA(root->right, a, b);

	bool isMatch = root->val == a->val || root->val == b->val;

	if((l && r) || (l && isMatch) || (r && isMatch))
		lca = root;

	if(l || r || isMatch) return true;
}

#endif // _578_LOWEST_COMMON_ANCESTOR_III_H_INCLUDED
