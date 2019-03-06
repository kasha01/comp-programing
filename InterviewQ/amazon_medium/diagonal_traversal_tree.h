#ifndef DIAGONAL_TRAVERSAL_TREE_H_INCLUDED
#define DIAGONAL_TRAVERSAL_TREE_H_INCLUDED


// https://practice.geeksforgeeks.org/problems/diagonal-traversal-of-binary-tree/1
struct Node
{
    int data;
    Node *left, *right;
    Node(int d){
        this->data = d;
        this->left = nullptr;
        this->right = nullptr;
    }
};

map<int,vector<int>> mp;
void inorder(Node* n, int d){
    if(n == nullptr){return;}
    inorder(n->left,d+1);
    mp[d].push_back(n->data);
    inorder(n->right,d);
}

void driver(){

    Node* n8 = new Node(8);
    Node* n10 = new Node(10);
    Node* n14 = new Node(14);
    Node* n13 = new Node(13);
    Node* n3 = new Node(3);
    Node* n6 = new Node(6);
    Node* n7 = new Node(7);
    Node* n1 = new Node(1);
    Node* n4 = new Node(4);

    n8->right = n10;
    n10->right = n14;
    n14->left=n13;
    n8->left=n3;
    n3->right=n6;
    n3->left=n1;
    n6->right= n7;
    n6->left=n4;

    inorder(n8,0);

    for(std::map<int,vector<int>>::iterator it=mp.begin(); it!=mp.end(); ++it){
        vector<int> vec = it->second;
        for(int i=0;i<vec.size();++i){
            cout << vec[i] << " ";
        }
        it->second.clear();
    }
    mp.clear();

    return 0;
}


// not mine but pretty smart
void diagonalPrint(Node *root)
{

   // your code here
   if(root==0)return;
   Node* x;
   queue<Node *>q;
   q.push(root);

   while(!q.empty())
   {
       int n=q.size();
       while(n--)
       {
           x=q.front();
           q.pop();
           while(x!=0)
           {
               cout<<x->data<<" ";
               if(x->left!=0)q.push(x->left);
               x=x->right;
           }
       }
   }
}

#endif // DIAGONAL_TRAVERSAL_TREE_H_INCLUDED
