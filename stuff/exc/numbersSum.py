def findSum(num1, num2):
	if num1 == num2:
		return 0
	
	if num1<num2:
		return num1 + findSum(num1+1, num2)
	else:
		return num2 + findSum(num1, num2+1)
	
print(findSum(10, 11))