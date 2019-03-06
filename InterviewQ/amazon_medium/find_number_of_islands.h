#ifndef FIND_NUMBER_OF_ISLANDS_H_INCLUDED
#define FIND_NUMBER_OF_ISLANDS_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/find-the-number-of-islands/1
void trackIsland(int x, int y, int n, int m, int matrix[][10]){
    if(x>=n || x<0 || y<0 || y>=m){
        return;
    }

    if(matrix[x][y] == -1 || matrix[x][y] == 0){
        return;
    }

    matrix[x][y] = -1;
    trackIsland(x-1,y,n,m,matrix);
    trackIsland(x+1,y,n,m,matrix);
    trackIsland(x,y-1,n,m,matrix);
    trackIsland(x,y+1,n,m,matrix);
    trackIsland(x+1,y+1,n,m,matrix);
    trackIsland(x+1,y-1,n,m,matrix);
    trackIsland(x-1,y+1,n,m,matrix);
    trackIsland(x-1,y-1,n,m,matrix);
}

void driver(){
    int[][] matrix;
    int c=0;
    for(int i=0;i<n;i++){
        for(int j=0;j<m;j++){
            if(matrix[i][j] == 1){
                c++;
                trackIsland(i,j,n,m,matrix);
            }
        }
    }

    return 0;
}


#endif // FIND_NUMBER_OF_ISLANDS_H_INCLUDED
