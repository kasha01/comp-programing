#ifndef MERGE_TWO_BST_H_INCLUDED
#define MERGE_TWO_BST_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/merge-two-bst-s/1

class Node{
public:
    Node* left;
    Node* right;
    int data;

    Node(int v){
        this->right = nullptr;
        this->left = nullptr;
        this->data = v;
    }
};

void inorder(Node* root, vector<int>& vec){
    if(root == nullptr){return;}
    inorder(root->left, vec);
    vec.push_back(root->data);
    inorder(root->right,vec);
}

void driver()
{
    int sz1=2; int sz2=2;
    Node* root1 = new Node(1);
    root1->right = new Node(33);
    root1->right->left = new Node(4);

    Node* root2 = new Node(6);
    root2->right = new Node(7);
    root2->left = new Node(1);

    vector<int> vec1;
    vector<int> vec2;
    inorder(root1, vec1);
    for(int i=0;i<sz1;i++){cout << vec1[i] << " ";}
    cout << endl;

    inorder(root2, vec2);
    for(int i=0;i<sz2;i++){cout << vec2[i] << " ";}

    cout << endl;
    int j=0; int i=0;
    while(i<vec1.size() || j<vec2.size()){
        if(j>=vec2.size()){
            cout << vec1[i] << " "; i++;
        }
        else if(i>=vec1.size()){
            cout << vec2[j] << " "; j++;
        }
        else if(vec1[i] <= vec2[j]){
            cout << vec1[i] << " ";
            i++;
        }
        else{
            cout << vec2[j] << " "; j++;
        }
    }
}


#endif // MERGE_TWO_BST_H_INCLUDED
