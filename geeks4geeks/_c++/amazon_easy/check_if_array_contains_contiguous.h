#ifndef CHECK_IF_ARRAY_CONTAINS_CONTIGUOUS_H_INCLUDED
#define CHECK_IF_ARRAY_CONTAINS_CONTIGUOUS_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/check-if-array-contains-contiguous-integers-with-duplicates-allowed/0
void mt(){
    vector<int> vec = {5  ,2  ,3  ,6  ,4  ,4  ,6  ,6};
    int n = vec.size();
    sort(vec.begin(), vec.end());

    bool flag = true;
    int a = vec[0];
    for(int i=1;i<n;i++){
        if(vec[i] == a){continue;}
        else if(vec[i]==a+1 ){
            a=vec[i];
        }
        else{
            flag = false;
            break;
        }
    }
    cout << flag;   // Flag=true, array is a contiguous set {3,4,5,6}. if 8 existed answer would be false.
}

#endif // CHECK_IF_ARRAY_CONTAINS_CONTIGUOUS_H_INCLUDED
