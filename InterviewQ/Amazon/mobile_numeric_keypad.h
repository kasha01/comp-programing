#ifndef MOBILE_NUMERIC_KEYPAD_H_INCLUDED
#define MOBILE_NUMERIC_KEYPAD_H_INCLUDED


//Given a number N, find out the number of possible numbers of given length.
// http://www.geeksforgeeks.org/mobile-numeric-keypad-problem/

long long int** table;

long long int arr[4][3] = {
                {1,2,3 },
                {4,5,6 },
                {7,8,9 },
                {-1,0,-1 },
            };

vector<long long int> getAdj(long long int s)
{
    long long int row = 0; long long int col = 0;

    if (s == 0)
    {
        col = 1; row = 3;
    }
    else if (s % 3 == 0)
    {
        row = (s / 3) - 1;
        col = 2;
    }
    else
    {
        col = (s % 3) - 1;
        row = s / 3;
    }

    vector<long long int> adj;
    adj.push_back(arr[row][ col]);

    // top
    if (row - 1 >= 0)
        adj.push_back(arr[row - 1][col]);

    // bottom
    if (row + 1 < 4 && arr[row + 1][ col] != -1)
        adj.push_back(arr[row + 1][ col]);

    // right
    if (col - 1 >= 0 && arr[row][ col - 1] != -1)
        adj.push_back(arr[row][ col - 1]);

    // left
    if (col + 1 < 3 && arr[row][ col + 1] != -1)
        adj.push_back(arr[row][ col + 1]);

    return adj;
}


long long int dp2(long long int s, long long int n)
{
    if (n <= 0)
    {
        return 1;
    }

    vector<long long int> adj = getAdj(s);
    long long int sum = 0;
    for (long long int i = 0; i < adj.size(); i++)
    {
        if (table[adj[i]][n - 1] == 0)
            table[adj[i]][n - 1] = dp2(adj[i], n - 1);

        table[s][n] = table[s][ n] + table[adj[i]][ n - 1];
    }
    return table[s][n];
}

void driver()
{
    long long int t = 0; cin >> t;
    table = new long long int*[10];

    while(t>0){
        t--;
        long long int res = 0;
        long long int n = 0; cin >> n;
        long long int sum = 0;

        for (long long int i = 0; i < 10; i++)
        {
            table[i] = new long long int[n]();
            //memset(table[i],0,n*sizeof(long long int));
        }

        for (long long int i = 0; i <= 9; i++)
        {
            sum = sum + dp2(i, n - 1);
            table[i][n - 1] = sum;
        }

        cout << table[9][n-1] << endl;


        for (long long int i = 0; i < 10; i++)
        {
            delete table[i];
        }
    }
};


#endif // MOBILE_NUMERIC_KEYPAD_H_INCLUDED
