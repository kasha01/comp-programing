#ifndef _K_MAXIMUM_SUM_COMBINATIONS_FROM_TWO_ARRAYS_H_INCLUDED
#define _K_MAXIMUM_SUM_COMBINATIONS_FROM_TWO_ARRAYS_H_INCLUDED

// https://www.geeksforgeeks.org/k-maximum-sum-combinations-two-arrays/

/*
To understand the solution, generate the N^2 array solution. you will notice, I can have the solution as N arrays
each with its header being the maximum value possible
*/

class Node{
public:
	int a_idx;
	int b_idx;
	int val;

	Node(int ai, int bi, int v){
		this->a_idx=ai; this->b_idx=bi; this->val=v;
	}
};

static bool sort_rev (const int& a, const int& b){
	return a>=b;
};

class MyCompare{
public:
	bool operator()(const Node* a, const Node* b){
		return a->val < b->val;
	}
};

void solve()
{
	vector<int> a = {4,2,5,1};
	vector<int> b = {8,0,3,5};
	int k = 3;
	int n = a.size();

	sort(a.begin(), a.end(), sort_rev);
	sort(b.begin(), b.end(), sort_rev);

	priority_queue<Node*, vector<Node*>, MyCompare> pq;

	for(int i=0;i<n;++i){
		pq.push(new Node(i,0, a[i]+b[0]));
	}

	int sum = 0;
	for(int i=0;i<k;++i){
		Node* node = pq.top();
		pq.pop();

		cout << node->val << "\n";
		sum = sum + node->val;

		node->b_idx++;
		node->val = a[node->a_idx] + b[node->b_idx];
		pq.push(node);
	}

	cout << "Total sum:" << sum;
}


#endif // _K_MAXIMUM_SUM_COMBINATIONS_FROM_TWO_ARRAYS_H_INCLUDED
