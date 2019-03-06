#ifndef BITMANU_H_INCLUDED
#define BITMANU_H_INCLUDED

//https://www.hackerrank.com/challenges/sum-vs-xor
void sumvsxor(){
    long long int c = 0;
    long long int n = 1000000000000000;
    vector<long long int> bin;
    do{
        bin.push_back(n%2);
        if(n%2 == 0){c=c+1;}
        n=n/2;
    }while(n>0);

    cout.setf(ios::fixed);
    cout << setprecision(0) << pow(2,c);
}

#endif // BITMANU_H_INCLUDED
