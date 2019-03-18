#ifndef CONNECT_NODES_AT_SAME_LEVEL_H_INCLUDED
#define CONNECT_NODES_AT_SAME_LEVEL_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/connect-nodes-at-same-level/1
class Node{
public:
    Node* left;
    Node* right;
    Node* nextRight;
    int data;

    Node(int v){
        this->right = nullptr;
        this->left = nullptr;
        this->data = v;
        this->nextRight = nullptr;
    }
};

// my solution - using O(N) space
void postorder(Node* n, int l, map<int,vector<Node*>>& mp){
    if(n == nullptr){return;}
    int level = l+1;
    postorder(n->left,level, mp);
    postorder(n->right,level,mp);

    if(mp.find(level) == mp.end()){
        // not found
        vector<Node*> v; v.push_back(n);
        mp[level] = v;
    }
    else {
        mp[level].push_back(n);
    }
}


// clever solution - THANKS TO HARI KRISHNAN
void connect(Node *p)
{
   // Your Code Here
   if(p->left && p->right){
          p->left->nextRight=p->right;          // connect my left branch to my right branch
          if(p->nextRight)
          p->right->nextRight=p->nextRight->left; // connect the two subtrees (connects the right branch of subtree to
                                                    // to the left branch of the adjacent subtree)
   }

   if(p->left)
   connect(p->left);
   if(p->right)
   connect(p->right);
}

void driver()
{
    Node* root = new Node(10);
    root->left = new Node(5);
    root->right = new Node(50);
    root->right->right = new Node(100);
    root->right->left = new Node(40);
    root->left->left = new Node(1);

    map<int,vector<Node*>> mymap;
    postorder(root,0,mymap);

    for(map<int,vector<Node*>>::iterator it = mymap.begin(); it!=mymap.end(); it++){
        int s = it->second.size();
        for(int i=0;i<s-1;i++){
            it->second[i]->nextRight = it->second[i+1];
        }
    }

    Node* firstnode;
    for(map<int,vector<Node*>>::iterator it = mymap.begin(); it!=mymap.end(); it++){
        firstnode = it->second[0];
        while(firstnode != nullptr){
            cout << firstnode->data << " ";
            firstnode = firstnode->nextRight;
        }
        it->second.clear();
        cout << endl;
    }
}

#endif // CONNECT_NODES_AT_SAME_LEVEL_H_INCLUDED
