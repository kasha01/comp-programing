#ifndef LARGEST_NUMBER_FORMED_FROM_ARRAY_H_INCLUDED
#define LARGEST_NUMBER_FORMED_FROM_ARRAY_H_INCLUDED


// https://practice.geeksforgeeks.org/problems/largest-number-formed-from-an-array/0


// tricky answer
bool comp(int a, int b) {
    string x = to_string(a);
    string y = to_string(b);

    // apparently x+y will concatinate the strings, and > sign will cast the concatinated strings into integer
    return x+y > y+x;
};


// my answer
struct obj{
    int n;
    vector<int> vec;
    obj(int d){
        this->n = d;
    }
};

bool compare(obj* a, obj* b){

    int i=a->vec.size()-1;
    int j=b->vec.size()-1;

    if(i==j){
        // same digits count
        return a->n >= b->n;
    }

    while(i>=0 && j>=0){
        if(a->vec[i] == b->vec[j]){
            // continue
        }
        else if(a->vec[i] > b->vec[j]){
            return true;
        }
        else if(a->vec[i] < b->vec[j]){
            return false;
        }
        i--; j--;
    }

    int adigits = a->vec.size();
    int bdigits = b->vec.size();

    // a first then b OR b first then a;
    return ((a->n)*pow(10,bdigits)) + b->n >= ((b->n)*pow(10,adigits)) + a->n;
}


void mt()
{
    vector<int> v={624,421,145,969,736,916,626,535,43,12,680,153,245,296,819,397,693,816,992,34,670,398,554,548,826,211,663,212,809,378,762,626,336,869,996,777,768,440,875,332,557,302,873,561,95,985,756,790,408,16,194,770,681,456,856,507,964,503,677,109,250,332,845,639,809,998,652,850,204,732,532,15,420,776,10,181,930,224,55,261,738,546,318,526,201,257};

    vector<obj*> vec_obj;

    int r=0;
    for(int i=0;i<v.size(); ++i){
        obj* ob = new obj(v[i]);
        int num = v[i];
        do{
            r = num%10;
            ob->vec.push_back(r);
            num = num/10;
        }while(num > 0);
        vec_obj.push_back(ob);
    }

    sort(vec_obj.begin(), vec_obj.end(), compare);

    for(int i=0;i<v.size(); ++i){
        cout << vec_obj[i]->n << " ";
        delete vec_obj[i];
    }
}


#endif // LARGEST_NUMBER_FORMED_FROM_ARRAY_H_INCLUDED
