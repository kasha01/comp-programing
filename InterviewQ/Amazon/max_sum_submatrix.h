#ifndef MAX_SUM_SUBMATRIX_H_INCLUDED
#define MAX_SUM_SUBMATRIX_H_INCLUDED

long ROW; long COL;

// http://practice.geeksforgeeks.org/problems/max-sum-submatrix/0

using namespace std;

// does not deal with -ve matrix values
long mykadane_pos(long* arr, long n, long maxrow){
    long globalsum=0; long sum=0; int counter=0; int bb=0;
    for(int i=0;i<n;i++){
        if(i>=maxrow){sum = arr[i] + sum - arr[bb]; bb++;}
        else{sum = arr[i] + sum;}

        if(sum > globalsum){
            globalsum = sum;
        }
    }
    return globalsum;
};

long findMaxSum(long** M, long maxcol, long maxrow)
{
    // Variables to store the final output
    long maxSum = INT_MIN;

    long left, right, i;
    long temp[ROW], sum;

    // Set the left column
    for (left = 0; left < COL; ++left)
    {
        // Initialize all elements of temp as 0
        memset(temp, 0, sizeof(temp));

        // Set the right column for the left column set by outer loop
        for (right = left; right < COL && (right-left) < maxcol ; ++right)
        {
           // Calculate sum between current left and right for every row 'i'
            for (i = 0; i < ROW; ++i)
                temp[i] += M[i][right];

            sum = mykadane_pos(temp,ROW, maxrow);
            if (sum > maxSum)
            {
                maxSum = sum;
            }
        }
    }

    return maxSum;
}

// Driver program to test above functions
int main()
{
    long t = 0;
    cin >> t;
    while(t > 0){
        t--;
        cin >> ROW; cin >> COL;

        long** M = new long*[ROW];

        for(long i=0; i< ROW; i++){
            M[i] = new long[COL];
            for(long j=0; j<COL;j++){
                cin >> M[i][j];
            }
        }

        long tt=0;
        cin >> tt;
        while(tt>0){
            tt--;

            long maxRow=0; long maxCol=0;
            cin >> maxRow >> maxCol;

            long sum = findMaxSum(M,maxCol,maxRow);
                cout << sum << " ";
            }
        cout << endl;
     }

    return 0;
};

#endif // MAX_SUM_SUBMATRIX_H_INCLUDED
