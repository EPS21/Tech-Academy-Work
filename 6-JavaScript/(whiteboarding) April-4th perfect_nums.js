// Write a program that will output all perfect numbers between 1 and 10000

var x = 20000;


function test(max) {
	var pf = [];
	for (var i = 1; i <= max; i++) 
	{
		var factors = findFactors(i);
		var result = checkFactors(i, factors);
		if (result == true) pf.push(i);
		//console.log(result);
	}
	return pf;
}

console.log(test(x));

function findFactors(pot) {
	var nums = [];
	for (var i = 1; i <= pot / 2; i++) 
	{
		if (pot % i == 0) {
			nums.push(i);
		}
	}
	//console.log(nums);
	return nums;
}

function checkFactors(num, factors) {
	var sumTotal = 0;
	var perfectNumber;
	for (i = 0; i <= factors.length - 1; i++)
	{
		sumTotal += factors[i];
	}
	if (sumTotal == num) {
		perfectNumber = true;
	} else {
		perfectNumber = false;
	}
	return perfectNumber;
}

