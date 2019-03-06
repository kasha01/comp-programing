#ifndef SUBARRAY_WITH_GIVEN_SUM_H_INCLUDED
#define SUBARRAY_WITH_GIVEN_SUM_H_INCLUDED


// http://practice.geeksforgeeks.org/problems/subarray-with-given-sum/0

/*
Loop through the array and calculate the sum, keeping two pointers, First pointer marks the end of the subarray (i),
the second pointer (j) marks its beginning, once the sum exceeds K (the desired number).
That means I have elements in the beginning of my subarray that I don’t need.
So I loop with (while loop) until my sum is <= K and adjusting j accordingly.
There are a maximum of 2 operations on every element (adding to sum and subtracting from sum) so the upper
bound on the number of operations is 2n*/
mt(int* arr, int n, int k){
    int sum=0;
    int j=0; int a=0; int b=-1;
    for(int i=0; i<n; i++){
        sum=sum+arr[i];
        while(sum>k){
            sum = sum - arr[j];
            j++;
        }
        if(sum == k){
            a=j+1;b=i+1;break;
        }
    }

    if(b!=-1){
        cout << a << " " << b;
    }
    else {
        cout << -1;
    }
}

void driver(){
    int arr[] = {28,68,142,130,41,14,175,2,78,16,84,14,193,25,2,193,160,71,29,28,85,76,187,99,171,88,48,5,104,22,64,107,164,11,172,90,41,165,143,20,114,192,105,19,33,151,6,176,140,104,23,99,48,185,49,172,65};
    int n = sizeof(arr)/sizeof(arr[0]);
    mt(arr,n,1562);
    return 0;
}

#endif // SUBARRAY_WITH_GIVEN_SUM_H_INCLUDED
