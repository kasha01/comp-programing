#ifndef DOES_SODUKO_HAVE_SOLUTION_H_INCLUDED
#define DOES_SODUKO_HAVE_SOLUTION_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/is-sudoku-valid/0
set<int> arr_dic_row[9];
set<int> arr_dic_col[9];
set<int> arr_dic_square[9];
vector<pair<int,int>> available_sq;

bool isValid(int arr[][9],int i, int row, int col, int sq){
    if(arr_dic_col[col].find(i) == arr_dic_col[col].end()
       && arr_dic_row[row].find(i) == arr_dic_row[row].end()
       && arr_dic_square[sq].find(i) == arr_dic_square[sq].end()
       )
    {
        return true;
    }
    else{
        return false;
    }
}

bool sudoku(int arr[][9], int index){
    if(index >= available_sq.size()) { return true; }

    pair<int,int> p = available_sq[index];
    int row = p.first; int col=p.second;
    int sq = 3*(row/3) + col/3;
    bool res = false;
    for(int i=1;i<=9;i++){
        arr[row][col]=i;
        if(isValid(arr,i, row, col, sq)){
            // add i to the proper dictionaries
            arr_dic_col[col].insert(i);
            arr_dic_row[row].insert(i);
            arr_dic_square[sq].insert(i);
            int temp = index + 1;
            res = sudoku(arr, temp);
            if(res){
                return true;
            }
            else{
                // remove i from dictionaries
                arr_dic_col[col].erase(i);
                arr_dic_row[row].erase(i);
                arr_dic_square[sq].erase(i);
            }
        }
    }
    return false;
}

void driver(){
    int grid[][9] = {{3, 0, 6, 5, 0, 8, 4, 0, 0},
                      {5, 2, 0, 0, 0, 0, 0, 0, 0},
                      {0, 8, 7, 0, 0, 0, 0, 3, 1},
                      {0, 0, 3, 0, 1, 0, 0, 8, 0},
                      {9, 0, 0, 8, 6, 3, 0, 0, 5},
                      {0, 5, 0, 0, 9, 0, 6, 0, 0},
                      {1, 3, 0, 0, 0, 0, 2, 5, 0},
                      {0, 0, 0, 0, 0, 0, 0, 7, 4},
                      {0, 0, 5, 2, 0, 6, 3, 0, 0}};


    int index = 0;
    for(int i=0;i<9;i++){
        for(int j=0;j<9;j++){
            if(grid[i][j] == 0){
                pair<int,int> p(i,j);
                available_sq.push_back(p);
            }
            else{
                int sq = 3*(i/3) + (j/3);
                arr_dic_col[j].insert(grid[i][j]);
                arr_dic_row[i].insert(grid[i][j]);
                arr_dic_square[sq].insert(grid[i][j]);
            }
        }
    }

    bool res = sudoku(grid,0);

    available_sq.clear();
    for(int i=0;i<9;i++){
        arr_dic_col[i].clear();
        arr_dic_row[i].clear();
        arr_dic_square[i].clear();
    }

    for (int i = 0; i < 9; i++)
    {
        for (int j = 0; j < 9; j++)
        {
            cout << grid[i][j] << " ";
        }
        cout << endl;
    }
    cout << res;
}

#endif // DOES_SODUKO_HAVE_SOLUTION_H_INCLUDED
