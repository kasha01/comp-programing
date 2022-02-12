#ifndef _760_BINARY_TREE_RIGHT_SIDE_VIEW_H_INCLUDED
#define _760_BINARY_TREE_RIGHT_SIDE_VIEW_H_INCLUDED

// https://www.lintcode.com/problem/760/description
vector<int> rightSideView(TreeNode * root) {
	vector<int> ans;
	if(!root) return ans;

	queue<TreeNode*> qu;
	qu.push(root);

	while(!qu.empty()){
		int n = qu.size();

		bool right_view_set = false;
		for(int i=0;i<n;++i){
			auto node = qu.front();
			qu.pop();

			if(!right_view_set){
				ans.push_back(node->val);
				right_view_set = true;
			}

			if(node->right) qu.push(node->right);
			if(node->left) qu.push(node->left);
		}
	}

	return ans;
}

#endif // _760_BINARY_TREE_RIGHT_SIDE_VIEW_H_INCLUDED
