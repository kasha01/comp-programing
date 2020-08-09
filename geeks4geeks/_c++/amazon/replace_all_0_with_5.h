#ifndef REPLACE_ALL_0_WITH_5_H_INCLUDED
#define REPLACE_ALL_0_WITH_5_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/replace-all-0-with-5-in-an-input-integer/1
void mt(){
    int n = 1004;
    int i=0;
    double sum=0;
    while(n>=10){
        int m = n%10;
        if(m == 0){
            sum = sum + (5*pow(10,i));
        }
        else{
            sum = sum + (m*pow(10,i));
        }
        n = n/10; ++i;
    }
    sum = sum+(n*pow(10,i));

    cout << sum;
}

#endif // REPLACE_ALL_0_WITH_5_H_INCLUDED
