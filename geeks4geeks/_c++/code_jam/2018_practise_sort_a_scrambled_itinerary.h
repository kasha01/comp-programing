#ifndef 2018_PRACTISE_SORT_A_SCRAMBLED_ITINERARY_H_INCLUDED
#define 2018_PRACTISE_SORT_A_SCRAMBLED_ITINERARY_H_INCLUDED

// https://code.google.com/codejam/contest/4374486/dashboard#s=p3
map<string,char> city;
map<string,string> flight;

void dic(string c, char d){
	map<string,char>::iterator it = city.find(c);

	if(it != city.end()){
		// city alreayd exists
		city.erase(it);
	}
	else{
		// city not found
		city[c] = d;
	}
}

string solve(int n){
	string start_point = "";
    for(map<string,char>::iterator it=city.begin(); it!=city.end(); it++){
		if(it->second == 's'){
			start_point = it->first;
		}
    }


    string cur_destination = "";
    string cur_source = start_point;
	string result = "";
	map<string,string>::iterator it = flight.begin();
	for(int i=0;i<n;i++){
        it = flight.find(cur_source);
        cur_destination = it->second;
        result = result + cur_source + "-" + cur_destination + " ";
        cur_source = cur_destination;
	}

	return result;
}

void readfile(){
    ofstream fo; fo.open("output.txt");
    int T = 0;
    ifstream fin; fin.open("source.txt");
    fin >> T;

	string source = "";
	string destination = "";
    for(int t=1; t<=T; ++t){
		city.clear();
		flight.clear();
        int N=0;
        fin >> N;
        for(int i=0;i<N;i++){
			fin >> source;
			fin >> destination;
			dic(source,'s');
			dic(destination,'d');

            flight[source] = destination;
        }

        string result = solve(N);

        fo << "Case #" << t << ": " << result << endl;
    }
}



#endif // 2018_PRACTISE_SORT_A_SCRAMBLED_ITINERARY_H_INCLUDED
