#ifndef ROUND_1_A_SQUARE_COUNTING_H_INCLUDED
#define ROUND_1_A_SQUARE_COUNTING_H_INCLUDED

// https://code.google.com/codejam/contest/8284486/dashboard#s=p0

// Only small set solution (actually this is the best solution - check algo)
long long int solve(long long int n, long long int m){
    long long int k=min(n,m);

    long long int sum=0;
    for(long long int i=1;i<k;++i){
        long long int nn = n-i;
        long long int mm = m-i;

        long long int ss = (nn)*(mm); // -> (R-x)*(C-x)
        sum = sum + ss;

        if(i>1){
            sum = sum + (i-1)*ss; // --> sum= (sum + ss) + ss(i-1) = sum + ss + ssi - ss = sum + ssi !duh
                                  // so this can be sum = sum + ssi
        }
        sum = sum % 1000000007;
    }

    return sum;
}

// Not my solution (Best of all)
// https://groups.google.com/forum/#!topic/google-code-jam-preparation-2017/iOckCIyBSQA
// This is using arithmetic progression (i.e. treating for loop into summation)
static long long int M    = 1000000007; // = 10^9 + 7
static long long int inv2 = 500000004; // inv of 2 mod M
static long long int inv3 = 333333336;  // inv of 3 mod M
inline long long int m(long long int x) {
    if (x < 0) x = x + M;
    return x % M;
} // helper to find x mod M

// total squares = n(n + 1)/2 * (n(n + 1)/2 - (R + C)(2n + 1)/3 + RC)
//                       = s(s - t + u)
//       where s = n(n+1)/2 mod M
//             t = (R + C)(2n + 1)/3 mod M
//             u = RC mod M
// answer = total mod M = m(total)
long long int solve(long long int R, long long int C) {
    long long int n = min(R, C);
    long long int s = m(m(m(n) * m(n + 1)) * inv2);
    long long int t = m(m((m(R) + m(C)) * m(2*n + 1)) * inv3);
    long long int u = m(R * C);
    return m(s * m(m(s + u) - t));
}



// =====================================================================================================================
// from geeks for geeks
typedef unsigned long long int uint64;
// works for small set only O(1)
uint64 solve_2(uint64 n, uint64 m){

    // n and m are square sides
    if(n<m){
        // swap
        uint64 temp = n;
        n = m;
        m=temp;
    }
    // n is the bigger side of the rectangular space

    // 1: summation of i (i=0->m)
    uint64 i_sigma = m*(m+1)/2;

    // 2: summation of i^2 (i=0->m)
    uint64 i_sq_sigma = (m*(m+1)*(2*m+1))/6;

    //3: summation of i^3 (i=0->m) => (m*(m+1)/2)^2
    uint64 i_cub_sigma = i_sigma * i_sigma;

    // 4.a: total counts of full squares => i_sq_sigma + (n-m)*i_sigma
    uint64 sum_sq = i_sq_sigma + (n-m)*i_sigma;

    // 4.b.1: total counts of diamonds in full squares => m*i_sq_sigma - i_cub_sigma
    uint64 sum_diamonds_1 = m*i_sq_sigma - i_cub_sigma;

    // 4.b.2: total count of diamonds in extended squares
    uint64 sum_diamonds_2 = (n-m)*(m*i_sigma - i_sq_sigma);

    // 4.b.3: total count of diamonds
    uint64 sum_diamonds = sum_diamonds_1 + sum_diamonds_2;

    uint64 total = sum_sq + sum_diamonds;

    return total%1000000007;
}


void readfile(){
    ofstream fo; fo.open("output.txt");
    int tt = 0;
    ifstream fin; fin.open("source.txt");
    fin >> tt;
    uint64 result = 0;
    for(int t=1; t<=tt; ++t){
        int R,C=0;
        fin >> R >> C;
        result = solve(R,C);
        result = solve_2(R-1,C-1);
        fo << "Case #" << t << ": " << result << endl;
    }
}

void test(){
    // dots
    int n = 1000; int m = 500;
    long long int sum = solve(n,m);
    cout << sum;
}


#endif // ROUND_1_A_SQUARE_COUNTING_H_INCLUDED
