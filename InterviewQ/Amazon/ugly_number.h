#ifndef UGLY_NUMBER_H_INCLUDED
#define UGLY_NUMBER_H_INCLUDED

// https://www.geeksforgeeks.org/ugly-numbers/

// Ugly numbers are numbers whose only prime factors are
// 2, 3 or 5. The sequence 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15, … shows the first 11 ugly numbers.
// given number n, find the nth ugly number
// n=7 --> ugly number = 8, n=10 --> ugly number = 12

int mymin(int aa, int bb, int cc, int& a, int& b, int& c)
{
  int m = aa;
  if (m > bb)
    m = bb;
  if (m > cc)
    m = cc;

  if(m==aa)
    a++;
  if(m==bb)
    b++;
  if(m==cc)
    c++;

  return m;
}


void ugly_number_driver()
{
    int k = 0; cin >> k;    // Rank to find its ugly number
    vector<int> arr;
    int n = 0; int sum = 1; arr.push_back(1);
    int a=0; int b=0; int c=0;
    while(n < k-1){
        sum = mymin(2*arr[a], 3*arr[b], 5*arr[c], a,b,c);
        n++;
        arr.push_back(sum);
    }

    cout << sum;
    arr.clear();
}

#endif // UGLY_NUMBER_H_INCLUDED
