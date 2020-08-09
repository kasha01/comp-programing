#ifndef COUNTRY_LEADER_H_INCLUDED
#define COUNTRY_LEADER_H_INCLUDED

// https://code.google.com/codejam/contest/6304486/dashboard
void solve()
{
    unordered_set<char> tempset;

    ofstream fo; fo.open("output.txt");
    int tt = 0;
    ifstream fin; fin.open("source.txt");
    fin >> tt;

    for(int t=1; t<=tt; ++t){
        string leader=""; int c_leader=0;
        string str="";
        tempset.clear();

        int ww=0; fin >> ww;  getline(fin,str); // cin/fin >> is still at the second line of words count-getline to ignore the line feed and jump to next line
        for(int w=1; w<=ww; ++w){
            getline(fin, str);  // or fin >> str; and delete the extra getline(fin,str); above
            int sz = str.size();
            for(int i=0;i<sz;++i){
                if(str[i] == ' '){continue;}
                tempset.insert(str[i]);
            }

            int k = tempset.size();

            if(k>c_leader){
                leader = str;
                c_leader = k;
            }
            else if(k==c_leader){
                if(str < leader){
                    leader = str;
                }
            }

            tempset.clear();
        }
        //cout << "Case #:" << t << ": " << leader << endl;
        fo << "Case #" << t << ": " << leader << endl;
    }
    return 0;
}


#endif // COUNTRY_LEADER_H_INCLUDED
