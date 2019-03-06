#include <iostream>

using namespace std;

/* https://www.hackerrank.com/challenges/rectangle-area?h_r=next-challenge&h_v=zen */

class Rectangle{
    public:
    int width = 0;
    int height = 0;
    void display(){
        cout << width << " " << height << endl;
    }
};

class RectangleArea : public Rectangle{
    public:
    void read_input(){
        int w,h;
        cin >> w >> h;
        this->width = w;
        this->height = h;
    }
    void display(){
        int area = this->width * this->height;
        cout << area << endl;
    }
};

int main()
{
    /*
     * Declare a RectangleArea object
     */
    RectangleArea r_area;

    /*
     * Read the width and height
     */
    r_area.read_input();

    /*
     * Print the width and height
     */
    r_area.Rectangle::display();

    /*
     * Print the area
     */
    r_area.display();

    return 0;
}
