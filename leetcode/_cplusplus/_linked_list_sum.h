#ifndef _LINKED_LIST_SUM_H_INCLUDED
#define _LINKED_LIST_SUM_H_INCLUDED

// https://leetcode.com/discuss/interview-question/1546673/Amazon-or-OA-or-LinkedListSum
class Node{
public:
	int val;
	Node* next;

	Node(int v){
		this->val = v;
	}
};

Node* get_xor (Node* a, Node* b)
{
    return (Node*) ((uintptr_t) (a) ^ (uintptr_t) (b));
}

void convert_to_xor_linked_list(Node* head){
	Node* prev = nullptr;

	while(head!=nullptr){
		Node* next_node = head->next;
		head->next = get_xor(prev, next_node);
		prev = head;
		head = next_node;
	}
}

Node* find_last_node(Node* node){
	Node* last_node = nullptr;
	Node* prev = nullptr;
	while(node->next != prev){
		Node* temp = node;
		node = get_xor(prev, node->next);
		prev = temp;
	}

	return last_node = node;
}

Node* buildLinkedTree(int* arr, int n){
	Node* head = new Node(arr[0]);
	Node* current = head;
	for(int i=1;i<n;++i){
		Node* node = new Node(arr[i]);
		current->next = node;
		current = node;
	}
	return head;
}

int get_max_pair_sum(Node* head){
	int n = 1;
	Node* first = head;

	// find last node in the list
	Node* second = head;
	while(second->next!=nullptr){
		second = second->next; ++n;
	}

	// convert linked list to xor doubly linked list
	convert_to_xor_linked_list(head);

	// find last node in the linked list
	// Node* second = find_last_node(head);

	Node* first_prev = nullptr;
    Node* second_next = nullptr;

    int max_sum = 0;
    int mid = n%2 != 0 ? (n/2)+1 : -1;
    while(n>0){
		if(n==mid) break;	// in case the list in odd, so we don't count the middle item twice

		int af = first->val;
		int bf =second->val;

		max_sum = max(first->val + second->val, max_sum);

		Node* first_temp = first;
		first = get_xor(first_prev, first->next);
		first_prev = first_temp;

		Node* second_temp = second;
		second = get_xor(second_next, second->next);
		second_next = second_temp;

		--n;
    }

    return max_sum;
}

void solve()
{
	int arr[] = {1,4,3,2}; int n = sizeof(arr)/sizeof(int);
	Node* head = buildLinkedTree(arr,n);

	cout << get_max_pair_sum(head);
}

#endif // _LINKED_LIST_SUM_H_INCLUDED
