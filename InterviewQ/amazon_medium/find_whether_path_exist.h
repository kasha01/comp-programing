#ifndef FIND_WHETHER_PATH_EXIST_H_INCLUDED
#define FIND_WHETHER_PATH_EXIST_H_INCLUDED

/*
Given a N X N matrix (M) filled with 1 , 0 , 2 , 3 . Your task is to find whether there is a path possible
from source to destination, while traversing through blank cells only.
You can traverse up, down, right and left.
1=source; 3=blank cell; 2=destination/target; 0=wall/block
*/

// https://practice.geeksforgeeks.org/problems/find-whether-path-exist/0
int c = 0;
bool mt(int x, int y, int const &n, int** arr, bool** memo){

    c++;
    if(x<0 || y<0 || x>=n || y>=n){
        return false;
    }

    if(arr[x][y] == -1){
        return false;
    }

    if(arr[x][y] == 0){
        return false;
    }
    else if(arr[x][y] == 2){
        return true;
    }

    if(!memo[x][y]){
        // return false; passed without memo!
    }

    int z = arr[x][y];
    arr[x][y] = -1;
    bool result = mt(x+1,y,n,arr,memo) || mt(x-1,y,n,arr,memo) || mt(x,y+1,n,arr,memo) || mt(x,y-1,n,arr,memo);
    memo[x][y]=result;
    arr[x][y] = z;
    return result;
}


void driver(){
    int x = -1; int y=-1;
    int num[] = { 0 ,3 ,2 ,3 ,0 ,0 ,1 ,0 ,0};
    int n=3;
    int** arr = new int*[n];

    bool** memo = new bool*[n];

    for(int i=0;i<n;i++){
        arr[i] = new int[n];
        memo[i] = new bool[n];
        for(int j=0;j<n;j++){
            arr[i][j] = num[(i*n)+j];
            memo[i][j] = true;
            if(num[(i*n)+j] == 1){
                // source coordinates
                x=i; y=j;
            }
        }
    }

    for(int i=0;i<n;i++){
        for(int j=0;j<n;j++){
            cout << arr[i][j] << " ";
        }
        cout << endl;
    }

    cout << endl;

    bool result = mt(x,y,n,arr,memo);

    for(int i=0;i<n;i++){
        for(int j=0;j<n;j++){
            cout << arr[i][j] << " ";
        }
        cout << endl;
    }

    cout << result << " " << c;
}


#endif // FIND_WHETHER_PATH_EXIST_H_INCLUDED
