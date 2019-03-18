#ifndef DUPLICATE_SUBTREE_IN_BT_H_INCLUDED
#define DUPLICATE_SUBTREE_IN_BT_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/duplicate-subtree-in-binary-tree/1

// the idea is the Hash set will have a 3 chars string of the head node + r.node + l.node.
// if the same combination exists --> set flag to true
// in this question a segment head--one branch is considered a valid subtree. therefore I am only skpping the case when
// both c1 and c2 are '!' null.
class Node{
public:
    Node* left;
    Node* right;
    char data;

    Node(char v){
        this->right = nullptr;
        this->left = nullptr;
        this->data = v;
    }
};

std::stringstream ss;
set<string> st;
char preorder(Node* root, bool& flag){
    if(flag){return '\0';}
    if(root == nullptr){return '!';}

    char c = root->data;
    //cout << root->data << " ";
    char c1 = preorder(root->left,flag);
    char c2 = preorder(root->right,flag);
    if(c1 == '!' && c2 == '!'){
        // skip
    }
    else{
        ss.flush();
        ss << c << c1 << c2;
        string mys = ss.str();
        ss.str("");
        cout << mys << endl;
        if(st.find(mys)==st.end()){
            st.insert(mys);
        }
        else{
            flag = true;
        }
    }
    return root->data;
}

void driver(){
    Node* root = new Node('A');
    root->left = new Node('B');
    root->right = new Node('C');
    root->left->left = new Node('D');
    root->left->right = new Node('E');

    root->right->right = new Node('B');
    root->right->right->right = new Node('E');
    root->right->right->left = new Node('D');
    bool flag = false;
    preorder(root,flag);
    cout << flag;
}
#endif // DUPLICATE_SUBTREE_IN_BT_H_INCLUDED
