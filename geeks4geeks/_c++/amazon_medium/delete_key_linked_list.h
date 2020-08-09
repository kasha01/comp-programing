#ifndef DELETE_KEY_LINKED_LIST_H_INCLUDED
#define DELETE_KEY_LINKED_LIST_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/delete-keys-in-a-linked-list/1

struct Node{
    int data;
    Node* next;

    Node(int d){
        this->data = d;
        this->next = nullptr;
    }

};

Node* deleteAllOccurances(Node *head,int x)
{
    if(head==nullptr)
        return nullptr;

    Node* k = deleteAllOccurances(head->next,x);

    if(head->data == x){
        head = nullptr;
        delete head;
        return k;
    }
    else{
        head->next = k;
        return head;
    }
}

void test(){

    Node* n1 = new Node(2);
    Node* n2 = new Node(4);
    Node* n3 = new Node(1);
    Node* n4 = new Node(2);
    Node* n5 = new Node(4);

    n1->next = n2;
    n2->next = n3;
    n3->next = n4;
    n4->next = n5;

    int x = 2;
    Node* head = deleteAllOccurances(n1,x);

    while(head!=nullptr){
        cout << head->data << " ";
        head = head->next;
    }

    return 0;
}


#endif // DELETE_KEY_LINKED_LIST_H_INCLUDED
