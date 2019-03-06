#ifndef FLOOD_FILL_H_INCLUDED
#define FLOOD_FILL_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/flood-fill-algorithm/0

// k=pixel color to replace. kk=pixel color to replace with
void mt(int x, int y, int k, int kk, int n, int m, int** arr){
    vector<pair<int,int>> vec;

    if(x-1>=0 && arr[x-1][y]==k){arr[x-1][y] = kk; vec.push_back(std::make_pair(x-1,y)); }
    if(x+1<n && arr[x+1][y]==k){arr[x+1][y] = kk; vec.push_back(std::make_pair(x+1,y)); }
    if(y-1>=0 && arr[x][y-1]==k){arr[x][y-1] = kk; vec.push_back(std::make_pair(x,y-1)); }
    if(y+1<m && arr[x][y+1]==k){arr[x][y+1] = kk; vec.push_back(std::make_pair(x,y+1)); }

    //if(x-1>=0 && y+1<m && arr[x-1][y+1]==k){arr[x-1][y+1] = kk; vec.push_back(std::make_pair(x-1,y+1)); }
    //if(x-1>=0 && y-1>=0 && arr[x-1][y-1]==k){arr[x-1][y-1] = kk; vec.push_back(std::make_pair(x-1,y-1)); }
    //if(x+1<n && y+1<m && arr[x+1][y+1]==k){arr[x+1][y+1] = kk; vec.push_back(std::make_pair(x+1,y+1)); }
    //if(x+1<n && y-1>=0 && arr[x+1][y-1]==k){arr[x+1][y-1] = kk; vec.push_back(std::make_pair(x+1,y-1)); }

    for(int i=0; i<vec.size(); i++){
        mt(vec[i].first, vec[i].second, k, kk, n, m, arr);
    }
    vec.clear();
}

void driver(){
    int n=3; int m=4; int** arr; arr = new int*[n];

    int a[] = {0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 2, 3};

    int c=0;
    for(int i=0; i<n;i++){
        arr[i] = new int[m];
        for(int j=0;j<m;j++){
            arr[i][j]= a[c]; c++;
        }
    }
    int k = arr[0][1]; arr[0][1] = 5;
    mt(0,1,k,5,n,m,arr);

    for(int i=0; i<n;i++){
        for(int j=0;j<m;j++){
            cout << arr[i][j] << " ";
        }
        cout << endl;
    }
}

#endif // FLOOD_FILL_H_INCLUDED
