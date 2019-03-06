#ifndef OVERLAPPING_INTERVALS_H_INCLUDED
#define OVERLAPPING_INTERVALS_H_INCLUDED

// https://www.geeksforgeeks.org/merging-intervals/
void mt(){

    int ar[] = {6, 8, 1, 9, 2, 4, 4, 7 };
    int n=sizeof(ar)/sizeof(ar[0]);

    vector<pair<int,int>> vec;

    // get input
    for(int i=0;i<n-1;i=i+2){
        pair<int,int> p = make_pair(ar[i], ar[i+1]);
        vec.push_back(p);
    }

    sort(vec.begin(), vec.end());

    // solve
    vector<pair<int,int>> outvec;
    int c=0;
    outvec.push_back(vec[0]);

    for(int i=1;i<vec.size(); i++){
        pair<int,int> newpair = vec[i];

        if(newpair.first>outvec[c].second){
            // newpair is out of range of existing pair
            outvec.push_back(newpair);
            c++;
        }
        else{
            if(newpair.second<=outvec[c].second){
                //ignore - will be swallowed
            }
            else{
                //swap - my new pair end is bigger than existing pair so extend existing pair end by the amount of new pair
                outvec[c].second = newpair.second;
            }
        }
    }

    // print
    for(int i=0;i<outvec.size();i++){
        cout << outvec[i].first << " " << outvec[i].second << endl;
    }
}

#endif // OVERLAPPING_INTERVALS_H_INCLUDED
