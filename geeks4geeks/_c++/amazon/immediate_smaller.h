#ifndef IMMEDIATE_SMALLER_H_INCLUDED
#define IMMEDIATE_SMALLER_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/immediate-smaller-element/0
// Given an integer array, for each element in the array check whether there exist a smaller element on the next immediate position of the array.
// If it exist print the smaller element. If there is no smaller element on the immediate next to the element then print -1.
// 4 2 1 5 3
// 2 1 -1 3 -1  <-- immediate smaller
void mt(){

    int arr[] = {4 ,2 ,1 ,5 ,3};

    int sz = sizeof(arr)/sizeof(arr[0]) -1;

    for(int i=0;i<sz;i++){
        if(arr[i+1] < arr[i]){
            cout << arr[i+1] << " ";
        }
        else {
            cout << "-1" << " ";
        }
    }
    cout << -1 << endl;
}

#endif // IMMEDIATE_SMALLER_H_INCLUDED
