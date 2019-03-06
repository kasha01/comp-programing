#include <iostream>
#include <vector>
#include <map>
#include <string>
#include <algorithm>
#include <set>
#include <cassert>
using namespace std;

/*see: https://www.hackerrank.com/challenges/abstract-classes-polymorphism */

struct Node{
   Node* next;
   Node* prev;
   int value;
   int key;
   Node(Node* p, Node* n, int k, int val):prev(p),next(n),key(k),value(val){};
   Node(int k, int val):prev(NULL),next(NULL),key(k),value(val){};
};

class Cache{

   protected:
   map<int,Node*> mp; //map the key to the node in the linked list
   int cp;  //capacity
   Node* tail; // double linked list tail pointer
   Node* head; // double linked list head pointer
   virtual void set(int, int) = 0; //set function
   virtual int get(int) = 0; //get function

};


class LRUCache : public Cache {
public:
    LRUCache(int c){
        this->cp = c;
        this->head = NULL;
        this->tail = NULL;
    }

    int get(int k){
        if(mp.find(k) == mp.end()){
            //Cashe miss
            return -1;
        }
        else{
            Node* hitNode = mp[k];              //Get HitNode
            hitNode->prev = NULL;               // HitNode will become the new Head, so it has No Prev
            hitNode->next = this->head;         // HitNode will move to the Head, so current HitNode.Next points to Current Head
            head->prev = hitNode;               // and current Head.prev points to HitNode: Null <-- HitNode --> CurrentHead

            // if HitNode was adjacent/after Original Head:
            if(hitNode->prev == this->head){
                //need to relink original head to the node following the HitNode
                head->next = hitNode->next;
            }

            // if HitNode was adjacent/Before the Tail:
            if(hitNode->next == this->tail){
                // need to relink the tail to the Node Prior to HitNode
                this->tail->prev = hitNode->prev;
            }
            head = hitNode;                     //Assign the HitNode as the new Head
            return this->mp[k]->value;          //Return HitNode Value
        }
    }

    void set(int k, int v){
        if(this->head == NULL)
        {  //First Node to insert - Node will be the Head
           this->mp[k] = new Node(k,v);
           this->head = mp[k];
        }
        else if(this->tail == NULL){
            //Second Node to insert -Now we can have a Tail:        //  Null <-- NewNode --> OldHead --> Tail -->Null

            this->mp[k] = new Node(NULL,this->head,k,v);            //Create the new Node, new Node will go on top of the current Head
            this->tail = this->head;                                //Old Head becomes the Tail
            this->tail->prev = this->mp[k];                         //Tail.prev Now points to the New Node which is also the
            this->head = this->mp[k];                               //New Node becomes the Head
        }
        else{
            this->mp[k] = new Node(NULL,this->head,k,v);           //Create New Node: Null <-- New Node --> Old Head --> ... --> Tail --> Null
            this->head->prev = mp[k];                               // Old Head.Prev points to New Node
            this->head = this->mp[k];   //new key becomes head      //New Node becomes the Head

            //check capacity- if map has went over cache capacity
            if(mp.size() > this->cp){
                // need to pop the tail
                int e = this->tail->key;            //Get the key of the current tail
                this->tail = this->tail->prev;      //Move Tail Pointer UP, the new Tail is now the Node Prior to Old Tail
                this->tail->next = NULL;            //New Tail.next should point to NULL.
                this->mp.erase(e);                  // Erase Old Tail
            }
        }
    }
};

int main() {
   int n, capacity,i;
   cin >> n >> capacity;
   LRUCache l(capacity);
   for(i=0;i<n;i++) {
      string command;
      cin >> command;
      if(command == "get") {
         int key;
         cin >> key;
         cout << l.get(key) << endl;
      }
      else if(command == "set") {
         int key, value;
         cin >> key >> value;
         l.set(key,value);
      }
   }
   return 0;
}
