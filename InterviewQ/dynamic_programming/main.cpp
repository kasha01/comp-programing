#include <bits/stdc++.h>


using namespace std;

int M = 1000000007;

uint64_t* inverse = new uint64_t[1000000007];

uint64_t mul_mod(uint64_t a, uint64_t b, uint64_t m)
{
   long double x;
   uint64_t c;
   int64_t r;
   if (a >= m) a %= m;
   if (b >= m) b %= m;
   x = a;
   c = x * b / m;
   r = (int64_t)(a * b - c * m) % (int64_t)m;
   return r < 0 ? r + m : r;
};

// calc (a^b) mod m - uses the above method to calc (ab) mod m
uint64_t pow_mod(uint64_t a, uint64_t b, uint64_t m)
{
    uint64_t r = 1;
    while (b > 0) {
        if(b % 2 == 1)
            r = mul_mod(r, a, m);
        b = b >> 1;
        a = mul_mod(a, a, m);
    }
    return r;
};


uint64_t inv(int a){
	if(inverse[a] != -1){return inverse[a];}
    inverse[a] = pow_mod(a,M-2,M);
    return inverse[a];
}

uint64_t binomial2(int n, int k){
    if(n==k || k==0){return 1;}

	uint64_t res = 1;
	for (int i = 0; i < k; ++i)
	{
		res = (res * (n - i))%M;
		res = (res * inv(i+1))%M;
	}

	return pow_mod(res,2,M);
}

long long int binomial(int n, int k){
    if(n==k || k==0){return 1;}

	long long int res = 1;
	for (int i = 0; i < k; ++i)
	{
		res = res * (n - i);
		res = res / (i+1);
	}

	return res * res;
}


long long binomialCoeff3(int n, int k)
{
    if(n==k || k==0){return 1;}

	long long* C = new long long[k + 1];
	memset(C,0,sizeof(long long)*(k+1));

	C[0] = 1;  // nC0 is 1

	for (int i = 1; i <= n; i++)
	{
		for (int j = min(i, k); j > 0; j--)
			C[j] = C[j] + C[j - 1];
	}
	long long res = C[k];
	delete[] C;
	return res * res;
}

unsigned long long binomialCoeff4(int n, int k)
{
    if(n==k || k==0){return 1;}

	unsigned long long* C = new unsigned long long[k + 1];
	memset(C,0,sizeof(unsigned long long)*(k+1));

	C[0] = 1;  // nC0 is 1

	for (int i = 1; i <= n; i++)
	{
		for (int j = min(i, k); j > 0; j--)
			C[j] = (C[j]%M + C[j - 1]%M)%M;
	}
	unsigned long long res = C[k];
	delete[] C;
	return (res * res)%M;
}

int main()
{
    int n=487;
	memset(inverse,-1,M*sizeof(uint64_t));
    unsigned long long sum=0;
    for(int i=n;i>=0;--i){
		//sum = sum + binomialCoeff4(n,i);
		sum = sum + binomial2(n,i);
		sum = sum%M;
    }
    cout << sum;
    return 0;
}
