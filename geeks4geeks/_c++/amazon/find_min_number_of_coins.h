#ifndef FIND_MIN_NUMBER_OF_COINS_H_INCLUDED
#define FIND_MIN_NUMBER_OF_COINS_H_INCLUDED

// http://www.geeksforgeeks.org/find-minimum-number-of-coins-that-make-a-change/

// if n=11 is required, a mininmum count of 2 coins is needed. {6,5}
int arr[] = {9, 6, 5, 1};
int* table;

// RECURSSIVE - not optimized
int dp2(int n, int sz, int& c){
    if(n==0){return 0;}

    int sum = INT_MAX;

    for(int i=0; i<sz;i++){
        c++;
        if(n-arr[i]<0){continue;}
        sum = min(sum, dp2(n-arr[i],sz,c)+1);
    }
    return sum;
};

// top down optimized O(nv). n:value I want, v:size of coins array
int dp(int n, int sz, int& c){
    if(n==0){return 0;}
    if(table[n] != INT_MAX){return table[n];}

    //int sum = INT_MAX;

    int temp=INT_MAX;
    for(int i=0; i<sz;i++){
        c++;
        if(n-arr[i]<0){continue;}

        //table[n] = min(table[n], dp(n-arr[i],sz,c)+1);

        // we do the temp trick to avoid overflow in case dp returned INT_MAX
        temp = dp(n-arr[i],sz,c);
        if(temp != INT_MAX && temp+1 < table[n]){
            table[n]=temp+1;
        }
    }
    return table[n];
}

// geeksforgeeks impl. bottom up
// m is size of coins array (number of different coins)
int minCoins(int coins[], int m, int V)
{
    // table[i] will be storing the minimum number of coins
    // required for i value.  So table[V] will have result
    int table[V+1];

    // Base case (If given value V is 0)
    table[0] = 0;

    // Initialize all table values as Infinite
    for (int i=1; i<=V; i++)
        table[i] = INT_MAX;

    // Compute minimum coins required for all
    // values from 1 to V
    for (int i=1; i<=V; i++)
    {
        // Go through all coins smaller than i
        for (int j=0; j<m; j++)
          if (coins[j] <= i)
          {
              int sub_res = table[i-coins[j]];
              if (sub_res != INT_MAX && sub_res + 1 < table[i])
                  table[i] = sub_res + 1;
          }
    }
    return table[V];
}

void driver()
{
    int n = 11;
    table = new int[n+1];
    // setting array to initial value of INT_MAX
    for(int i=0; i<n+1;i++){
        table[i] = INT_MAX;
    }
    table[0] = 0;
    int c=0;
    int res = dp(n,4,c);
    cout << res << " " << c;
    return 0;
}

#endif // FIND_MIN_NUMBER_OF_COINS_H_INCLUDED
