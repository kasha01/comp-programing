#ifndef 2018_PRACTISE_GBUS_H_INCLUDED
#define 2018_PRACTISE_GBUS_H_INCLUDED

// https://code.google.com/codejam/contest/4374486/dashboard#s=p0

int r,n;
vector<pair<int,int>> range;
vector<int> buses;

void solve(int* result){
	for(int i=0;i<n;++i){
		for(int j=0;j<r;++j){
			int a = range[j].first;
			int b = range[j].second;

			if(buses[i] >= a && buses[i]<=b){
				result[i]++;
			}
		}
	}
}


void readfile(){
    ofstream fo; fo.open("output.txt");
    int T = 0;
    ifstream fin; fin.open("source.txt");
    fin >> T;
    for(int t=1; t<=T; ++t){
        range.clear();
        buses.clear();
        fin >> r;
        int a=0; int b=0;
		for(int i=0;i<r*2;i=i+2){
			fin >> a >> b;
			pair<int,int> p(a,b);
			range.push_back(p);
		}

		fin >> n;
		for(int i=0;i<n;++i){
			fin >> a;
			buses.push_back(a);
		}

		int* result = new int[n];
		memset(result,0,n*sizeof(int));

        solve(result);
        fo << "Case #" << t << ": ";
        for(int i=0;i<n;++i){
			fo << result[i] << " ";
        }
		fo << endl;
        delete[] result;

        fin.ignore();
    }
}


#endif // 2018_PRACTISE_GBUS_H_INCLUDED
