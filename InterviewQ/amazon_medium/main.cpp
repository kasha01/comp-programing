#include <iostream>
#include<cstring>
#include<algorithm>
#include<vector>
#include<queue>
#include<stack>
#include<list>
#include<math.h>
#include<sstream>
#include<set>
#include<map>
#include<iomanip>

using namespace std;

struct Node{
    int data;
    Node* next;

    Node(int d){
        this->data = d;
        this->next = nullptr;
    }

};

int main(){

    Node* n1 = new Node(10);
    Node* n2 = new Node(20);
    Node* n3 = new Node(30);
    Node* n4 = new Node(40);

    n1->next = n2;
    n2->next = n3;
    n3->next = n4;

    Node* x1 = n1;

    cout << n1->data << endl;

    cout << x1->data << endl;

    n1->data = 44;

    //n1 = n1->next;

    cout << n1->data << endl;

    cout << x1->data << endl;

    return 0;
}
