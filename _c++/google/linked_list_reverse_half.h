#ifndef LINKED_LIST_REVERSE_HALF_H_INCLUDED
#define LINKED_LIST_REVERSE_HALF_H_INCLUDED

// print linked list 1->2->3->4->5 as ==> 1,5,2,4,3 outside->inward
struct Node{
	int data;
	Node* next;
	Node(int d, Node* n){
		this->data = d;
		this->next = n;
	}
};

Node* p;
int c=0;
void rev(Node* n){
	if(n == nullptr)
		return;

	c++;

	rev(n->next);
	if(c<=0){
		return;
	}

	if(n==p){
		cout << p->data << " ";
	}
	else{
		cout << p->data << " " << n->data << " ";
	}

	p=p->next;
	c=c-2;
}

// print normally
void go(Node* n){
	Node* p1 = n;
    while(p1){
		cout << p1->data;
		p1 = p1->next;
    }
}

void test()
{
	Node* n6 = new Node(6,nullptr);
	Node* n5 = new Node(5,n6);
	Node* n4 = new Node(4,n5);
	Node* n3 = new Node(3,n4);
	Node* n2 = new Node(2,n3);
	Node* n1 = new Node(1,n2);

	p=n1;
	rev(n1);

    return 0;
}

#endif // LINKED_LIST_REVERSE_HALF_H_INCLUDED
