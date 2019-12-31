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

int main()
{
	int arr[] = { 2, 3 };
	int n = sizeof(arr) / sizeof(int);

    cout << findSum(arr, n);

    return 0;
}
