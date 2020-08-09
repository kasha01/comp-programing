#ifndef DELETE_WITHOUT_HEAD_POINTER_H_INCLUDED
#define DELETE_WITHOUT_HEAD_POINTER_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/delete-without-head-pointer/1

class Node
{
public:
    int data;
    Node* next;
    Node(int v){
		this->data = v;
    }
};

void solve()
{
    Node* n0 = new Node(10);
    Node* n1 = new Node(20);
    Node* n2 = new Node(4);
    Node* n3 = new Node(30);

    n0->next = n1;
    n1->next = n2;
    n2->next = n3;
    n3->next = nullptr;

	Node* node = n1;

	Node * temp = node->next;
    node->data = node->next->data;
    node->next = temp->next;
    delete temp;
	temp = nullptr;

    while(n0){
		cout << n0->data << " ";
		n0=n0->next;
    }
}


#endif // DELETE_WITHOUT_HEAD_POINTER_H_INCLUDED
