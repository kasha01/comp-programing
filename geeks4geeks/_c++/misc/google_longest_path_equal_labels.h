#ifndef GOOGLE_LONGEST_PATH_EQUAL_LABELS_H_INCLUDED
#define GOOGLE_LONGEST_PATH_EQUAL_LABELS_H_INCLUDED

// https://www.geeksforgeeks.org/google-interview-experience-set-7-software-engineering-intern/

struct Node{
    int index;
    int label;

    Node* left;
    Node* right;

    Node(int l, int i){
        this->index = i;
        this->label = l;
        this->left = nullptr;
        this->right = nullptr;
    }
};

int similar_labels_bfs(Node* n, int dist){

    int s = dist;

    int ll = n->label;
    int dd = n->index;

    Node* adj = nullptr;
    for(int i=0;i<2;++i){
        if(i==0){adj = n->left;}
        else{adj = n->right;}

        if(!adj){continue;}

        if(adj->label == n->label){
            s = similar_labels_bfs(adj,s+1);
        }
        else{
            s = similar_labels_bfs(adj,1);
        }
    }
    s = max(s,dist);
    return s;
}

void driver()
{
    Node* n1 = new Node(1,1);
    Node* n2 = new Node(1,2);
    Node* n3 = new Node(1,3);
    Node* n4 = new Node(2,4);
    Node* n5 = new Node(2,5);

    n1->left = n2;
    n1->right = n3;
    n2->left = n4;
    n2->right = n5;

    cout << similar_labels_bfs(n1,1);
}

#endif // GOOGLE_LONGEST_PATH_EQUAL_LABELS_H_INCLUDED
