#ifndef SYMMETRIC_TREE_H_INCLUDED
#define SYMMETRIC_TREE_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/symmetric-tree/1
struct Node{
public:
	int data;
	Node* left;
	Node* right;

	Node(int d){
        this->data = d;
	}
};

bool isMirror(Node* n1, Node* n2){
    if(n1 == nullptr && n2 == nullptr){
		return true;
    }
    else if(n1 == nullptr || n2 == nullptr){
		return false;
    }
    else if(n1->data != n2->data){
		return false;
    }

    return isMirror(n1->left, n2->right) && isMirror(n1->right, n2->left);
}

bool isSymmetric(Node* root)
{
    if(root == nullptr)
        return true;

    return isMirror(root->left, root->right);
}

int main()
{
    Node* root = new Node(1);
    Node* n2l = new Node(2);
    Node* n3l = new Node(3);
    Node* n4l = new Node(4);

    Node* n2r = new Node(2);
    Node* n3r = new Node(3);
    Node* n4r = new Node(4);

    root->left = n2l;
    n2l->left = n3l;
    n2l->right = n4l;

    root->right = n2r;
    n2r->left = n4r;
    n2r->right = n3r;

	cout << isSymmetric(root);

    return 0;
}

#endif // SYMMETRIC_TREE_H_INCLUDED
