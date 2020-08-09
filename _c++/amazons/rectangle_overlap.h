#ifndef RECTANGLE_OVERLAP_H_INCLUDED
#define RECTANGLE_OVERLAP_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/overlapping-rectangles/0
void mt(){
    int r1_top_x = 89;
    int r1_top_y = 58;
    int r1_bottom_x = 97;
    int r1_bottom_y = 44;

    int r2_top_x = 66;
    int r2_top_y = 59;
    int r2_bottom_x = 89;
    int r2_bottom_y = 11;

    if((r1_bottom_x <= r2_top_x || r2_bottom_x <= r1_top_x)
        && (r1_top_y <= r2_bottom_y || r2_top_y <= r1_bottom_y))
        {
            // no overlap
            cout << 0;
        }
        else{
            cout << 1;
        }
}

#endif // RECTANGLE_OVERLAP_H_INCLUDED
