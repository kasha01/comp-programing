#ifndef MAXIMUM_MONEY_H_INCLUDED
#define MAXIMUM_MONEY_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/maximum-money/0
// Given street of houses (a row of houses), each house having some amount of money kept inside; now there is a thief who is going to steal this // money but he has a constraint/rule that he cannot steal/rob two adjacent houses. Find the maximum money he can rob.
// n: number of house in the row/street, m:money in each house (all houses have same amount of m)
int getMaxMoney(int n, int m){
    int thief=0;
    if(n%2 == 0){
        // even
        thief = (n/2)*m;
    }
    else {
        thief = ((n/2)+1)*m;
    }
    return thief;
}

#endif // MAXIMUM_MONEY_H_INCLUDED
