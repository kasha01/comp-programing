#ifndef MAX_LEVEL_SUM_IN_BINARY_TREE_H_INCLUDED
#define MAX_LEVEL_SUM_IN_BINARY_TREE_H_INCLUDED

struct Node{
public:
    int data = 0;
    Node* left = nullptr;
    Node* right = nullptr;

    Node(int d){
        this->data = d;
        this->left = nullptr;
        this->right = nullptr;
    }
};

map<int,int> mp;

class Tree{
public:
    Node* root = nullptr;
    void sumLevels(Node* n, int l);
};

void Tree::sumLevels(Node* n, int l){
    if(n == nullptr){return;}

    l++;
    sumLevels(n->left,l);
    sumLevels(n->right,l);
    int ll = l;
    int nn = n->data;
    if(mp.find(l) == mp.end()){
        // not found
        mp[l] = n->data;
    }else{
        mp[l] = mp[l] + n->data;
    }
}

void get_max_level_sum(){

    // Driver
    Tree t;
    Node* root = new Node(1);
    root->left = new Node(2);
    root->right = new Node(3);
    root->left->left = new Node(4);
    root->left->right = new Node(5);
    root->right->right = new Node(8);
    root->right->right->right = new Node(7);
    root->right->right->left = new Node(6);

    t.root = root;

    // Get Levels Sum
    t.sumLevels(root,-1);

    mp.clear(); // in case of multiple test cases
    int mx = 0;
    for(map<int,int>::iterator it = mp.begin(); it!=mp.end(); it++){
        cout << it->first << " --> " << it->second << endl;
        if(mx < it->second){mx = it->second;}
    }

    cout << mx;
}


#endif // MAX_LEVEL_SUM_IN_BINARY_TREE_H_INCLUDED
