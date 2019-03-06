#ifndef KADANE_WITH_PRINT_SUBSEQ_H_INCLUDED
#define KADANE_WITH_PRINT_SUBSEQ_H_INCLUDED

using namespace std;

void largest_cont_sub_seq_sum(){

    int arr[] = {-2,-3,-4,-1,-2,-5,-3};

    int sum = arr[0]; int globalsum = arr[0];
    int n = sizeof(arr)/sizeof(arr[0]);
    int b=0; int e=0;
    for(int i=1; i<n; i++){
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

    cout << globalsum << endl;

    for(int i=b; i<=e;i++){
        cout << arr[i] << " ";
    }
}


// using divide and conquer O(n Log n)
// Find the maximum possible sum in arr[] auch that arr[m] is part of it
int maxCrossingSum(int arr[], int l, int m, int h)
{
    // Include elements on left of mid.
    int sum = 0;
    int left_sum = INT_MIN;
    for (int i = m; i >= l; i--)
    {
        // this is like globalsum, notice how the loop started from m -> end of left half
        // since left_sum=MIN, we guarntee mid is included which is the total point of find the max sum
        // CROSSING mid, any other item down the left that would increase left_sum, would be included, along
        // with the chains of items before it to the mid.
        // consider {-2, -5, 6, -2, -3, 1, -5, 2} subarray, where m=3 =>
        // left = {-2, -5, 6, -2} , right={-3, 1, 5, -6}. now the crossing left_sum => starts from mid=-6,
        // is included by defualt since left_sum=MIN. then comes 5 good it increased my left_sum, comes 1, also
        // good, comes -3, nope..so left_sum=-6+5+1. notice how -6 is included to guarantee a continueous link
        // crossing mid.
        // Right ={-3, 1, -5, 2} => right_sum = MIN, comes -3 good, comes 1, so far right_sum=-2
        // comes -5 not good sum=-7, right_sum=-2, comes 2, not so good because -5 before was really bad
        // right_sum=-2, sum=-5. END so crossing max sum = left+right.
        //NOtice even if this is not the good solution that is okay, It will be compared across max_left and
        // max_right in the original method, but it could be also a good solution that is why mid crossing
        // solution must be calculated.
        sum = sum + arr[i];
        if (sum > left_sum)
          left_sum = sum;
    }

    // Include elements on right of mid
    sum = 0;
    int right_sum = INT_MIN;
    for (int i = m+1; i <= h; i++)
    {
        // this is like maxsumsofar
        sum = sum + arr[i];
        if (sum > right_sum)
          right_sum = sum;
    }

    // Return sum of elements on left and right of mid
    return left_sum + right_sum;
}

// Returns sum of maxium sum subarray in aa[l..h]
int maxSubArraySum(int arr[], int l, int h)
{
   // Base Case: Only one element
   if (l == h)
     return arr[l];

   // Find middle point
   int m = (l + h)/2;

   /* Return maximum of following three possible cases
      a) Maximum subarray sum in left half
      b) Maximum subarray sum in right half
      c) Maximum subarray sum such that the subarray crosses the midpoint
      (the maximum sum that overlaps the middle of the list)*/
   return max(maxSubArraySum(arr, l, m),
              maxSubArraySum(arr, m+1, h),
              maxCrossingSum(arr, l, m, h));
}

#endif // KADANE_WITH_PRINT_SUBSEQ_H_INCLUDED
