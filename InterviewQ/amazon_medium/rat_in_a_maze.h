#ifndef RAT_IN_A_MAZE_H_INCLUDED
#define RAT_IN_A_MAZE_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/rat-in-a-maze-problem/1
void bt(int r,int c, int n, string s, int** arr){

    //cout << s << endl;
    if(r<0 || c<0 || r>=n || c>=n){
        return;
    }

    if(arr[r][c] == 0 || arr[r][c] == -1){
        return;
    }

    if(r== n-1 && c==n-1){
        cout << s << endl;
        return;
    }

    // do work
    arr[r][c] = -1;

    bt(r+1,c,n,s+"D",arr);
    bt(r,c-1,n,s+"L",arr);
    bt(r,c+1,n,s+"R",arr);
    bt(r-1,c,n,s+"U",arr);

    // back track
    arr[r][c]=1;
}

void driver(){
    int n=4;
    int a[] = {1,0,0,0,1,1,0,1,1,1,0,0,0,1,1,1};
    int** arr = new int*[n];

    for(int i=0;i<n;i++){
        arr[i] = new int[n];
        for(int j=0;j<n;j++){
            arr[i][j] = a[(i*n) + j];
        }
    }

    bt(0,0,4,"",arr);

}


#endif // RAT_IN_A_MAZE_H_INCLUDED
