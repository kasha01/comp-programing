#ifndef JUNKYARD_H_INCLUDED
#define JUNKYARD_H_INCLUDED

void test_array_of_pointers(){

    int a = 1; int b=2; int c=3;
    int* ap = &a; int* bp = &b; int* cp = &c;

    int* arr = new int[20]; //array on the heap - new keyword returns a pointer to the head of the array it created on the heap
    arr[0] = 4;
    int arrs[20] = {1,4,6}; //array on the stack

    int** arr_ptr = new int*[3];
    arr_ptr[0] = ap;
    arr_ptr[1] = bp;
    arr_ptr[2] = cp;

    //shallow copy
    int** arrcopy = arr_ptr;

    cout << "Values: " << *(arr_ptr[0]) << " " << *(arrcopy[0]) << endl;
    cout << "Addresses: " << arr_ptr[0] << " " << arrcopy[0] << endl;
    cout << endl;

    a++;

    cout << "After Incrementing a:" << endl;
    cout << *(arr_ptr[0]) << " " << *(arrcopy[0]) << endl;
    cout << arr_ptr[0] << " " << arrcopy[0] << endl;
    cout << endl;

    *(arr_ptr[0]) = 5;

    cout << "After updating a value to 5:" << endl;
    cout << *(arr_ptr[0]) << " " << *(arrcopy[0]) << endl;
    cout << arr_ptr[0] << " " << arrcopy[0] << endl;
    cout << endl;

    //so far so good

    //deleting arr_ptr
    delete[] arr_ptr;

    // Why?: shouldn't arrcopy still be pointing to A.
    cout << "Values: " << *(arr_ptr[0]) << " " << *(arrcopy[0]) << endl; //The result I am expecting here is: unknown_value  5
    cout << "Addresses: " << arr_ptr[0] << " " << arrcopy[0];
    cout << endl;

    //Answer, arr_ptr is actually a pointer to a block of memory, so in memory I have something like:
    // mem_adr: content
    // 0xFEE01: OxABE07 --> OXABE07: OX50A03  -->   OX50A03: 3 (value of A)
    // arr_ptr+1            OXABE08: OX70040        OX70040: 4 (value of B)
    // arr_ptr+2            OXABE09: OXAC03D        OXAC03D: 5 (value of C)

    // arr_ptr is nothing but a location in memory that has a pointer pointing to a block of memory (since we have array of
    // array of pointer, that block of memory also has pointers, each points to a memory location which has my actual data A)
    // so arr_ptr returns the pointer (OxABE07) located at 0xFEE01 memory address.
    // when I say arrcopy = arr_ptr, I am merely copying the pointer arr_ptr, so I will have:
    //                   mem_adr: content
    // (this is arrcopy) 0xDFAA1: OxABE07  -->   OXABE07: OX50A03  -->  OX50A03: 3 (value of A)
    // now arrcopy which is also a pointer pointing at a memory block, is also pointing to the same memory block arr_ptr is
    // pointing to, so when I say delete[] arr_ptr (or delete[] arrcopy),
    // I am actually deleting the memory block both pointers are pointing to, that is why I am getting invalid data
    // remember, array is nothing put a pointer pointing to a memory block
}

#endif // JUNKYARD_H_INCLUDED
