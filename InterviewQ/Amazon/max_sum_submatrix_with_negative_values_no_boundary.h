#ifndef MAX_SUM_SUBMATRIX_WITH_NEGATIVE_VALUES_NO_BOUNDARY_H_INCLUDED
#define MAX_SUM_SUBMATRIX_WITH_NEGATIVE_VALUES_NO_BOUNDARY_H_INCLUDED


// can I make it better (Kadane with boundaries) O(nm) : m: boundary
int mykadane_all(int* arr, long n, long maxrow){
    int sum=0; int global_sum=0;
    for(int i=0; i<n; i++){
        sum = 0;
        for(int j=i;j<maxrow+i && j<n;j++){
            sum = sum + arr[j];

            if(sum > global_sum){
                global_sum = sum;
            }
        }
    }
    return global_sum;
}

// http://www.geeksforgeeks.org/dynamic-programming-set-27-max-sum-rectangle-in-a-2d-matrix/
// work with no boundaries - this is my better Kadane
int mykadane(int* arr, int* start, int* finish, int n){

    int sum = arr[0]; int globalsum = arr[0];
    int b=0; int e=0;
    for(int i=1; i<n; i++){
        int a = arr[i];
        if(sum+arr[i] > arr[i]){
            sum = sum + arr[i];
        }
        else{
            // Flipping
            sum = arr[i];
            if(sum > globalsum){b=i;}   // sum > globalsum ==> I have a new beginning. sometimes it may flip withoug changing globalsum
                                        // such case must be ignored
        }

        if(sum > globalsum){
            globalsum = sum; e=i;       // as long as sum/globalsum keeps growing, e keeps extending. it will stop once globalsum stops changing
        }
    }
    *start = b; *finish = e;
    return globalsum;
}

// The main function that finds maximum sum rectangle in M[][]
void findMaxSum(int M[][COL])
{
    // Variables to store the final output
    int maxSum = INT_MIN, finalLeft, finalRight, finalTop, finalBottom;

    int left, right, i;
    int temp[ROW], sum, start, finish;

    // Set the left column
    for (left = 0; left < COL; ++left)
    {
        // Initialize all elements of temp as 0
        memset(temp, 0, sizeof(temp));

        // Set the right column for the left column set by outer loop
        for (right = left; right < COL; ++right)
        {
           // Calculate sum between current left and right for every row 'i'
            for (i = 0; i < ROW; ++i)
                temp[i] += M[i][right];

            // Remember: Kadane is the subarray with the max sum, so myKadana will mark me the
            // the range of rows (subarray) that has the max sum, when the range of columns is between right
            // and left, and returns to me the max sum, I do that for every combination of columns range
            // keeping track of max Kadane, which will result the max final result. (maxsum)

            // Find the maximum sum subarray in temp[]. The kadane()
            // function also sets values of start and finish.  So 'sum' is
            // sum of rectangle between (start, left) and (finish, right)
            //  which is the maximum sum with boundary columns strictly as
            //  left and right.
            sum = mykadane(temp, &start, &finish, ROW);

            // Compare sum with maximum sum so far. If sum is more, then
            // update maxSum and other output values
            if (sum > maxSum)
            {
                maxSum = sum;
                finalLeft = left;
                finalRight = right;
                finalTop = start;
                finalBottom = finish;
            }
        }
    }

    // Print final values
    printf("(Top, Left) (%d, %d)n", finalTop, finalLeft);
    printf("(Bottom, Right) (%d, %d)n", finalBottom, finalRight);
    printf("Max sum is: %dn", maxSum);
}

// Driver program to test above functions
void driver()
{
    int M[ROW][COL] = {{1, -2, -1, -4, -20},
                       {-8, -3, 4, 2, 1},
                       {3, 8, 10, 1, 3},
                       {-4, -1, 1, 7, -6}
                      };

    findMaxSum(M);
}


#endif // MAX_SUM_SUBMATRIX_WITH_NEGATIVE_VALUES_NO_BOUNDARY_H_INCLUDED
