using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sorting
{
    public partial class WebForm1 : System.Web.UI.Page
    {        

        protected void Page_Load(object sender, EventArgs e)
        {
        }     

        protected void mergeSortBtn_Click(object sender, EventArgs ee)
        {
            // initialize and reset the string
            resultLabel.Text = "";

            // initializing the values from the boxes as ints
            int a = int.Parse(TextBox1.Text);
            int b = int.Parse(TextBox2.Text);
            int c = int.Parse(TextBox3.Text);
            int d = int.Parse(TextBox4.Text);
            int e = int.Parse(TextBox5.Text);
            int f = int.Parse(TextBox6.Text);
            int g = int.Parse(TextBox7.Text);
            int h = int.Parse(TextBox8.Text);
            int i = int.Parse(TextBox9.Text);
            int j = int.Parse(TextBox10.Text);

            // putting them into the initial array
            int[] numArray = new int[10] { a, b, c, d, e, f, g, h, i, j };
            //int len = 10;

            // beginning mergesort procedure
            MergeSort_Recursive(numArray, 0, numArray.Length - 1);
            //mergeSort(numArray);
            
            // Built-in sorting method
            //Array.Sort(numArray);

            // displaying end result of the numArray
            foreach (var item in numArray)
            {
                resultLabel.Text += item.ToString() + " ";
            }

            
        }

        private void DoMerge(int[] numbers, int left, int mid, int right)
        {            
            int[] temp = new int[numbers.Length];
            // initializes temporary variables
            int left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid]) // check if first part came to an end
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];

            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];

            // setting elements from temp array into numbers array
            for (int i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
            //throw new NotImplementedException();
        }

        private void MergeSort_Recursive(int[] numbers, int left, int right)
        {
            int mid;

            if (right > left)
            {
                // defines the current array in 2 parts
                mid = (right + left) / 2;

                // sort the 1st part of array
                MergeSort_Recursive(numbers, left, mid);

                // sort the 2nd part of array
                MergeSort_Recursive(numbers, (mid + 1), right);

                // merge both parts by comparing elements of both the parts
                DoMerge(numbers, left, (mid + 1), right);
            }
        }

        /* The other videos solution but missing final part of adding back to original array
        private void mergeSort(int[] array)
        {
            // recursive method
            mergeSort(array, new int[array.Length], 0, array.Length - 1);

        }

        private void mergeSort(int[] array, int[] temp, int leftStart, int rightEnd)
        {
            if (leftStart >= rightEnd)
            {
                return;
            }
            int middle = (leftStart + rightEnd) / 2;
            mergeSort(array, temp, leftStart, middle);
            mergeSort(array, temp, middle + 1, rightEnd);
            mergeHalves(array, temp, leftStart, rightEnd);
        }

        private int[] mergeHalves(int[] array, int[] temp, int leftStart, int rightEnd)
        {
            int leftEnd = (rightEnd + leftStart) / 2;
            int rightStart = leftEnd + 1;
            int size = rightEnd - leftStart + 1;

            int left = leftStart;
            int right = rightStart;
            int index = leftStart;

            while (left <= leftEnd && right <= rightEnd)
            {
                if (array[left] <= array[right])
                {
                    temp[index] = array[left];
                    left++; // move left pointer
                }
                else
                {
                    temp[index] = array[right];
                    right++; // move right pointer
                }
                index++;
            }

            return temp;
            
        }
        */

    }
}