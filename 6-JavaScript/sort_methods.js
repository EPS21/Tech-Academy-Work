
function reverseString(stringName) {
	var newString = "";

	for (var i = stringName.length - 1; i >=0; i--) {
		newString += stringName[i];

	}
	return newString;
}

console.log(reverseString("asuna"));

// insertion sort
var nums = [9,7,6,7,1,2,3,];
var response = "69"
nums.push(parseInt(response));
nums.push(4,5,999);
console.log(nums);
nums.splice(3, 0, 70, 80); //(what index, how many to remove (or 0), number to add, number to add etc)
console.log(nums);

for (var i = 0; i < nums.length - 1; i++) {
	for (var j = i + 1; j > 0; j--) {
		if (nums[j - 1] > nums[j]) {
			var temp = nums[j - 1];
			nums[j - 1] = nums[j];
			nums[j] = temp;
		}
	}
}
console.log(nums);

