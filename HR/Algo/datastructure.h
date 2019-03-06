#ifndef DATASTRUCTURE_H_INCLUDED
#define DATASTRUCTURE_H_INCLUDED


struct LNode{
public:
    int value;
    LNode* next;

    LNode(int v){
        this->next = nullptr;
        this->value = v;
    }
};

class LinkedList{
public:
    int lsize=0;
    LNode* head = NULL;
    LNode* current = NULL;

    LinkedList(){}

    LinkedList(int init_v){
        LNode* n = new LNode(init_v);
        head = n;
        current = head;
    }

    void insert_node(int v){
        lsize++;
        LNode* n = new LNode(v);
        if(head == nullptr){
            head=n;
            current = head;
        }else{
            current->next = n;
            current = n;
        }
    }

    void insert_node2(int v){
        if(head !=NULL){
            LNode* n = new LNode(v);
            current->next = n;
            current = n;
        }
    }

    void insert_atpos(int v, int pos){

        if(pos > lsize + 1){return;}

        lsize++;
        //naive approach
        current = head;
        LNode* prev = NULL;
        while(pos>1){
            prev = current;
            current = current->next;
            pos--;
        }

        //create new node
        LNode* n = new LNode(v);
        //insert
        if(prev!=NULL){
            prev->next = n;
        }else{
            head = n;
        }
        n->next = current;
    }
};

void LinkedListDriver(){
    int arr[] = {1,2,3,4,5,6};
    LinkedList ll;
    for(int i=1;i<7;i++){
        ll.insert_node(i);
    }

    ll.insert_atpos(100,7);


    for(int i=0;i<ll.lsize;i++){
        cout << ll.head->value << " ";
        ll.head = ll.head->next;
    }

}
#endif // DATASTRUCTURE_H_INCLUDED
