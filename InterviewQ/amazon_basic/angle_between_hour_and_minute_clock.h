#ifndef ANGLE_BETWEEN_HOUR_AND_MINUTE_CLOCK_H_INCLUDED
#define ANGLE_BETWEEN_HOUR_AND_MINUTE_CLOCK_H_INCLUDED

//http://practice.geeksforgeeks.org/problems/angle-between-hour-and-minute-hand/0

double clock(double h, double m){
    double mm=0; double hh=0;

    if(m==60){m=0;}
    else {
        mm = (m/60) * 360;
    }

    if(h==12){h=0;}
    hh = ((h/12)*360) + (30*(m/60)); // where did 30 degree come from? one round is 360, the hour clocks
    // is partitioned to 12 partition between each hour tick, 360/12=30. the angle between each hour tick is 30

    double diff = abs(hh-mm);
    if(diff > 180){
        if(hh>180){
            hh = 360-hh;
        }
        else{
            mm = 360-mm;
        }
        diff = hh+mm;
    }

    return floor(diff);
}

#endif // ANGLE_BETWEEN_HOUR_AND_MINUTE_CLOCK_H_INCLUDED
