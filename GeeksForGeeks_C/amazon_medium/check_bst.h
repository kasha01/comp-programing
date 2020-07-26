#ifndef CHECK_BST_H_INCLUDED
#define CHECK_BST_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/check-for-bst/1
int rc(Node* root, char d){
	if(root == nullptr)
		return 0;

	int t = root->data;
	int l = rc(root->left, 'l');
	int r = rc(root->right, 'r');

	if(l==0 && r==0)
		return t;

    if(l==-1 || r == -1)
		return -1;

	if((l>0 && l>=t) || (r>0 && r<t))
		return -1;

    if(d == 'l')
		return max(l, max(t,r));
	else if(d == 'r'){
		if(l==0)
			return min(r,t);
		else
			return min(r, min(t,l));
	}
	else
		return 1;
}

// return true if the given tree is a BST, else return false
bool isBST(Node* root) {
    // Your code here
    int r = rc(root, '-');
	return r == -1 ? false : true;
}


#endif // CHECK_BST_H_INCLUDED
