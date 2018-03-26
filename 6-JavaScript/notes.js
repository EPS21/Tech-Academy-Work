/*js notes*/

num1 = 1;
num2 = 2;
numberArray = [2,3,"c",7,11,4];
numberArray[2] = "f";
numberArray.push("x");

for (var i = 0; i < numberArray.length; i++) {
	console.log(numberArray[i]);
	
}
var num = 6;
result = (num >= 4);
//console.log(result);

function myFunction() {	
	console.log(typeof result);

}
myFunction();

var str = "Hello World!";
var result = str.fontcolor("green");
console.log(result);