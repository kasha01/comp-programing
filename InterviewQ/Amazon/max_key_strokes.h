#ifndef MAX_KEY_STROKES_H_INCLUDED
#define MAX_KEY_STROKES_H_INCLUDED

int* arr;

// http://www.geeksforgeeks.org/how-to-print-maximum-number-of-a-using-given-four-keys/
int dp(int n){
    if(n<=6){ return n;}
    int temp=0; int sum=0; int m=2; int ntemp=n-3;
    while(ntemp>1 && temp >= sum){
        sum=temp;
        if(arr[ntemp]>0){
            temp=arr[ntemp]*m;
        }
        else{
            temp = dp(ntemp) * m;
        }
        m++; ntemp--;
    }

    arr[n]=sum;
    return arr[n];
}

void driver()
{
    int n=16;
    arr=new int[n+1]();
    for(int i=0; i<=6;i++){
        arr[i]=i;
    }
//
//    for(int i=7; i<=n;i++){
//        arr[i]=-1;
//    }

    cout << dp(n);

    delete[] arr;
    return 0;
}


#endif // MAX_KEY_STROKES_H_INCLUDED
