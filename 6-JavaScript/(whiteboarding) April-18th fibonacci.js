// write a program to output the fibonacci sequence
// between 1 and a num entered by the user

function findFibSequence(num) 
{
	var nums = [];	
	if (num == 0) {
		nums = [0];
	}
	else if (num == 1) {
		nums = [0,1,1];
	} 
	else {
		nums = [0,1]
		var num1 = 1;
		var num2 = 2;
		nums.push(num1);
		nums.push(num2);

		var result;
		for (var i = 2; i < num; i++) {
			result = num1 + num2

			// Don't want to display number higher than user inputted
			if (result <= num) {
				nums.push(result);
			}			
			num1 = num2;
			num2 = result;
		}
	}
	return nums;
}

console.log(findFibSequence(9));