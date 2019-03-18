#ifndef MAX_ABSOLUTE_DIFF_H_INCLUDED
#define MAX_ABSOLUTE_DIFF_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/max-absolute-difference/0
//  find two non-overlapping contiguous sub-arrays such that the absolute difference between the sum of
// two sub-arrays is maximum.
// [2, -1, -2, 1, -4, 2, 8] ==> Two subarrays are [-1, -2, 1, -4] and [2, 8] . output 16

/*
The trick is, there is a divider that divides the array into 2 halves (2 subarrays). and we find the max and min
contiguous subarray in both the right half and left half...and find the absolute difference
int test case arr=[2, -1, -2, 1, -4, 2, 8]; the max diff is when the divider is at i=5. i.e.
left_arr={2, -1, -2, 1, -4}, right_arr={2,8}.
the max_diff yields when one half is max and the other half is min. so we calculate the min&max of both halves.
and see which difference yields the max difference.
so here, min_right=2, max_right=10; min_left=-6, max_left=2;
and max difference is when we take the difference between the min_left and max_right (10--6)=16
*/
void kadane(int* arr, int s, int e, int& globalmax, int& globalmin){
    int maxsofar = arr[s];
    globalmax = arr[s];

    int minsofar = arr[s];
    globalmin = arr[s];

    for(int i=s+1;i<e;i++){
        maxsofar = max(arr[i], maxsofar + arr[i]);
        globalmax = max(maxsofar, globalmax);

        minsofar = min(arr[i], minsofar + arr[i]);
        globalmin = min(minsofar, globalmin);
    }
};

void driver(){

    int arr[] = {-162 ,617 ,332 ,-123 ,507 ,-428};
    int n = sizeof(arr)/sizeof(arr[0]);
    int arr_left_min = INT_MIN; int arr_left_max = INT_MAX;
    int arr_right_min = INT_MIN; int arr_right_max = INT_MAX;
    int max_diff=INT_MIN;
    for(int i=1;i<n;i++){
        //divider (all indexes must be included/looped). since kadane method up, deals directly with indexes
        //in case i=n=5. left[0-4 (i<e=5)]={-162 ,617 ,332 ,-123 ,507}
        // right[i=5] (for loop is not executed, but initial values are set) = {-428}
        kadane(arr, 0, i,arr_left_max, arr_left_min);

        kadane(arr,i,n, arr_right_max, arr_right_min);

        int temp = max(arr_left_max-arr_right_min, arr_right_max - arr_left_min);
        max_diff = max(temp,max_diff);
    }

    cout << max_diff;
}


#endif // MAX_ABSOLUTE_DIFF_H_INCLUDED
