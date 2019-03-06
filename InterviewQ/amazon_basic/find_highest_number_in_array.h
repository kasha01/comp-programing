#ifndef FIND_HIGHEST_NUMBER_IN_ARRAY_H_INCLUDED
#define FIND_HIGHEST_NUMBER_IN_ARRAY_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/find-the-highest-number/0
int solve(int* arr, int n){

    int i=0; int j = n- 1;

    int result = -1;
    while(i<j){
        if(arr[i+1]<arr[i]){
            result = arr[i];
            break;
        }
        else if(arr[j-1]<arr[j]){
            result = arr[j];
            break;
        }
        i++;
        j--;
    }
    if(result == -1){result = arr[i];}
    return result;
}



#endif // FIND_HIGHEST_NUMBER_IN_ARRAY_H_INCLUDED
