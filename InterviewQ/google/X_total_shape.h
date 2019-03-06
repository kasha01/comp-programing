#ifndef X_TOTAL_SHAPE_H_INCLUDED
#define X_TOTAL_SHAPE_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/x-total-shapes/0
// Any Adjacent 'X' is considered a part of the same shape, two undajcent 'X's gives a total of two shapes total
void dp(vector<vector<char>>& vec, int i, int j,int n, int m){
    if(i<0 || i>=n || j<0 || j>=m){return;}

    if(vec[i][j]!='X'){return;}

    vec[i][j] = 'O';
    dp(vec,i-1,j,n,m);
    dp(vec,i+1,j,n,m);
    dp(vec,i,j+1,n,m);
    dp(vec,i,j-1,n,m);
}


void driver(){
    vector<vector<char>> matrix = {
     {'O','O','O','O','X','X','O'},
     {'O','X','O','X','O','O','X'},
     {'X','X','X','X','O','X','O'},
     {'O','X','X','X','O','O','O'}
    };

    int s=0;
    int n=4; int m=7;

    for(int i=0;i<n;i++){
        for(int j=0;j<m;j++){
            if(matrix[i][j] == 'X'){
                s=s+1;
                dp(matrix, i,j,n,m);
            }
        }
    }

    cout << s;
}


#endif // X_TOTAL_SHAPE_H_INCLUDED
