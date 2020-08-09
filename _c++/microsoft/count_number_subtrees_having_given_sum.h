#ifndef COUNT_NUMBER_SUBTREES_HAVING_GIVEN_SUM_H_INCLUDED
#define COUNT_NUMBER_SUBTREES_HAVING_GIVEN_SUM_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/count-number-of-subtrees-having-given-sum/1
struct Node
{
    int data;
    Node* left;
    Node* right;
    Node(int v){
		this->data= v;
		this->left = nullptr;
		this->right = nullptr;
    }
};

int c = 0;
int m = 7;

int solve(Node* n){
	if (n == nullptr){
		return 0;
	}

    int l = solve(n->left);
    int r = solve(n->right);
    int sum = l+r+n->data;
    if(sum == x){
        c++;
    }
    return sum;
}

void test()
{
	Node* root = new Node(1);

	solve(root);
	cout << "answer is: " << c;
}

#endif // COUNT_NUMBER_SUBTREES_HAVING_GIVEN_SUM_H_INCLUDED
