#ifndef EXTRA_H_INCLUDED
#define EXTRA_H_INCLUDED

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
    int getLevel(Node* n);
    int getHeight(Node* n);
    Node* getNode(Node* n, int d);
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
        node = Balance(node);
    }
    else if(d < node->data){
        node->left = insert_rc(node->left,d,++l);
        node = Balance(node);
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
}

int Tree::getLevel(Node* n){
    if(n == nullptr){
        return 0;
    }
    int lh = getLevel(n->left);
    int rh = getLevel(n->right);
    return max(lh,rh) + 1;
}

int Tree::getHeight(Node* n){
    int h = 0;
    if(n == nullptr){
        return 0;
    }
    if(n->left != nullptr || n->right != nullptr){h++;}
    int lh = getHeight(n->left);
    int rh = getHeight(n->right);
    return max(lh,rh) + h;
}

void Tree::sumLevels(Node* n, int l){
    if(n == nullptr){return;}

    sumLevels(n.left,l++);
    sumLevels(n.right,l++);
}

#endif // EXTRA_H_INCLUDED
