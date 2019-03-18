#ifndef MYHEADER_H_INCLUDED
#define MYHEADER_H_INCLUDED

using namespace std;

void Find_first_and_last_occurrence_of_x(int r, int l, int v, int& fi, int& la, int arr[])
{
    int mid = (r+l)/2;
    if(r>l){return;}

    if(arr[mid] > v){
        Find_first_and_last_occurrence_of_x(r,mid-1,v,fi,la,arr);
    }
    else if(arr[mid]<v){
        Find_first_and_last_occurrence_of_x(mid+1,l,v,fi,la,arr);
    }
    else if(arr[mid] == v){
        if(fi == -1){
            fi=mid;
        }else if(mid <fi){
            fi = mid;
        }
        if(la == -1){
            la=mid;
        }else if(mid > la){
            la = mid;
        }
        Find_first_and_last_occurrence_of_x(r,mid-1,v,fi,la,arr);
        Find_first_and_last_occurrence_of_x(mid+1,l,v,fi,la,arr);
    }
    else{
        return;
    }
}

void Roman_Number_to_Integer(string rom){

    map<char,int> rom_map;
    rom_map['I'] = 1;
    rom_map['V'] = 5;
    rom_map['X'] = 10;
    rom_map['L'] = 50;
    rom_map['C'] = 100;
    rom_map['D'] = 500;
    rom_map['M'] = 1000;

    int bef = rom_map[rom[rom.size()-1]];
    int num = 0;
    int sum = bef;
    for(int i=rom.size()-2; i>=0; i--){
        num = rom_map[rom[i]];
        if(num < bef){
            sum = sum - num;
        }
        else{
            sum = sum + num;
        }
        bef = num;
    }

    cout << sum << endl;
};

// Find All four Sums
void merge_sort(int ar[], int sz){

    if (sz < 2)
    {
        return;
    }

    int mid = sz / 2;
    int left[mid];
    int right[sz-mid];
    for(int ii = 0; ii < mid; ii++)
    {
        left[ii] = ar[ii];
    }
    for (int jj = mid; jj < sz; jj++)
    {
        right[jj - mid] = ar[jj];
    }

    merge_sort(left,mid);
    merge_sort(right, sz-mid);

    int k = 0;
    int i = 0; int j = 0;
    while(i < mid && j < sz-mid)
    {
        if(left[i] < right[j])
        {
            ar[k] = left[i]; i++;
        }
        else
        {
            ar[k] = right[j]; j++;
        }
        k++;
    }

    while (i < mid)
    {
        ar[k] = left[i]; i++; k++;
    }
    while (j < sz-mid)
    {
        ar[k] = right[j]; j++; k++;
    }
};

class obj{
public:
    int fi; int se; int th; int fo;
    //obj(int fi, int se, int th, int fo) : fi(fi), se(se), th(th), fo(fo){}
    obj(int fi, int se, int th, int fo){
      this->fi = fi;
      this->se = se;
      this->th = th;
      this->fo = fo;;
    }

};

void findSums(int arr[], int sum, int sz){
    vector<obj*> v;
    int third = 0;
    int forth = 0;
    int s = 0;
    //int sz = sizeof(arr)/sizeof(arr[0]);
    map<string,bool> mp;
    ostringstream os;
    int counter = 0;
    for(int first = 0; first< sz-3; first++ ){
        for(int second=first+1; second <sz-2; second++){
            third = second + 1;
            forth = sz - 1;

            while(third < forth){
                s = arr[first] + arr[second] + arr[third] + arr[forth];
                if(s == sum){
                    os << arr[first] << arr[second] << arr[third] << arr[forth];
                    string myhash = os.str();
                    if(mp.find(myhash) == mp.end()){
                        // not found
                        mp[myhash] = true;
                        v.push_back(new obj(arr[first], arr[second], arr[third], arr[forth]));
                    }
                    os.str("");
                    third++; forth--; counter++;
                }
                else if(s < sum){
                    third++;
                }
                else{
                    forth--;
                }
            }
        }
    }

    //print
    if(v.size() == 0){
        cout << -1;
    }
    else{
        for(vector<obj*>::iterator it= v.begin(); it != v.end(); it++){
            //int jj = (*(it))->fi;
            cout << (*(it))->fi << " " << (*(it))->se << " " << (*(it))->th << " " << (*(it))->fo << " $";
        }
    }
    cout << endl;
}

// End Find All Four Sums

void DecodeThePattern(int counter){
    string seed = "1";
    string result = "1";
    char prev = seed[0];
    int scounter = 0;
    ostringstream os;
    while (counter > 1){
        counter--;
        int l = seed.size();
        for(int i=0; i<l; i++){
            if(seed[i] == prev){
                scounter++;
            }
            else{
                os << scounter << prev;
                prev = seed[i];
                scounter = 1;
            }
        }
        os << scounter << prev;
        seed = os.str();
        prev = seed[0]; scounter = 0;
        os.str("");
    }

    cout << os.str() << seed << endl;
}

// http://practice.geeksforgeeks.org/problem-page.php?pid=1687
void findTypeOfArray(){
    int t = 0;
    cin >> t;
    while(t > 0){
        t--;
        int sz = 0;
        cin >> sz;
        //int arr[sz];
        int la = 0;
        int inp = 0;
        cin >> inp;
        int mx = inp; int mn = inp; int fi = inp;
        for(int i=1;i<sz;i++){
            cin >> inp;
            if(inp > mx){mx = inp;}
            else if(inp<mn){mn = inp;}
        }
        la = inp;

        if(mx==la && mn == fi){cout << mx << " 1" << endl;}
        else if(mx == fi && mn==la){cout << mx << " 2" << endl;}
        else {
            if(la > fi){cout << mx << " 3" << endl;}
            else if(la < fi){cout << mx << " 4" << endl;}  // asc rot
        }
    }
}

void find_two_distinct_numbers(){
    int arr[] = { 1, 2, 3, 2, 1, 4};

    int x = 0;
    for(int i=0; i<6; i++){
        x = x ^ arr[i];
    }
    int lsb = x & (-x);

    int fi = 0; int sec = 0;
    for(int i=0; i<6; i++){
        if(arr[i] & lsb == true){
            fi = fi ^ arr[i];
        }
        else{
            sec = sec ^ arr[i];
        }
    }

    cout << fi << " " << sec;
};


#endif // MYHEADER_H_INCLUDED

