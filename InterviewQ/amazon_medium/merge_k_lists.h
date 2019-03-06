#ifndef MERGE_K_LISTS_H_INCLUDED
#define MERGE_K_LISTS_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/merge-k-sorted-linked-lists/1
struct Node
{
    int data;
    Node* next;

    Node(int d){
        this->data = d;
        this->next = nullptr;
    }
};

class myComparator{
public:
    int operator() (const Node* p1, const Node* p2)
    {
        return p1->data >= p2->data;
    }
};

void mt(){

    Node* n1 = new Node(1);
    Node* n2 = new Node(20);
    Node* n3 = new Node(30);
    n1->next = n2;
    n2->next = n3;

    Node* n4 = new Node(4);
    Node* n5 = new Node(15);
    n4->next = n5;

    Node* n6 = new Node(6);
    Node* n7 = new Node(7);
    n6->next = n7;

    int N = 3;
    Node* arr[] = {n1,n4,n6};
    std::priority_queue<Node*, std::vector<Node*>,myComparator>pq(arr, arr+N);

    Node* _n = pq.top();
    pq.pop();
    Node* root = new Node(_n->data);
    _n = _n->next;
    if(_n != nullptr){
        pq.push(_n);
    }

    Node* myroot = root;

    while(!pq.empty()){
        _n = pq.top();
        pq.pop();
        int a = _n->data;
        root->next = new Node(_n->data);
        root = root->next;
        _n = _n->next;
        if(_n != nullptr){
            pq.push(_n);
        }
    }

    delete _n;
    while(myroot != nullptr){
        cout << myroot->data << " ";
        myroot = myroot->next;
    }
}

#endif // MERGE_K_LISTS_H_INCLUDED
