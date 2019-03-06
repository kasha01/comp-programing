#ifndef CHECK_IF_FOUR_POINTS_FORM_SQUARE_H_INCLUDED
#define CHECK_IF_FOUR_POINTS_FORM_SQUARE_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/check-if-given-four-points-form-a-square/0
void is_square(){
    //  20 20 20 10 10 20 10 10
    int ax=20; int bx=20; int cx=10; int dx=10;
    int ay=20; int by=10; int cy=20; int dy=10;

    int dxab = bx-ax;
    int dyab = by-ay;

    int dxbc = cx-bx;
    int dybc = cy-by;

    int dxcd = dx-cx;
    int dycd = dy-cy;

    int dxad = dx-ax;
    int dyad = dy-ay;

    int dxac = cx-ax;
    int dyac = cy-ay;

    int dxbd = dx-bx;
    int dybd = dy-by;

    vector<double> v;
    v.push_back(pow(dxab,2) + pow(dyab,2));
    v.push_back(pow(dxbc,2) + pow(dybc,2));
    v.push_back(pow(dxcd,2) + pow(dycd,2));
    v.push_back(pow(dxad,2) + pow(dyad,2));
    v.push_back(pow(dxac,2) + pow(dyac,2));
    v.push_back(pow(dxbd,2) + pow(dybd,2));

    std::sort(v.begin(), v.end());

    // v[0] > 0 to catch the case where i have at least two poionts on the same coordinate, meaning I will have a triangle
    if((v[0]>0) && (v[0] == v[1]) && (v[1]== v[2]) && (v[2]== v[3])){
        cout << "square";
    }
    else{
        cout << "not square";
    }
}

#endif // CHECK_IF_FOUR_POINTS_FORM_SQUARE_H_INCLUDED
