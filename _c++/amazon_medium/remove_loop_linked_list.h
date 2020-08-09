#ifndef REMOVE_LOOP_LINKED_LIST_H_INCLUDED
#define REMOVE_LOOP_LINKED_LIST_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/remove-loop-in-linked-list/1

// use tortoise and hare
struct Node
{
    int data;
    Node* next;

    Node(int v){
        this->data = v;
    }
};

void mt(){

    Node* root = new Node(1);
    Node* n2 = new Node(2);
    Node* n3 = new Node(3);
    Node* n4 = new Node(4);
    Node* n5 = new Node(5);

    root->next = n2;
    n2->next = n3;
    n3->next = n4;
    n4->next = n5;
    n5->next = n2;


    Node* tortois = root;
    Node* hare = root;

    // init
    if(tortois && hare && hare->next && hare->next->next){
        tortois = tortois->next;
        hare = hare->next->next;
    }

    while(tortois != hare && tortois && hare && hare->next && hare->next->next){
        tortois = tortois->next;
        hare = hare->next->next;
    }

    // loop is removed - the loop always starts where hare and tortois meet
    hare->next = nullptr;

    return 0;
}


#endif // REMOVE_LOOP_LINKED_LIST_H_INCLUDED
