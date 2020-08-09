#ifndef FACEBOOK_CODING_PRACTISE_H_INCLUDED
#define FACEBOOK_CODING_PRACTISE_H_INCLUDED

// https://www.facebookrecruiting.com/portal/coding_practice_question/?problem_id=495004218121393
struct Node {
  int data;
  Node* left ;
  Node* right;
  Node() {
    data = 0;
    left = NULL;
    right = NULL;
  }
  Node(int data) {
    this->data = data;
    this->left = NULL;
    this->right = NULL;
  }
};
// Add any helper functions you may need here
std::map<int,int> mp;

void visibleNodes(Node* root, int l) {
  // Write your code here
  if(root == NULL){
    return;
  }
  int x = l+1;
  visibleNodes(root->left, x);
  visibleNodes(root->right,x);

  if(mp.find(l) == mp.end()){
    mp[l] = 1;
  }
}
int visibleNodes(Node* root) {
  // Write your code here
  mp.clear();
  visibleNodes(root,0);
  return mp.size();
}


#endif // FACEBOOK_CODING_PRACTISE_H_INCLUDED
