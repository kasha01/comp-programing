#ifndef N_QUEEN_H_INCLUDED
#define N_QUEEN_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/n-queen-problem/0

bool flag = false;  // to indicate at least one result was printed/founded
void invalidate_validate_matrix(int x, int y, int** matrix, int& n, bool& b){
    int z=1;
    if(b){
        // make diagonal valid (decrement its matrix values)
        z=-1;
    }
    else{
        // make it inalid. +1
    }

    int tempx=x; int tempy=y;

    tempx=tempx+1;
    tempy=tempy+1;
    while(tempx>=0 && tempy>=0 && tempx<n && tempy<n){
        matrix[tempx][tempy] = matrix[tempx][tempy] + z;
        tempx=tempx+1;
        tempy=tempy+1;
    }

    tempx=x; tempy=y;
    tempx=tempx+1;
    tempy=tempy-1;
    while(tempx>=0 && tempy>=0 && tempx<n && tempy<n){
        matrix[tempx][tempy] = matrix[tempx][tempy] + z;
        tempx=tempx+1;
        tempy=tempy-1;
    }

    tempx=x; tempy=y;
    tempx=tempx-1;
    tempy=tempy+1;
    while(tempx>=0 && tempy>=0 && tempx<n && tempy<n){
        matrix[tempx][tempy] = matrix[tempx][tempy] + z;
        tempx=tempx-1;
        tempy=tempy+1;
    }

    tempx=x; tempy=y;
    tempx=tempx-1;
    tempy=tempy-1;
    while(tempx>=0 && tempy>=0 && tempx<n && tempy<n){
        matrix[tempx][tempy] = matrix[tempx][tempy] + z;
        tempx=tempx-1;
        tempy=tempy-1;
    }
}

void bt(int row, int& n, vector<int>& vec, int** matrix, vector<bool>& rows, vector<bool>& columns){

    if(row >= n){
        // print result
        if(vec.size()>0){
            flag=true;
            cout << "[";
            for(int i=0;i<n;i++){
                cout << vec[i]+1 << " ";
            }
            cout << "]";
        }
        return;
    }

    // try every column for a given row
    for(int c=0;c<n;c++){
        // validate my Queen location, on row, column=c
        // if rows[0]=true-->this row is within a horizantal range of another queen, thus invalid
        // if columns[0]=true-->this column is within a vertical range of another queen, thus invalid
        // if matrix[row][c]>0 -->this square is within a diagonal of another queen, thus invalid
        // a value of 2 means this square in within range for two queens, thus on the back track i decrement by 1
        // for one queen posibility
        if(rows[row] || columns[c] || matrix[row][c] != 0){
            // not valid column - continue
            continue;
        }

        // it is valid. invalidate other squares, put my queen here
        rows[row]=true;     // invalidate my row - it is within my range
        columns[c]=true;    // invalidate my column - it is within my range
        bool b = false;
        matrix[row][c] = matrix[row][c]+1;  // invalidate my position
        invalidate_validate_matrix(row,c,matrix,n,b); // invalidates diagonals within my range starting from x,y

        vec.push_back(c);   // this is a good location for my queen. at this row/column

        bt(row+1,n,vec,matrix,rows,columns);

        // back track
        rows[row]=false;    // validate my row (make it valid)
        columns[c]=false;   // validate my column
        b=true;
        invalidate_validate_matrix(row,c,matrix,n,b); // back track my diagonals range in matrix
        matrix[row][c] = matrix[row][c]-1;  // validate my position
        vec.pop_back();
    }
}

void driver(){
    int n = 4;
    vector<bool> rows;
    vector<bool> columns;
    int** matrix = new int*[n];

    for(int i=0;i<n;i++){
        rows.push_back(false);
        columns.push_back(false);
        matrix[i] = new int[n];
        for(int j=0;j<n;j++){
            matrix[i][j] = 0;
        }
    }

    vector<int> result;
    bt(0,n,result,matrix,rows,columns);

    // no solution is possible - print -1
    if(!flag){
        cout << -1;
    }
}


#endif // N_QUEEN_H_INCLUDED
