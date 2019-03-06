#include <bits/stdc++.h>
using namespace std;

#define m(a) (a%1000000007)
typedef unsigned long long int uint64;
typedef signed long long int int64;

int64 solve(int64** arr, int N);

void readfile(){
    ofstream fo; fo.open("output.txt");

    int tt = 0;
    ifstream fin; fin.open("source.txt");
    fin >> tt;

    string result = "";
    for(int t=1; t<=tt; ++t){
		int n=0;
		fin >> n;

		int64** arr = new int64*[n];
		for(int i=0;i<n;++i){
			arr[i] = new int64[4];
			fin >> arr[i][0];fin >> arr[i][1];fin >> arr[i][2];fin >> arr[i][3];
		}

        fo << "Case #" << t << ": " << solve(arr,n) << endl;

        for(int i=0;i<n;++i){
			delete[] arr[i];
		}
		delete[] arr;
    }
}


int64 solve(int64** arr, int N){
	int64 min_x=LLONG_MAX;
	int64 min_y=LLONG_MAX;
	int64 min_z=LLONG_MAX;
	int64 max_x=LLONG_MIN;
	int64 max_y=LLONG_MIN;
	int64 max_z=LLONG_MIN;

	int64 max_delta_x = LLONG_MIN;
	int64 max_delta_y = LLONG_MIN;
	int64 max_delta_z = LLONG_MIN;

	int s1=0; int s2=0;

	int64 a_n=0; int64 a_m=0;

    int i_x_min=0; int i_x_max=0;
    int i_y_min=0; int i_y_max=0;
    int i_z_min=0; int i_z_max=0;

    for(int i=0;i<N;++i){
		int64 r = arr[i][3];

		if(min_x > arr[i][0]-r){
			min_x = arr[i][0]-r;
			i_x_min = i;
		}
		if(min_y > arr[i][1]-r){
			i_y_min = i;
			min_y = arr[i][1]-r;
		}
		if(min_z > arr[i][2]-r){
			min_z = arr[i][2]-r;
			i_z_min = i;
		}

		if(max_x < arr[i][0]+r){
			max_x = arr[i][0]+r;
			i_x_max = i;
		}
		if(max_y < arr[i][1]+r){
			max_y = arr[i][1]+r;
			i_y_max = i;
		}
		if(max_z < arr[i][2]+r){
			max_z = arr[i][2]+r;
			i_z_max = i;
		}
    }

    char most_spanned_axis = 'o';
    int64 delta_temp=0;

	max_delta_x = abs(max_x - min_x);
	max_delta_y = abs(max_y - min_y);
	max_delta_z = abs(max_z - min_z);

	if(max_delta_x > max_delta_y){
		most_spanned_axis = 'x';
		s1 = i_x_min;
		s2 = i_x_max;
		a_n = min_x; a_m=max_x;
		delta_temp = max_delta_x;
	}
	else{
		most_spanned_axis = 'y';
		s1 = i_y_min;
		s2 = i_y_max;
		a_n = min_y; a_m=max_y;
		delta_temp = max_delta_y;
	}

	if(max_delta_z > delta_temp){
		most_spanned_axis = 'z';
		s1 = i_z_min;
		s2 = i_z_max;
		min_z; a_m=max_z;
	}

	int64 max_radius = max(arr[s1][3], arr[s2][3])*2;

	for(int i=0;i<N;++i){
        if(i==s1 || i == s2){continue;}

		int64 r = arr[i][3];
		int64 rx=0;

        if(most_spanned_axis == 'x'){
			int64 px = arr[i][0];
			rx = min(abs(a_n-(px+r)), abs(a_m-(px-r)));
        }
        else if(most_spanned_axis == 'y'){
			int64 py = arr[i][1];
			rx = min(abs(a_n-(py+r)), abs(a_m-(py-r)));
        }
        else if(most_spanned_axis == 'z'){
			int64 pz = arr[i][2];
			rx = min(abs(a_n-(pz+r)), abs(a_m-(pz-r)));
        }

		max_radius = max(max_radius, rx);
	}

	return max_radius;
}


void test() {
	int N=3;
	int64 inp[N][4] = {{1,0,0,5}, {9,9,9,3}, {-9,-9,-9,1} };

	int64** arr = new int64*[N];
	for(int i=0;i<N;++i){
		arr[i] = new int64[4];
		arr[i][0] = inp[i][0];
		arr[i][1] = inp[i][1];
		arr[i][2] = inp[i][2];
		arr[i][3] = inp[i][3];
	}
	cout << solve(arr, N);
}

int main() {
	readfile();
	return 0;
}
