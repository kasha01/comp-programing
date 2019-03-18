#ifndef 2017_ROUND_B_A_MATH_ENCODER_H_INCLUDED
#define 2017_ROUND_B_A_MATH_ENCODER_H_INCLUDED

// https://code.google.com/codejam/contest/11304486/dashboard

using namespace std;

// my solution O(n^2)
#define m(a) (a%1000000007)
typedef unsigned long long int uint64;
uint64 power(uint64 x, unsigned int y, int p)
{
    uint64 res = 1;
    x = x % p;
    while (y > 0)
    {
        if (y & 1)
            res = (res*x) % p;

        y = y>>1;
        x = (x*x) % p;
    }
    return res;
};

// https://code.google.com/codejam/contest/11304486/dashboard
uint64 solve(int* arr, int N){
	uint64 sum = 0;
	for(int i=N-1;i>=0;--i){
        int l = arr[i];
        for(int j=0;j<i;++j){
			int s = arr[j];
            sum = m(m(sum) + m((l-s)* power(2,i-j-1,1000000007)));
        }
	}

	return sum;
}

void readfile(){
    unordered_set<char> tempset;
    ofstream fo; fo.open("output.txt");
    int tt = 0;
    ifstream fin; fin.open("source.txt");
    fin >> tt;

    string result = "";
    for(int t=1; t<=tt; ++t){
		int n=0;
		fin >> n;

		int arr[n];
		for(int i=0;i<n;++i){
			fin >> arr[i];
		}

        fo << "Case #" << t << ": " << solve(arr,n) << endl;
    }
}


////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// pps_789 solution

// Explain
/*
Consider array {A,B,C,D}
the solutions will be the summation of:
B-A, C-B, C-A, D-C, D-B, D-A, C-A, D-A, D-A, D-B, D-A, A, -A, B, -B, C, -C, D, -D
==> this yields to
4D-4A + 2D-2B + 2C-2A + B-A + C-B + D-C +A-A + B-B + C-C + D-D.
If I group by +/- variables...I mean if I count the number of positive D and negative D and so on
(8D-0D) + (4C-2C) + (2B-4B) + (1A-8A)

this matches the equation: X * 2^(i-1) - X * 2^(n-i). where i is the index of the number starting from 1.
and X is A,B,C,D...etc

so for array {3,6,7,9} ==> i=1->3, i=2->6, i=3->7, i=4->9. n=3

then I apply:
i=1 -> 3 ==> 3*2^0 - 3*2^3 = 3-24
i=2 -> 6 ==> 6*2^1 - 6*2^2 = 12-24
i=3 -> 7 ==> 7*2^2 - 7*2^1 = 28-14
i=4 -> 9 ==> 9*2^3 - 9*2^0 = 72-9

the summation is 44 which is the right answer
*/

const int MOD = 1e9 + 7;
const int N = 1e4 + 5;

int po[N];
int arr[N] = {0,3,6,7,9};
int n=4;

// pre computing the powers of 2..2^0, 2^1, 2^2, 2^3...etc
void precompute() {
	po[0] = 1;
	for(int i = 1 ; i < N ; i++) {
		po[i] = 2 * po[i-1] % MOD;
	}
}

int solve() {
	int ret = 0;
	for(int i = 1 ; i <= n ; i++) {
		int kiri = i-1;
		int kanan = n-i;

		long long tambah = 1ll * po[kiri] * (arr[i]) % MOD;
		long long kurang = 1ll * po[kanan] * (-arr[i]) % MOD;

		ret = (ret + tambah) % MOD;
		ret = (ret + kurang) % MOD;
	}

	if(ret < 0) ret += MOD;
	return ret;
}

void solvethis() {
	precompute();
	int ret = solve();
	cout << ret;
}

#endif // 2017_ROUND_B_A_MATH_ENCODER_H_INCLUDED
