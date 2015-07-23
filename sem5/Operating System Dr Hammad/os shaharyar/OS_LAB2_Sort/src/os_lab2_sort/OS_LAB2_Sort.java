/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package os_lab2_sort;

//import com.sun.org.apache.xml.internal.security.algorithms.Algorithm;

/**
 *
 * @author tucky
 */
public class OS_LAB2_Sort {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        int[] s = {190,180,170,160,150,140,130,120,110,100,90,80,70,60,50,40,30,20,10,1};
        int toInsert,j;
        System.out.print("\nUnsorted Array: ");
        for(int i=0;i<s.length;i++)
        {
            System.out.print(s[i]);
            System.out.print(' ');
        }
        
        long start = System.nanoTime();
        for (int i = 1; i < s.length; i++) 
        {
            if (s[i] < s[i-1]) 
            {
                toInsert = s[i];
                j = i;
                do  
                {
                    s[j] = s[j-1];
                    j = j - 1;
                } while (j > 0 && toInsert < s[j-1]);
                s[j] = toInsert;
            }
        }

        
        long end= System.nanoTime();
        System.out.print("\nSorted Array  : ");
        
        for(int b=0;b<s.length;b++)
        {
            System.out.print(s[b]);
            System.out.print(' ');
        }
        System.out.print("\nString Length : ");
        System.out.print((s.length));
        System.out.print("\nAlgorithm Time: ");
        System.out.print((end-start));
        System.out.println(" nanoseconds");
        
    }
}