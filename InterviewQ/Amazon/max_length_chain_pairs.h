#ifndef MAX_LENGTH_CHAIN_PAIRS_H_INCLUDED
#define MAX_LENGTH_CHAIN_PAIRS_H_INCLUDED

// http://www.geeksforgeeks.org/dynamic-programming-set-20-maximum-length-chain-of-pairs/

// For example, if the given pairs are {{5, 24}, {39, 60}, {15, 28}, {27, 40}, {50, 90} },
// then the longest chain that can be formed is of length 3, and the chain is {{5, 24}, {27, 40}, {50, 90}}
struct pair1{
	int a;
	int b;
};

/*
if 1st item < 2nd item => reutnrs -1 => sort puts a1 before b1
if 1st item = 2nd item => returns 0  => sort keep things as is
if 1st item > 2nd item => reutnrs 1  => sort puts a1 after b1
*/
bool comp(struct pair1 a1,struct pair1 b1)
{
    return a1.b<b1.b;
}

void solve(pair1 arr[],int n)
{
    int i,j,ans=0;
    sort(arr,arr+n,comp);
    ans=1;
    j=0;
    for(i=1;i<n;i++)
    {
        if(arr[i].a>arr[j].b)
        {
            ans++;
            j=i;
        }
    }
    cout<<ans<<endl;
};

void Driver(){
    int i;
    struct pair1 arr[] = {
        {5, 24}, {39, 60}, {15, 28}, {27, 40}, {50, 90}
    };
    int n = sizeof(arr)/sizeof(arr[0]);
    solve(arr,n);
}

#endif // MAX_LENGTH_CHAIN_PAIRS_H_INCLUDED
