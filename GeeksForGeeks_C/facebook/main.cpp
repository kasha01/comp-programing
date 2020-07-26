#include <bits/stdc++.h>

using namespace std;

struct node
{
	int data;
	struct node* next;

	node(int x){
		data = x;
		next = nullptr;
	}
};

void rev(node* n, int k){
    if(n->next == nullptr || ){
		return;
    }

    rev(n->next, ++k);


}

int main(){
	return 0;
}
