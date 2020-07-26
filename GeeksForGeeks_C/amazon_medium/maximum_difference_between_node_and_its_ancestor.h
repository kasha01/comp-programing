#ifndef MAXIMUM_DIFFERENCE_BETWEEN_NODE_AND_ITS_ANCESTOR_H_INCLUDED
#define MAXIMUM_DIFFERENCE_BETWEEN_NODE_AND_ITS_ANCESTOR_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/maximum-difference-between-node-and-its-ancestor/1

struct Node
{
    int data;
    struct Node* left;
    struct Node* right;

    Node(int x){
        data = x;
        left = right = NULL;
    }
};

int m = INT_MIN;
int rc(Node* root){
	if(root==nullptr)
		return INT_MIN;

	int t = root->data;
	int l = rc(root->left);
	int r = rc(root->right);

	int v;
	if(l==INT_MIN && r==INT_MIN){
		 v = t;
	}
	else if(l==INT_MIN){
		v = min(t,r);
		m = max(m, t-r);
	}
	else if(r==INT_MIN){
		v = min(t,l);
		m = max(m, t-l);
	}
	else{
        v = min(t, min(l,r));
        m = max(m, t - min(l,r));
	}

	return v;
}

void driver(Node* root)
{
    // Your code here
    m = INT_MIN;
    rc(root);
    cout << m;
}


#endif // MAXIMUM_DIFFERENCE_BETWEEN_NODE_AND_ITS_ANCESTOR_H_INCLUDED
