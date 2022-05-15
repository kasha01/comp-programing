#ifndef _1514_ROBOT_ROOM_CLEANER_H_INCLUDED
#define _1514_ROBOT_ROOM_CLEANER_H_INCLUDED

// https://www.lintcode.com/problem/1514/solution

/**
 * // This is the robot's control interface.
 * // You should not implement it, or speculate about its implementation
 * class Robot {
 *   public:
 *     // Returns true if the cell in front is open and robot moves into the cell.
 *     // Returns false if the cell in front is blocked and robot stays in the current cell.
 *     bool move();
 *
 *     // Robot will stay in the same cell after calling turnLeft/turnRight.
 *     // Each turn will be 90 degrees.
 *     void turnLeft();
 *     void turnRight();
 *
 *     // Clean the current cell.
 *     void clean();
 * };
 */
class Solution {
public:
    int x=0; int y=0;
    set<pair<int,int>> visited;
    int direction=0;
    int dx[4] = {0,1,0,-1};
    int dy[4] = {1,0,-1,0};

    void cleanRoom(Robot& robot) {
        if(visited.count({x,y})) {
             return;
         }

        robot.clean();
        visited.insert({x,y});

        for(int l=0;l<4;++l){
            if(robot.move()){
                x = x + dx[direction];
                y = y + dy[direction];

                cleanRoom(robot);

                // move to previous location
                robot.turnRight();
                robot.turnRight();
                robot.move();
                robot.turnRight();
                robot.turnRight();

                x = x - dx[direction];
                y = y - dy[direction];
            }

            direction = (direction + 1)%4;
            robot.turnRight();
        }
    }
};
#endif // _1514_ROBOT_ROOM_CLEANER_H_INCLUDED
