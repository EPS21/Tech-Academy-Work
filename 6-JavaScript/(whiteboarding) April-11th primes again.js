function findPrimes (n) {
	var isPrime = true;
	for (var i = 2; i < n; i++)
	{
		for (var j = 2; j < i / 2; j++) 
		{
			if (i % j == 0) 
				isPrime = false;

					
		}
			if (isPrime == true) 		
				console.log(i)		 		

	}
	

	
}

findPrimes(21);