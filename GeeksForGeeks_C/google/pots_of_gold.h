#ifndef POTS_OF_GOLD_H_INCLUDED
#define POTS_OF_GOLD_H_INCLUDED


// http://practice.geeksforgeeks.org/problems/pots-of-gold-game/1
int dp(int arr[], int i, int n, int** mem)
{
    // base conditions
    if (i > n) { return 0; }                        // no more items
    else if(i == n) { return arr[i]; }              // only one item left (last pick)
    else if(i+1 == n){return max(arr[i],arr[n]);}   // only two items left i,n (return max as X wants max). this an optional base
                                                    // condition and can be omitted, as DP can handle it. this is synonymous to
                                                    // my last return line

    if(mem[i][n] != 0) { return mem[i][n]; }
    int sr = 0; int sl = 0;
    int pr=0; int pl=0;

    int res = 0;

    pr = arr[i];
    // In this case: X initial pick is i.
    // y wants to play optimally, meaning Y wants x to always get the min of the two possibilities (picking right edge or
    // left edge coins pot). thus X will get a total of his initial pick+the minimum of his(X's)next pick
    // X's next pick depends on what Y picked before hand, in this case they can be either:
    // 1) Assuming Y pick was i+1 --> thus leaving the array with items limit {i+2,n} for X to pick from --> min(dp(arr, i+2, n, mem)
    // 2) Assuming Y pick was n --> thus leaving the array with items limit {i+1,n-1} for X to pick from --> min(dp(arr, i+1, n-1, mem)
    // As I said, since Y wants X to have the min values, thus we pick the min of X's next recurssive pick
    // Total_1 = X initial pick + X's next pick (recursive dp) which is deduced from the beforehand Y pick of either i+1 or n
    sr = pr + min(dp(arr, i+2, n, mem), dp(arr,i+1,n-1,mem));

    // In this Case: X initial pick is n.
    // X's next pick depends on what Y picked before hand, in this case they can be either:
    // 1) Assuming Y pick was i --> thus leaving the array with items limit {i+1,n-1} for X to pick from --> min(dp(arr, i+1, n-1, mem)
    // 2) Assuming Y pick was n-1 --> thus leaving the array with items limit {i,n-2} for X to pick from --> min(dp(arr, i, n-2, mem)
    // And Again Y wants X to have the min of either of his (X's) next picks.
    pl = arr[n]; //n-1
    sl = pl + min(dp(arr,i+1,n-1,mem), dp(arr,i,n-2,mem)) ;


    // X on the other hand wants to have the max of his own picks
    // Remember, this method ONLY handles X's picks
    // sr=X initial pick of item i + X's Next pick (which was minimized by Y pick of i+1 or n)
    // sl=X initial pick of item n + X's Next pick (which was minimized by Y pick of i or n-1)
    mem[i][n] = max(sl,sr);
    return mem[i][n];
}

void driver()
{
    int arr[] = {887,778,916,794,336,387,493,650,422,363,28,691,60,764,927,541,427,173,737,212,369,568,430,783,531,863,124,68,136,930,803,23,59,70,168,394,457,12,43,230,374,422,920,785,538,199,325,316,371,414,527,92,981,957,874,863,171,997,282,306,926,85,328,337,506,847,730,314,858,125,896,583,546,815,368,435,365,44,751,88,809,277,179,789};
    int n = sizeof(arr)/sizeof(arr[0]);
    int** meme = new int*[n];
    for(int i=0;i<n;i++){
        meme[i] = new int[n];
        for(int j=0;j<n;j++){
            if(i==j){meme[i][j] = arr[i]; }
            else {meme[i][j] = 0;}
        }
    }
    cout << dp(arr,0,n-1, meme);
    return 0;
}

#endif // POTS_OF_GOLD_H_INCLUDED
