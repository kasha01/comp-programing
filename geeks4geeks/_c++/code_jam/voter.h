#ifndef VOTER_H_INCLUDED
#define VOTER_H_INCLUDED

// Solved Small Dataset Only
// https://code.google.com/codejam/contest/6304486/dashboard#s=p1
long long int factorial(int n, long long int* meme){
    if(n<=1){return 1;}
    if(meme[n] != 0){
        return meme[n];
    }
    meme[n]= n*factorial(n-1,meme);
    return meme[n];
}


long long int dp(int A, int B, int _a, int _b){

    long long int _result = 1;
    long long int result1 = 0;
    long long int result2 = 0;
    if(_a > _b && A>0){
        // Do A vote
        result1 = A*dp(A-1,B,_a+1,_b);
    }

    if(_a>_b + 1 && B>0 && A>0){
        // Do B vote
        result2 = B*dp(A,B-1,_a,_b+1);
    }
    else if(_a>_b + 1 && B>0){
        // only B left
        long long int* memo = new long long int[A+B+1];
        memset(memo,0,sizeof(long long int)*(A+B+1));
        memo[0] = memo[1] = 1;

        result2 = factorial(B,memo);
        delete[] memo;
    }

    return max(result1+result2,_result);
}

long long int solve(int A, int B)
{
    int aseat, bseat=0;

    long long int base = 1;
    base = A * dp(A-1,B,1,0);

    return base;
}

void readfile(){
    unordered_set<char> tempset;
    ofstream fo; fo.open("output.txt");
    int tt = 0;
    ifstream fin; fin.open("source.txt");
    fin >> tt;
    long long int result = 0;
    for(int t=1; t<=tt; ++t){
        int A,B=0;
        fin >> A >> B;

        long long int* memo = new long long int[A+B+1];
        memset(memo,0,sizeof(long long int)*(A+B+1));
        memo[0] = memo[1] = 1;
        long long int denom = factorial(A+B,memo);
        delete[] memo;

        result = solve(A,B);

        double vote = (double)result/denom;

        fo.precision(8);
        fo.setf(ios::fixed);
        fo.setf(ios::showpoint);
        fo << "Case #" << t << ": " << vote << endl;
    }
}

#endif // VOTER_H_INCLUDED
