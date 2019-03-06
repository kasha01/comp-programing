#ifndef PAINTER_PARTITION_H_INCLUDED
#define PAINTER_PARTITION_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/the-painters-partition-problem/0
int dp(int x,int k, int* arr, const int K, const int N, int* tb, int** memo){
    if(x>=N || k>K){return 0;}
    if(k==K){
        // last painter
        return tb[x];
    }

    if(memo[x][k-1] != 0){
        return memo[x][k-1];
    }

    int sumk=0;
    int res=0;
    int result = INT_MAX;
    for(int i=x; i<N;i++){
        res = 0;
        sumk=arr[i] + sumk;
        res = dp(i+1,k+1,arr,K,N,tb,memo);
        int z = max(sumk,res);
        result=min(z,result);
    }
    memo[x][k-1] = result;
    return result;
}


void driver()
{
    int k = 3;
    int n = 4;
    int arr[] = {10,20,30,40};

    int tb[n];
    int s=0;
    for(int i=n-1;i>=0;--i){
        s = s + arr[i];
        tb[i] = s;
    }

    int** memo = new int*[n];
    for(int i=0;i<n;i++){
        memo[i]=new int[k];
        memset(memo[i],0,k*sizeof(int*));
    }

    int result = dp(0,1,arr,k,n,tb,memo);

    cout << result << endl;

   for(int i=0;i<k;i++){
        for(int j=0;j<k;j++){
            cout << memo[i][j] << " ";
        }
    }

    for(int i=0;i<k;i++){
        delete[] memo[i];
    }
    delete[] memo;
}


#endif // PAINTER_PARTITION_H_INCLUDED
