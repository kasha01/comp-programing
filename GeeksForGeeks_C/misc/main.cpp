#include <bits/stdc++.h>

using namespace std;

struct node{
public:
	int value;
	node* left;
	node* right;

	node(int v){
		this->value = v;
		this->left = nullptr;
		this->right = nullptr;
	}
};


#define maxN 10

// To store factorial values
int fact[maxN];

// Function to return ncr
int ncr(int n, int r)
{
    return (fact[n] / fact[r]) / fact[n - r];
}

// Function to return the required sum
int findSum(int* arr, int n)
{
    // Intialising factorial
    fact[0] = 1;
    for (int i = 1; i < n; i++)
        fact[i] = i * fact[i - 1];

    // Multiplier
    int mul = 0;

    // Finding the value of multipler
    // according to the formula
    for (int i = 0; i <= n - 1; i++)
        mul += (int)pow(2, i) * ncr(n - 1, i);

    // To store the final answer
    int ans = 0;

    // Calculate the final answer
    for (int i = 0; i < n; i++)
        ans += mul * arr[i];

    return ans;
}

/* Reverses arr[0..i] */
void flip(int arr[], int i)
{
    int temp, start = 0;
    while (start < i)
    {
        temp = arr[start];
        arr[start] = arr[i];
        arr[i] = temp;
        start++;
        i--;
    }
}

// Returns index of the
// maximum element in
// arr[0..n-1]
int findMax(int arr[], int n)
{
int mi, i;
for (mi = 0, i = 0; i < n; ++i)
    if (arr[i] > arr[mi])
            mi = i;
return mi;
}

// The main function that
// sorts given array using
// flip operations
int f = 0;
int pancakeSort(int *arr, int n)
{
    // Start from the complete
    // array and one by one
    // reduce current size
    // by one
    for (int curr_size = n; curr_size > 1; --curr_size)
    {
        // Find index of the
        // maximum element in
        // arr[0..curr_size-1]
        int mi = findMax(arr, curr_size);

        // Move the maximum
        // element to end of
        // current array if
        // it's not already
        // at the end
        if (mi != curr_size-1)
        {
            f++;
            // To move at the end,
            // first move maximum
            // number to beginning
            flip(arr, mi);

            // Now move the maximum
            // number to end by
            // reversing current array
            flip(arr, curr_size-1);
        }
    }
}

// Function to return the minimum prefix reversals
int minimumPrefixReversals(int a[], int n)
{
    string start = "";
    string destination = "", t, r;
    for (int i = 0; i < n; i++) {
        // converts the number to a character
        // and add  to string
        start += to_string(a[i]);
    }
    sort(a, a + n);
    for (int i = 0; i < n; i++) {
        destination += to_string(a[i]);
    }

    // Queue to store the pairs
    // of string and number of reversals
    queue<pair<string, int> > qu;
    pair<string, int> p;

    // Initially push the original string
    qu.push(make_pair(start, 0));

    // if original string is the destination string
    if (start == destination) {
        return 0;
    }

    // iterate till queue is empty
    while (!qu.empty()) {

        // pair at the top
        p = qu.front();

        // string
        t = p.first;

        // pop the top-most element
        qu.pop();

        for(int i=0;i<n;i++){
            // peform prefix reversals for all index and push
            // in the queue and check for the minimal
            for (int j = i+2; j <= n; j++) {
                r = t;

                // reverse the string till prefix j
                reverse(r.begin()+i, r.begin() + j);

                // if after reversing the string from first i index
                // it is the destination
                if (r == destination) {
                    return p.second + 1;
                }

                // push the number of reversals for string r
                qu.push(make_pair(r, p.second + 1));
            }
        }
    }
}


int main()
{
	int arr[] = {23, 10, 20, 11, 12, 6, 7};
    int n = sizeof(arr)/sizeof(arr[0]);

    pancakeSort(arr,n);
    cout << f;
    // Calling function
    //cout << minimumPrefixReversals(arr, n);

    return 0;
}
