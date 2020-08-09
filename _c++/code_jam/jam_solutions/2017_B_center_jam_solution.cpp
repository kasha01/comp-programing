#include <bits/stdc++.h>
using namespace std;

const int N = 1e4 + 5;
const int MAGIC = 80;
const double MX = 1e3 + 5;

double x[N], y[N], w[N];
int n;

void read() {
	cin >> n;
	for(int i = 0 ; i < n ; i++) {
		cin >> x[i] >> y[i] >> w[i];
	}
}

double coba(double tx, double ty) {
	double ret = 0;
	for(int i = 0 ; i < n ; i++)
		ret += w[i] * max(fabs(tx - x[i]), fabs(ty - y[i]));
	return ret;
}

// find the minimum way for x = tx
double coba(double tx) {
	// I picked an x.
	// now using ternary search again, try all Ys (find minimum y)
	double lo = -MX, hi = MX;
	for(int i = 0 ; i < MAGIC ; i++) {
		double p1 = lo + (hi - lo) / 3;
		double p2 = lo + 2 * (hi - lo) / 3;

		// find minimum why that satsifies the equation.
		if(coba(tx, p1) > coba(tx, p2)) {
			lo = p1;
		} else {
			hi = p2;
		}
	}
	// return the min value for the picked x,y
	return coba(tx, lo);
}

double solve() {
	// user ternary search
	double lo = -MX, hi = MX;

	// try all Xs in the domain, find minimum X
	for(int i = 0 ; i < MAGIC ; i++) {
		double p1 = lo + (hi - lo) / 3;
		double p2 = lo + 2 * (hi - lo) / 3;
		// pick random domain from lo to hi and random m1 and m2
		// find the minimum x for that domain
		if(coba(p1) > coba(p2)) {
			lo = p1;
		} else {
			hi = p2;
		}
	}
	// at this point, after trying all Xs, I picked the minimum X.
	// do one more time to pick the minimum Y.
	return coba(lo);
}


void readfile(){
    ofstream fo; fo.open("output.txt");
    int T = 0;
    ifstream fin; fin.open("source.txt");
    fin >> T;
    for(int t=1; t<=T; ++t){
        fin >> n;

		for(int i = 0 ; i < n ; i++) {
			fin >> x[i] >> y[i] >> w[i];
		}

		double result = solve();
        fo << "Case #" << t << ": " << result << endl;
    }
}

int main() {
	readfile();
	return 0;
}
