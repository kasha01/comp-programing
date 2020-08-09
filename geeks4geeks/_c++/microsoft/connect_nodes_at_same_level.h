#ifndef CONNECT_NODES_AT_SAME_LEVEL_H_INCLUDED
#define CONNECT_NODES_AT_SAME_LEVEL_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/connect-nodes-at-same-level/1
struct Node
{
  int data;
  Node *left,  *right;
  Node *nextRight;  // This has garbage value in input trees
};

// time:O(N) - space:O(1)
void connect(Node *p)
{
    queue<Node*> myq;
    myq.push(p);

    while(!myq.empty()){
        int k = myq.size();
        Node* prev = nullptr;
        for(int i=0;i<k;++i){
            Node* n = myq.front();
            myq.pop();
            n->nextRight = nullptr;

            if(n->left != nullptr){
                myq.push(n->left);
            }

            if(n->right != nullptr){
                myq.push(n->right);
            }

            if(prev != nullptr){
                prev->nextRight = n;
            }
            prev = n;
        }
    }
}


#endif // CONNECT_NODES_AT_SAME_LEVEL_H_INCLUDED
