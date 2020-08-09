#ifndef A_SIMPLE_FRACTION_H_INCLUDED
#define A_SIMPLE_FRACTION_H_INCLUDED

// if a number has a repeating decimal, but it in brakets; 1/3 => 0.(3)
// https://practice.geeksforgeeks.org/problems/a-simple-fraction/0
void driver()
{
    map<int,int> mp;
    vector<int> vec;

    int n=10; int d=2;

    int dv = n/d;
    int r = n%d;

    int rep=-1; // decimal repetition index.
    int i=0;    // decimal number index 1.45 4:has an index of 0
    int num=0;  // result of division
    while(r!=0){
        mp[r] = i;
        num = (r*10)/d;
        vec.push_back(num);
        r = (r*10)%d;
        if(mp.find(r) != mp.end()){
            // found
            rep = mp[r];
            break;
        }
        i=i+1;
    }

    ostringstream os;
    os << dv;
    if(vec.size() > 0){
        // there was a remainder
        os << ".";
    }

    for(int j=0;j<vec.size();++j){
        if(rep==j){
            os << "(";
        }
        os << vec[j];
    }

    if(rep!= -1){
        os << ")";
    }

    cout << os.str();
}

#endif // A_SIMPLE_FRACTION_H_INCLUDED
