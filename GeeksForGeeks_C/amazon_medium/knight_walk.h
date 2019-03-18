#ifndef KNIGHT_WALK_H_INCLUDED
#define KNIGHT_WALK_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/knight-walk/0
class Node{
public:
    int x;
    int y;
    int dist;
    bool visited;

    Node(int x,int y){
        this->x=x;
        this->y=y;
        this->dist=0;
        this->visited=false;
    }
};

bool get_adjacent(int x, int y, Node*** arr, int d, queue<Node*> &q, int const &n, int const &m, int const &tx, int const &ty){
    if(x<0 || x>=n || y<0 || y>=m){
        return false;
    }

    if(arr[x][y]->visited){
        // node was visited
        return false;
    }

    arr[x][y]->dist = d + 1;

    if(x==tx && y==ty){
        // this is the target square - I am doing BFS, so the first one reaches the target is the shortest path
        // (first calculation of square is the shortest/min one)
        return true;
    }

    q.push(arr[x][y]);
    return false;
}

void mt()
{
    int n=4; int m=7;

    int sx=2; int sy=6;
    int tx=2; int ty=4;

    // remember the input starts from square one = 1, whereas I deal with indexes [0 - n-1]
    sx=sx-1;sy=sy-1;tx=tx-1;ty=ty-1;

    // edge cases
    if(sx<0 || sx>=n || sy<0 || sy>=m ||
        tx<0 || tx>=n || ty<0 || ty>=m){
            // invalid input
            cout << -1 << endl;
            return; // end program
    }
    if(sx == tx && sy == ty){
        // source == target
        cout << 0 << endl;
        return; // end program
    }

    Node*** arr = new Node**[n];
    for(int i=0;i<n;i++){
        arr[i] = new Node*[m];
        for(int j=0;j<m;j++){
            arr[i][j] = new Node(i,j);
        }
    }

    // set source square distance
    queue<Node*> q;
    Node* myNode = arr[sx][sy];
    myNode->dist = 0;
    q.push(myNode);

    // set target square distance = -1 as no such move is possible.
    arr[tx][ty]->dist = -1;

    while(!q.empty()){
        myNode = q.front();
        q.pop();
        myNode->visited = true; // mark as visited.
        int x=myNode->x;
        int y=myNode->y;

        // get adjacent (8)
        int d = myNode->dist;
        if(
        get_adjacent(x+2,y+1,arr,d,q,n,m,tx,ty) ||
        get_adjacent(x+2,y-1,arr,d,q,n,m,tx,ty) ||
        get_adjacent(x-2,y+1,arr,d,q,n,m,tx,ty) ||
        get_adjacent(x-2,y-1,arr,d,q,n,m,tx,ty) ||
        get_adjacent(x+1,y+2,arr,d,q,n,m,tx,ty) ||
        get_adjacent(x-1,y+2,arr,d,q,n,m,tx,ty) ||
        get_adjacent(x+1,y-2,arr,d,q,n,m,tx,ty) ||
        get_adjacent(x-1,y-2,arr,d,q,n,m,tx,ty)
        ){
            // target was found - exist
            break;
        }
    }

    cout << arr[tx][ty]->dist << endl;
    //delete myNode;    do NOT do this, as it will delete the pointer arr[x][y]..for given x,y
    // when the below clearing code comes in, you will have a segment fault as it will try to free up an already
    // freed up space. Notice when I do myNode=arr[x][y] I am doing a shallow copy. REMEMBER pointers are nothing
    // but a special int where the value is a memory address.

    for(int i=0;i<n;i++){
        for(int j=0;j<m;j++){
            delete arr[i][j];   // delete individual Node* object pointer
        }
        delete[] arr[i];        // delete the array
    }
    delete[] arr;               // delete the array
}


#endif // KNIGHT_WALK_H_INCLUDED
