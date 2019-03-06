#ifndef TREE_TOP_VIEW_H_INCLUDED
#define TREE_TOP_VIEW_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/top-view-of-binary-tree/1

struct Node
{
    int data;
    struct Node* left;
    struct Node* right;

    Node(int d){
        this->data = d;
        this->left = nullptr;
        this->right = nullptr;
    }
};

// key: column, value: level-data
map<int,pair<int,int>> mp;

void bfs(Node* n, int column){
    int level = 0;
    queue<pair<int,Node*>> qu;
    auto tp = make_pair(0,n);
    qu.push(tp);

    while(!qu.empty()){
        pair<int,Node*> p = qu.front();
        qu.pop();
        int col = p.first;
        Node* n = p.second;
        if(mp.find(col) == mp.end()){
            mp[col] = make_pair(level,n->data);
        }
        if(n->left != nullptr){qu.push(make_pair(col-1,n->left));}
        if(n->right != nullptr){qu.push(make_pair(col+1,n->right));}

        delete n;   // nice
        ++level;
    }
}

bool compare(pair<int,int> a, pair<int,int> b){

    return a.first <= b.first;
}

void driver(){

    Node* n1 = new Node(10);
    Node* n2 = new Node(20);
    Node* n3 = new Node(30);
    Node* n4 = new Node(40);
    Node* n5 = new Node(60);
    Node* n6 = new Node(90);
    //Node* n7 = new Node(7);

    n1->left = n2;
    n1->right =n3;

    n2->left=n4;
    n2->right=n5;

    n3->left=n6;
    //n3->right=n7;

    bfs(n1,0);

    vector<pair<int,int>> vec;
    for(std::map<int,pair<int,int>>::iterator it = mp.begin(); it != mp.end(); ++it){
        vec.push_back(it->second);
    }

    sort(vec.begin(),vec.end(),compare);

    for(std::vector<pair<int,int>>::iterator it = vec.begin(); it != vec.end(); ++it){
        cout << it->second << " ";
    }

    vec.clear();
    mp.clear();
}


#endif // TREE_TOP_VIEW_H_INCLUDED
