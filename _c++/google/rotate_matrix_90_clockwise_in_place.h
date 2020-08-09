#ifndef ROTATE_MATRIX_90_CLOCKWISE_IN_PLACE_H_INCLUDED
#define ROTATE_MATRIX_90_CLOCKWISE_IN_PLACE_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/rotate-a-2d-array-without-using-extra-space/0
void rotate_matrix_90_clockwise_in_place()
{
    int n=3;
    int M[][n] = {{1,2,3},
                {4,5,6},
                {7,8,9}
    };

    // print before rotation
    for(int i=0;i<n;i++){
        for(int j=0;j<n;j++){
            cout << M[i][j] << " ";
        }
        cout << endl;
    }
    cout << endl;

    // rotate
    for(int x=0; x<n/2;x++){
        for(int y=x; y<n-1-x;y++){
            int temp = M[x][y];
            M[x][y] = M[n-1-y][x];
            M[n-1-y][x] = M[n-1-x][n-1-y];
            M[n-1-x][n-1-y] = M[y][n-1-x];
            M[y][n-1-x] = temp;
        }
    }

    // print after rotation
    for(int i=0;i<n;i++){
        for(int j=0;j<n;j++){
            cout << M[i][j] << " ";
        }
        cout << endl;
    }
}

#endif // ROTATE_MATRIX_90_CLOCKWISE_IN_PLACE_H_INCLUDED
