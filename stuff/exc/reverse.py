def reverse(arr):
	if len(arr) == 1:
		return arr
	
	temp = arr[0]
	arr[0] = arr[len(arr)-1]
	arr[len(arr)-1] = temp
	return reverse(arr[:-1][:1])
	
a = [10, 23, 98, 2, 12, 38, 65]
print(reverse(a))