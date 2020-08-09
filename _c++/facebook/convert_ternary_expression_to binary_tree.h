#ifndef CONVERT_TERNARY_EXPRESSION_TO_BINARY_TREE_H_INCLUDED
#define CONVERT_TERNARY_EXPRESSION_TO_BINARY_TREE_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/convert-ternary-expression-to-binary-tree/1
struct Node{
	char data;
	Node *left,*right;
	Node(){}
	Node(char c){
		this->data = c;
	}
};

Node* convertExpression(string str,int i)
{
    Node* root = new Node();
    root->data = str[0];
	i++;
    int n = str.size();
    stack<Node*> mystack;
    mystack.push(root);
	Node* p;
	while(i<n){
        char x = str[i];
        if(x == '?'){
			p = mystack.top();
			p->left = new Node();
			p->left->data = str[i+1];
			mystack.push(p->left);
			i=i+2;
        }
        else if(x == ':'){
			mystack.pop();				// pop the child node
			p = mystack.top();			// peek at the parent
			p->right = new Node();		// assign parent's right node
			p->right->data = str[i+1];
			mystack.pop();				// now pop the parent because it is filled (both left and right children)
			mystack.push(p->right);		// push the new node, in case it has ternary as well
			i=i+2;
        }
	}

    return root;
}

int driver()
{
	convertExpression("a?b:c", 0);
    return 0;
}

#endif // CONVERT_TERNARY_EXPRESSION_TO_BINARY_TREE_H_INCLUDED
