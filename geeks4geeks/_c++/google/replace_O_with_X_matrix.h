#ifndef REPLACE_O_WITH_X_MATRIX_H_INCLUDED
#define REPLACE_O_WITH_X_MATRIX_H_INCLUDED

/*
Given a matrix of size NxM where every element is either ‘O’ or ‘X’, replace ‘O’ with ‘X’ if surrounded by ‘X’.
A ‘O’ (or a set of ‘O’) is considered to be by surrounded by ‘X’ if there are ‘X’ at locations just below,
above, left and right of it.
*/
// https://practice.geeksforgeeks.org/problems/replace-os-with-xs/0
bool check(int x, int y, int n, int m, char** arr){

    if(y<0 || x<0 || y>=m || x>=n){
        return false;
    }

    if(arr[x][y]=='O'){
        arr[x][y] = 'p';
        bool res = check(x-1,y,n,m,arr)&&
        check(x+1,y,n,m,arr)&&
        check(x,y-1,n,m,arr)&&
        check(x,y+1,n,m,arr);
        arr[x][y] = 'O';
        return res;
    }
    else{
        return true;
    }
};

void driver()
{
    int n=4; int m=3;
    char ar[n][m] = {{'X', 'O', 'O'},
                     {'O', 'O', 'O'},
                     {'O', 'O', 'X'},
                     {'X', 'X', 'O'}
                    };

    char** arr = new char*[n];

    for(int i=0;i<n;i++){
        arr[i] = new char[m];
        for(int j=0;j<m;j++){
            arr[i][j] = ar[i][j];
        }
    }

    for(int i=0; i<n; i++){
        for(int j=0;j<m;j++){
            if(arr[i][j] == 'O'){
                //arr[i][j] = 'p';
                bool res =check(i,j,n,m,arr);
                if(res){
                    arr[i][j] = 'X';
                }
                else{
                    arr[i][j] = 'O';
                }
            }
        }
    }

    for(int i=0;i<n;i++){
        for(int j=0;j<m;j++){
            cout << arr[i][j] << " ";
        }
        cout << endl;
    }
}


#endif // REPLACE_O_WITH_X_MATRIX_H_INCLUDED
