/*********************************************
 Finding minimum and maximum values with and
 without the helper methods within an array
 *********************************************/

 // Finding it manually (without helper methods)
var nums = [1,2,5,4,-2]
var largestNumber = 0;
var smallestNumber = 0;

for (var i = 0; i < nums.length; i++) {

	// finding largest number
	if (nums[i] > nums[largestNumber]) {
		largestNumber = i;
	}

	// finding smallest number
	if (nums[i] < nums[smallestNumber]) {
		smallestNumber = i;
	}
}

console.log("Sorting through " + nums.toString() + " manually.")
console.log("The largest value in this array is " + nums[largestNumber])
console.log("The smallest value in this array is " + nums[smallestNumber] + "\n")

// Finding it with Max() and Min() methods
var nums2 = [3,4,5,9,-8]
console.log("Sorting through " + nums2.toString() + " using built it Max and Min methods")

 // Don't even need a loop technically
for (var i = 0; i < nums2.length; i++) {
	
	// finding largest number
	if (nums2[i] == Math.max(...nums2)) {
		console.log("The largest value in this array is " + Math.max(...nums2))
	}

	// finding smallest number
	if (nums2[i] == Math.min(...nums2)) {
		console.log("The smallest value in this array is " + Math.min(...nums2))
	}
}

// Just use this instead to print directly
//console.log("The largest value in this array is " + Math.max(...nums2))
//console.log("The smallest value in this array is " + Math.min(...nums2) + "\n")



