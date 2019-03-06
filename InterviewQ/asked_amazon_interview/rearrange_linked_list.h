#ifndef REARRANGE_LINKED_LIST_H_INCLUDED
#define REARRANGE_LINKED_LIST_H_INCLUDED

// https://www.geeksforgeeks.org/rearrange-a-given-linked-list-in-place/
// Geeksforgeeks has a cleaner solution which splits and linked list into two halves (using hare and turtle)
// and reverse the second half, then join together
class Node{
public:
    int data;
    Node* next;

    Node(int d){
        this->data = d;
        this->next = nullptr;
    }
};


static Node* temp = nullptr;
static Node* _head; static bool flag = false;
void mt(Node* h)
{
    if (h==nullptr)
        return;

    mt(h->next);
    if (flag) { return; }

    int h1 = h->data; int hh = _head->data; int hn = _head->next->data;
    if (h == _head) { _head->next = nullptr; flag = true; return; }
    else if (_head->next == h)
    {
        flag = true;
        temp = nullptr;
    }
    else
    {
        temp = _head->next;
    }
    _head->next = h;
    h->next = temp;
    _head = temp;
}

void driver(){

    int arr[5] = {1,2,3,4,5};
    Node* myHead = new Node(arr[0]);
    _head = myHead;
    Node* mytemp = myHead;

    for(int i=1;i<5;i++){
        Node* t = new Node(arr[i]);
        mytemp->next = t;
        mytemp = mytemp->next;
    }

    // delete mytemp; I cannot delete my temp b/c mytemp is now pointing at memory address of the last item in
    // arr = 5, so I increment mytemp, now it's pointing at some bogus memory address and then delete it.
    mytemp++;
    delete mytemp;

    mt(_head);
    for(int i=0;i<5;i++){
        cout << myHead->data << " ";
        myHead = myHead->next;
    }

    return 0;
}


#endif // REARRANGE_LINKED_LIST_H_INCLUDED
