#ifndef LENGTH_LARGEST_REGION_OF_1_H_INCLUDED
#define LENGTH_LARGEST_REGION_OF_1_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/length-of-largest-region-of-1s/0
/* Consider a matrix with rows and columns (n,m), where each cell contains either a ‘0’ or a ‘1’ and any cell
containing a 1 is called a filled cell. Two cells are said to be connected if they are adjacent to each other
horizontally, vertically, or diagonally .If one or more filled cells are connected, they form a region.
*/
int mt(int** arr, int x, int y, int n, int m){
    if(x>=n || x<0 || y>=m || y<0){
        return 0;
    }

    if(arr[x][y]!= 1){
        return 0;
    }

    int sum = 0;
    arr[x][y] = -1;

    sum = 1 +
    mt(arr,x-1,y,n,m) +
    mt(arr,x+1,y,n,m) +
    mt(arr,x,y-1,n,m) +
    mt(arr,x,y+1,n,m) +
    mt(arr,x-1,y-1,n,m) +
    mt(arr,x-1,y+1,n,m) +
    mt(arr,x+1,y-1,n,m) +
    mt(arr,x+1,y+1,n,m);

    return sum;
}


int driver()
{
    int t=0; cin >> t;
    while(t>0){
        t--;

        int n=0; int m=0;
        cin >> n >> m;

        int** arr = new int*[n];
        int item=0;
        for(int i=0;i<n;i++){
            arr[i] = new int[m];
            for(int j=0;j<m;j++){
                cin >> item;
                arr[i][j] = item;
            }
        }

        int sum=0; int mx=0;
        for(int i=0;i<n;i++){
            for(int j=0;j<m;j++){
                sum=0;
                if(arr[i][j] == 1){
                    sum = mt(arr,i,j,n,m);
                }
                mx = max(mx,sum);
            }
        }

        cout << mx << endl;

        for(int i=0;i<n;i++){
            delete[] arr[i];
        }
        delete[] arr;

    }
	return 0;
}

#endif // LENGTH_LARGEST_REGION_OF_1_H_INCLUDED
