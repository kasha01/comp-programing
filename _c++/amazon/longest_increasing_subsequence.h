#ifndef LONGEST_INCREASING_SUBSEQUENCE_H_INCLUDED
#define LONGEST_INCREASING_SUBSEQUENCE_H_INCLUDED

int compare (const void *a, const void * b)
{
    return ( (*(Box *)b).d * (*(Box *)b).w ) -
           ( (*(Box *)a).d * (*(Box *)a).w );
}


// This is another way.
void getLIS(){
    int t = 0; cin >> t;
    while(t>0){
         t--;
         int n=0; cin >> n;
         int ar[n]; int lic[n];
         for(int i=0;i<n;i++){
             lic[i] = 1;
             cin >> ar[i];
         }

        for(int i=0; i<n;i++){
            for(int j=i+1;j<n;j++){
                if(ar[i] < ar[j]){
                    lic[j] = max(lic[j], lic[i] + 1);
                }
            }
        }

        int mx=0;
        for(int i=0; i<n;i++){
            mx = max(mx,lic[i]);
        }
        cout << mx << endl;
    }
}

// Stacking Boxes
int maxStackHeight( Box arr[], int n )
{
   /* Create an array of all rotations of given boxes
      For example, for a box {1, 2, 3}, we consider three
      instances{{1, 2, 3}, {2, 1, 3}, {3, 1, 2}} */
   Box rot[3*n];
   int index = 0;
   for (int i = 0; i < n; i++)
   {
      // Copy the original box
      rot[index] = arr[i];
      index++;

      // First rotation of box
      rot[index].h = arr[i].w;
      rot[index].d = max(arr[i].h, arr[i].d);
      rot[index].w = min(arr[i].h, arr[i].d);
      index++;

      // Second rotation of box
      rot[index].h = arr[i].d;
      rot[index].d = max(arr[i].h, arr[i].w);
      rot[index].w = min(arr[i].h, arr[i].w);
      index++;
   }

   // Now the number of boxes is 3n
   n = 3*n;

   /* Sort the array 'rot[]' in decreasing order, using library
      function for quick sort */
   qsort (rot, n, sizeof(rot[0]), compare);

   // Uncomment following two lines to print all rotations
   // for (int i = 0; i < n; i++ )
   //    printf("%d x %d x %d\n", rot[i].h, rot[i].w, rot[i].d);

   /* Initialize msh values for all indexes
      msh[i] --> Maximum possible Stack Height with box i on top */
   int msh[n];
   for (int i = 0; i < n; i++ )
      msh[i] = rot[i].h;

   /* Compute optimized msh values in bottom up manner */
   for (int i = 1; i < n; i++ )
      for (int j = 0; j < i; j++ )
         if ( rot[i].w < rot[j].w &&
              rot[i].d < rot[j].d &&
              msh[i] < msh[j] + rot[i].h
            )
         {
              msh[i] = msh[j] + rot[i].h;
         }


   /* Pick maximum of all msh values */
   int max = -1;
   for ( int i = 0; i < n; i++ )
      if ( max < msh[i] )
         max = msh[i];

   return max;
}
#endif // LONGEST_INCREASING_SUBSEQUENCE_H_INCLUDED
