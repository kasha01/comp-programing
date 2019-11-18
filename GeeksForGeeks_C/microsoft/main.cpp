#include <bits/stdc++.h>

using namespace std;

struct Node
{
    int data;
    Node* left;
    Node* right;
    Node(int v){
		this->data= v;
		this->left = nullptr;
		this->right = nullptr;
    }
};

struct Interval
{
    int buy;
    int sell;
};

void stockBuySell(int price[], int n)
{
    // Prices must be given for at least two days
    if (n == 1)
        return;

    int count = 0; // count of solution pairs

    // solution vector
    Interval sol[n/2 + 1];

    // Traverse through given price array
    int i = 0;
    while (i < n-1)
    {
        // Find Local Minima. Note that the limit is (n-2) as we are
        // comparing present element to the next element.
        while ((i < n-1) && (price[i+1] <= price[i]))
            i++;

        // If we reached the end, break as no further solution possible
        if (i == n-1)
            break;

        // Store the index of minima
        sol[count].buy = i++;

        // Find Local Maxima.  Note that the limit is (n-1) as we are
        // comparing to previous element
        while ((i < n) && (price[i] >= price[i-1]))
            i++;

        // Store the index of maxima
        sol[count].sell = i-1;

        // Increment count of buy/sell pairs
        count++;
    }

    // print solution
    if (count == 0)
        printf("There is no day when buying the stock will make profitn");
    else
    {
       for (int i = 0; i < count; i++)
          printf("Buy on day: %dt Sell on day: %dn", sol[i].buy, sol[i].sell);
    }

    return;
}

void driver_stock(){
    // stock prices on consecutive days
    int price[] = {100, 180, 260, 310, 40, 535, 695};
    int n = sizeof(price)/sizeof(price[0]);

    // fucntion call
    stockBuySell(price, n);
}

int solve(string s1, string s2){
    int n = s1.size();
    int m = s2.size();

    int i = 0;
    int j = 0;
    while (i<n && j<n) {
        char c1 = s1 [i];
        char c2 = s2 [j];

        int p1 = (s1 [i] + 0)*10;
        int p2 = (s2 [j] + 0)*10;

        if(i+1 < n && c1 == 'n' && s1[i+1] == 'g'){
            p1 = p1 + 5;
            i++;
        }

        if(j+1 < n && c2 == 'n' && s2[j+1] == 'g'){
            p2 = p2 + 5;
            j++;
        }

        if(p1 < p2)
            return -1;
        else if(p1 > p2)
            return 1;

        i++;j++;
    }

    if(n<m)
        return -1;
    else if(n>m)
        return 1;
    else
        return 0;
}

int main()
{
    string s1 = "abc"; string s2 = "abcd";

    cout << solve(s1,s2);
    return 0;
}
