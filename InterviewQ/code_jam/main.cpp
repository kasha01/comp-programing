#include <bits/stdc++.h>
using namespace std;
typedef unsigned long long int uint64;


int t;
long long f, l;

long long get(long long a) {
	long long ba = a % 10;
	a /= 10;
	long long x = 0, v = 1, sum = 0;
	while (a) {
		x += a % 10 * v;
		sum += a % 10;
		a /= 10;
		v *= 9;
	}
	long long re = x * 8;
	for (long long i = 0; i <= ba; i++)
		re += !!((sum + i) % 9);
	// printf("x %lld ba %lld re %lld > %lld\n", x, ba, x * 8, re);
	return re;
}

int main() {
	long long l = 102;
	long long f = 88;
	cout << get(l) - get(f) + 1;
	return 0;
}
