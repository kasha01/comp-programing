#ifndef TRIPLE_SUM_IN_ARRAY_H_INCLUDED
#define TRIPLE_SUM_IN_ARRAY_H_INCLUDED


// https://practice.geeksforgeeks.org/problems/triplet-sum-in-array/0
void mt(){

    vector<int> vec = { 1 ,5 ,45 ,5 ,10 ,8};
    int x = 13;
    int n = 6;
    sort(vec.begin(), vec.end());

    bool flag = false;
    for(int k=0;k<n-2;k++){
        if(flag){break;}
        int i=k+1; int j=n-1;
        while(i<j){
            int sum = vec[k] + vec[i] + vec[j];
            if(sum < x){
                i++;
            }
            else if(sum > x){
                j--;
            }
            else{
                flag = true;
                break;
            }
        }
    }

    if(flag){
        cout << 1 << endl;
    }
    else{
        cout << 0 << endl;
    }
}

#endif // TRIPLE_SUM_IN_ARRAY_H_INCLUDED
