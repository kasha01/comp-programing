#ifndef ALLOCATE_MIN_NUMBER_OF_PAGES_H_INCLUDED
#define ALLOCATE_MIN_NUMBER_OF_PAGES_H_INCLUDED

// https://www.geeksforgeeks.org/allocate-minimum-number-pages/

// Assuming calling my MaxStudent = MStudent
// Utility function to check if current minimum value is possible or not.
// curr_min is the Minimum no of pages the Max Student can have i.e.
// it is no of pages My desginated student (student 1) can have in order to be the student with BARELY the Max no
// of pages among other students BUT also minimum enough.
bool isPossible(int arr[], int n, int m, int curr_min)
{
    int studentsRequired = 1;
    int curr_sum = 0;

    // iterate over all books
    for (int i = 0; i < n; i++)
    {
        // if I get a book that is larger than my current_min solution, this means some other student must have
        // this book as my MStudent cannot have pages more than cur_min (which is the proposed solution). therefore
        // this book will have to go to someone else and this makes my MStudent not having the Maximum no of pages
        // among the other students, so cur_min as a solution is NOT possible and I return false
        if (arr[i] > curr_min)
            return false;

        // count how many students are required
        // to distribute curr_min pages
        // if curr_sum(which is the current no of book pages the current student has) + the current book to consider
        // arr[i] is greater than curr_min --> that means this student (indicated by studentsRequired) cannot have
        // more books accumulated to his curr_sum, therefore: 1) add a new student to the mix. 2)reset cur_sum
        // accumulate to the current book (meaning my previous student had the old cur_sum and my new considered
        // student gets this book arr[n], 3) check if I have exceed my students limits. if there are no more
        // studetns that can be considered studentsRequired>m--> then this solution is not possible.
        if (curr_sum + arr[i] > curr_min)
        {
            // increment student count. Now considered another student
            studentsRequired++;

            // update curr_sum. current student gets this book and accumulate.
            curr_sum = arr[i];

            // if students required becomes greater
            // than given no. of students,return false
            if (studentsRequired > m)
                return false;
        }

        // else update curr_sum.
        // Here is a counter of how many pages the current student can have..as long as cur_sum doesn't exceed
        // cur_min which is my proposed solution as the Max no of pages MStudent can have...I keep accumulating.
        else
            curr_sum += arr[i];
    }
    return true;    // all books were able to be distributed among all students without one student exceed the
                    // cur_min. so return true. Notice here MStudent is the first student to be considered as he
                    // gets papers accumulated until his cur_sum becomes > cur_min (allowed limit for him)..
                    // then I start considering the other students.
}

// function to find minimum pages
int findPages(int arr[], int n, int m)
{
    long long sum = 0;

    // return -1 if no. of books is less than
    // no. of students
    if (n < m)
        return -1;

    // Count total number of pages
    for (int i = 0; i < n; i++)
        sum += arr[i];

    // initialize start as 0 pages and end as
    // total pages
    int start = 0, end = sum;
    int result = INT_MAX;

    // traverse while start <= end
    // I consider all range of pages 0-->total no of pages in all books. The idea is, I choose the mid of the range
    // as my solution (the minimum no of pages MStudent can have in order to make him the student with the max no
    // no of pages among other students)
    // if the solution (mid) is possible --> this means MStudent has no of pages that is big enough to make him the
    // student with the maximum no of pages among other students BUT this is not necessarily the minimum solution.
    // so I come again and loop with decreasing my Hight limit of pages into end=mid-1, to push the solution into
    // the lower levels (as in the next loop mid(proposed solution) will be smaller), another way to look at it is
    // any solution>=mid is NOT required to be considered any more.
    // if the solution (mid) is NOT possible --> this means MStudent got a no of pages that is too little which put
    // more burden on the other students. therefore any no of pages that is less than or equal MID needs NOT to be
    // considered, so I shift my low limit up to mid+1.
    // looking at isPossible method, if cur_min is too small I would either
    // get a book with no of pages that is greater than cur_min (which is my proposed solution) and that book
    // will have to go to another student thus negating the condition of MStudent has the max no of pages OR
    // MStudent picked too little of books that other books needed to get distributed to more students than I
    // acutally have. CUR_MIN (MID) defines the MAXIMUM no of pages MStudent can have.
    // I keep looping and looping as I loop my start and end keep shrinking and eventually I will get a MID that is
    // POSSIBLE (it a no of pages that can be DISTRIBUTED among all students with MStudent has the Max) and it is
    // minimum (result=min(result,mid)) among all other previous results. I keep looping until start>end that is
    // when I am done.
    // Notice mid might get sometimes a no of pages that can be distributed among students but it is not an allowed
    // no of pages considering books distribution, this will still return true as Possible but since I keep looping
    // that MID will swing smaller (to get more mimimum) until Mid gets settled as a bare minimum and cannot get
    // any more min than that.
    while (start <= end)
    {
        // check if it is possible to distribute
        // books by using mid is current minimum
        int mid = (start + end) / 2;
        if (isPossible(arr, n, m, mid))
        {
            // if yes then find the minimum distribution
            result = min(result, mid);

            // as we are finding minimum and books
            // are sorted so reduce end = mid -1
            // that means
            end = mid - 1;
        }

        else
            // if not possible means pages should be
            // increased so update start = mid + 1
            start = mid + 1;
    }

    // at-last return minimum no. of  pages
    return result;
}

void driver(){
    //Number of pages in books
    int arr[] = {12, 34, 67, 90};
    int n = sizeof arr / sizeof arr[0];
    int m = 2; //No. of students

    cout << "Minimum number of pages = "
         << findPages(arr, n, m) << endl;

}

#endif // ALLOCATE_MIN_NUMBER_OF_PAGES_H_INCLUDED
