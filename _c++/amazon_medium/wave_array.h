#ifndef WAVE_ARRAY_H_INCLUDED
#define WAVE_ARRAY_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/wave-array/0
void mt(){

    int n=5;
    vector<int> vec = { 5 ,7 ,3 ,2 ,8};

    // I am doing the asc. sorting and going from n to 1 in the for loop to guarantee a lexographical order.
    sort(vec.begin(), vec.end());

    for(int i=n-1;i>0;i--){
        if((((i%2)!= 0) && (vec[i] > vec[i-1])) ||
           (((i%2)== 0) && (vec[i] < vec[i-1]))){
            // swap
            int temp = vec[i];
            vec[i] = vec[i-1];
            vec[i-1] = temp;
        }
    }

    for(int i=0;i<n;i++){
        cout << vec[i] << " ";
    }
}

#endif // WAVE_ARRAY_H_INCLUDED
