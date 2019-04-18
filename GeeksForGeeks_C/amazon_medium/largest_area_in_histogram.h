#ifndef LARGEST_AREA_IN_HISTOGRAM_H_INCLUDED
#define LARGEST_AREA_IN_HISTOGRAM_H_INCLUDED

// https://www.geeksforgeeks.org/largest-rectangle-under-histogram/
// The idea is For every bar ‘x’, we calculate the area with ‘x’ as the smallest bar in the rectangle.
// If we calculate such area for every bar ‘x’ and find the maximum of all areas, our task is done.
// How to calculate area with ‘x’ as smallest bar? We need to know index of the first smaller (smaller than ‘x’)
// bar on left of ‘x’ and index of first smaller bar on right of ‘x’.
// so basically 'x' is to be the bar surrounded by two bars on the left and right that are smaller than 'x',
// these two right,left boundaries makes 'x' the smaller bar within this range, so the max area is the height of x
// multiplied by the index range between left and right.

int getMaxArea(int hist[], int n)
{
    // Create an empty stack. The stack holds indexes of hist[] array
    // The bars stored in stack are always in increasing order of their
    // heights.
    stack<int> s;

    int max_area = 0; // Initalize max area
    int tp;  // To store top of stack
    int area_with_top; // To store area with top bar as the smallest bar

    // Run through all bars of given histogram
    int i = 0;
    while (i < n)
    {
        // If this bar is higher than the bar on top stack, push it to stack
        if (s.empty() || hist[s.top()] <= hist[i])
            s.push(i++);

        // If this bar is lower than top of stack, then calculate area of rectangle
        // with stack top as the smallest (or minimum height) bar. 'i' is
        // 'right index' for the top and element before top in stack is 'left index'
        else
        {
            tp = s.top();  // store the top index
            s.pop();  // pop the top

            // Calculate the area with hist[tp] stack as smallest bar
            area_with_top = hist[tp] * (s.empty() ? i : i - s.top() - 1);

            // update max area, if needed
            if (max_area < area_with_top)
                max_area = area_with_top;
        }
    }

    // Now pop the remaining bars from stack and calculate area with every
    // popped bar as the smallest bar
    while (s.empty() == false)
    {
        // notice here i POPED my bar (top bar). i is the index of the bar that is smaller than my bar on the right side.
        // and the reamining s.top() is the index of the bar smaller than my bar on the left side.
        tp = s.top();
        s.pop();
        area_with_top = hist[tp] * (s.empty() ? i : i - s.top() - 1);

        if (max_area < area_with_top)
            max_area = area_with_top;
    }

    return max_area;
}

#endif // LARGEST_AREA_IN_HISTOGRAM_H_INCLUDED
