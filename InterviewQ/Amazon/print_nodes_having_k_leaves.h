#ifndef PRINT_NODES_HAVING_K_LEAVES_H_INCLUDED
#define PRINT_NODES_HAVING_K_LEAVES_H_INCLUDED

#define nullptr NULL

using namespace std;

struct Node{
public:
    int data = 0;
    Node* left = nullptr;
    Node* right = nullptr;
    int level = 0;

    Node(int d, int l){
        this->data = d;
        this->level = l;
        this->left = nullptr;
        this->right = nullptr;
    }

    friend ostream& operator<<(ostream& op, Node* n){
        op << "Level:" << n->level << " " << n->data;
        return op;
    }
};

class Tree{
public:
    Node* root = nullptr;
    void insertNode(int d);
    void Display();
    int countleaves(Node* n);
    Node* getNode(Node* n, int d);
    int perfNode = -1;
    bool flag = false;
private:
    Node* insert_rc(Node* node, int d, int l);
};

void Tree::insertNode(int d){
    if(this->root != nullptr){
        Tree::insert_rc(this->root, d, 1);
    }
    else{
        this->root = new Node(d,1);
    }
};

Node* Tree::insert_rc(Node* node, int d, int l){
    if(node == nullptr){
        return new Node(d,l);
    }
    else if(d >=node->data){
        node->right = insert_rc(node->right,d,++l);
    }
    else if(d < node->data){
        node->left = insert_rc(node->left,d,++l);
    }
    return node;
};

void Tree::Display(){
    queue<Node*> q;
    q.push(this->root);

    while(!q.empty()){
        Node* n = q.front();
        q.pop();

        if(n != nullptr){
            Node* l = n->left;
            Node* r = n->right;

            //cout << n->level << ": " << n->data << endl;
            cout << n << endl;
            q.push(l);q.push(r);
        }
    }
};

Node* Tree::getNode(Node* n, int d){
    if(n->data == d){return n;}
    else if(d >= n->data){return getNode(n->right,d); }
    else if(d < n->data){return getNode(n->left,d); }
};

int Tree::countleaves(Node* n){
    if(n==nullptr){return 0;}
    if(flag){return 0;}
    int l = countleaves(n->left);
    int r = countleaves(n->right);
    int sum = l+r;

    if(sum == 2){
        //perfNode = n->data; flag = true;
        return n->data;
    }else if(sum == 0){
        return 1;
    }
    else {
        return sum;
    }
}

#endif // PRINT_NODES_HAVING_K_LEAVES_H_INCLUDED
