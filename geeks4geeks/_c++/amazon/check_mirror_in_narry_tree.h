#ifndef CHECK_MIRROR_IN_NARRY_TREE_H_INCLUDED
#define CHECK_MIRROR_IN_NARRY_TREE_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/check-mirror-in-n-ary-tree/0

class Node{
public:
    Node(int d){
        this->data = d;
    }
    int data;
    stack<Node*> st;
    queue<Node*> qu;
};


void check_mirror_easy_approach(){
    int t = 0; cin >> t;
    while(t>0){
        t--;

        int n = 0; int e = 0;
        cin >> n >> e;

        if(n<2){cout << 1 << endl; continue;}
        Node* arr[n];

        // build nodes array
        for(int i=1; i<=n;i++){
            arr[i-1] = new Node(i);
        }

        // build edge arrays
        int u=0; int v=0;
        for(int i=0;i<e;i++){
            cin >> u >> v;
            Node* mynode = arr[u-1];
            mynode->st.push(arr[v-1]);
        }
        for(int i=0;i<e;i++){
            cin >> u >> v;
            Node* mynode = arr[u-1];
            mynode->qu.push(arr[v-1]);
        }

        bool flag = true;
        for(int i=0;i<n;i++){
            Node* mynode = arr[i];
            while(!mynode->st.empty() && !mynode->qu.empty()){
                int s = mynode->st.top()->data ; int q = mynode->qu.front()->data;
                if(mynode->st.top()->data == mynode->qu.front()->data){
                    mynode->st.pop();mynode->qu.pop();
                }
                else{
                    flag = false;
                    break;
                }
            }
            if(!mynode->st.empty() || !mynode->qu.empty()){
                flag = false;
                break;
            }
        }
        cout << flag << endl;
        for(int i=0; i<n;i++){
            delete arr[i];
        }
    }
};

void check_mirror_flexible_node_data_approach()
{
    int t = 0; cin >> t;
    while(t>0){
        t--;

        int n = 0; int e = 0;
        cin >> n >> e;
        map<int,Node*> mp;

        // build edge arrays
        int u=0; int v=0;
        for(int i=0;i<e;i++){
            cin >> u >> v;
            if(mp.find(u) == mp.end()){mp[u] = new Node(u);}
            if(mp.find(v) == mp.end()){mp[v] = new Node(v);}

            Node* mynode = mp[u];
            mynode->st.push(mp[v]);
        }
        for(int i=0;i<e;i++){
            cin >> u >> v;
            Node* mynode = mp[u];
            mynode->qu.push(mp[v]);
        }

        bool flag = true;
        for(map<int,Node*>::iterator it=mp.begin(); it!=mp.end();it++){
            Node* mynode = it->second;
            while(!mynode->st.empty() && !mynode->qu.empty()){
                int s = mynode->st.top()->data ; int q = mynode->qu.front()->data;
                if(mynode->st.top()->data == mynode->qu.front()->data){
                    mynode->st.pop();mynode->qu.pop();
                }
                else{
                    flag = false;
                    break;
                }
            }
            if(!mynode->st.empty() || !mynode->qu.empty()){
                flag = false;
                break;
            }
        }
        cout << flag << endl;
        mp.clear();
    }
}

#endif // CHECK_MIRROR_IN_NARRY_TREE_H_INCLUDED
