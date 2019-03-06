#ifndef MAX_PROFIT_BUY_SELL_STOCKS_TRANSACTION_H_INCLUDED
#define MAX_PROFIT_BUY_SELL_STOCKS_TRANSACTION_H_INCLUDED



// max difference between two elements (max profit if allowed to make 1 transaction)
int maxDiff(int arr[], int arr_size)
{
  int max_diff = arr[1] - arr[0];
  int min_item = arr[0];
  int i;
  for(i = 1; i < arr_size; i++)
  {
    if (arr[i] - min_item > max_diff)
      max_diff = arr[i] - min_item;
    if (arr[i] < min_item)
         min_item = arr[i];
  }
  return max_diff;
}


/*
The main idea is:
Max profit with at most two transactions =
    MAX {max profit with one transaction and subarray price[0..i] +
         max profit with one transaction and aubarray price[i+1..n-1]  }

So we loop in one direction to get max profile of on direction, then we loop in reverse direction, this time we takes into account the summation
of previous transaction profit current transaction. Notice indexes might overlap i.e. on first loop I sell at one index, and on the second loop
I might be buying at that index, but that is okay as I can buy and sell at the same index/day as long as I don't exceed my limit of
2 transactions.
*/
// max profit of at most 2 transactions buy->sell->buy->sell
// the idea is, we loop twice, first time we loop from n to 0, recording profit at each element..this profit
// is the max profit I can make if my array starts at i (i included). notice profit =
// max(profit[i+1], max_price-price[i]) => max of profit made ahead of me or me
// then I make my second loop, starting from 0-n, and figuring the max profit between my previous profit
// profit[i-1] and my current profit + whatever max profit that was calculated in the first loop
// which records the max profit made from i forward

int maxProfit(int price[], int n)
{
    int *profit = new int[n];
    for (int i=0; i<n; i++)
        profit[i] = 0;

    // Get Max profit for subarray [i+1....n-1]
    // notice how I proceed from i to n moving backwards until I finish all n by reaching 0
    int max_price = price[n-1];
    for (int i=n-2;i>=0;i--)
    {
        // max_price has maximum of price[i..n-1]
        if (price[i] > max_price)
            max_price = price[i];

        profit[i] = max(profit[i+1], max_price-price[i]);
    }

    // Get Max profit for subarray [0....i]
    // notice how I proceed from 0 forward to i until I finish all n
    int min_price = price[0];
    for (int i=1; i<n; i++)
    {
        // min_price is minimum price in price[0..i]
        if (price[i] < min_price)
            min_price = price[i];
        profit[i] = max(profit[i-1], profit[i] +
                                    (price[i]-min_price) );
    }
    int result = profit[n-1];

    delete [] profit; // To avoid memory leak

    return result;
}

//reverse approach
int maxProfit_reverse(int price[], int n)
{
    int *profit = new int[n];
    for (int i=0; i<n; i++)
        profit[i] = 0;

    // Get Max profit for sub array [0....i]
    int min_price = price[0];
    for (int i=1; i<n; i++)
    {
        // min_price is minimum price in price[0..i]
        if (price[i] < min_price)
            min_price = price[i];
        profit[i] = max(profit[i-1], price[i]-min_price);
    }

    // Get Max profit for sub array [i....n-1]
    int max_price = price[n-1];
    for (int i=n-2;i>=0;i--)
    {
        // max_price has maximum of price[i..n-1]
        if (price[i] > max_price)
            max_price = price[i];

        profit[i] = max(profit[i+1], profit[i] + (max_price-price[i]));
    }

    int result = profit[0];

    delete [] profit; // To avoid memory leak

    return result;
}

// For all K: number of transactions allowed
int solve(int arr[],int n,int k)
{
	int i,j;
	// this would work if pro[k+1][n], as n is the number of prices
	int pro[k+1][n+1];  // rows number of transactions | columns:prices

	// this would be i<n
	for(i=0;i<=n;i++)
	pro[0][i]=0;

	// first column has a profit of zero, as the profit on the first price mark (regardless of k)
	// would always be zero (buying and selling on the first price)
	for(i=0;i<=k;i++)
	pro[i][0]=0;

	// for each transaction
	for(i=1;i<=k;i++)
	{
	    // for each prices from 1 to n
		for(j=1;j<n;j++)
		{
			int ma=pro[i][j-1]; // initial max profit for current transaction is the previous profit.
                                // of this transaction (assuming I had more profit when selling at previous days)
			for(int m=0;m<j;m++){
                // m: all buying points/prices up to current sell price (J)

                // ma=Max{initial max, current(sell-buy) + profit made of previous transaction (i-1) where the selling price WAS m which
                // is now my current buying price/point}. Keep in mind, it OK to sell and then buy at the same price. i.e.
                // sell at m in previous transaction/previous day and buy at m in the current transaction/today.
                ma=max(ma,arr[j]-arr[m]+pro[i-1][m]);
			}
			pro[i][j]=ma;   //profit at transaction i, and selling price j is ma
		}
	}

	// notice how the result is at [n-1], I mean the max profit after I did k transaction and considering
	// all the (n) selling points (index:n-1)...
	cout << pro[k][n-1];
}

void driver(){
    int price[] = {2, 30, 15, 10, 8, 25, 80};
    int n = sizeof(price)/sizeof(price[0]);
    cout << maxProfit(price,n) << " " << maxProfit_reverse(price,n);
}

#endif // MAX_PROFIT_BUY_SELL_STOCKS_TRANSACTION_H_INCLUDED
