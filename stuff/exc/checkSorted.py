def check_sorted(array, i, end):
	if i >= end-1:
		return True
	
	if array[i] < array[i+1]:
		check_sorted(array, i+1, end)
	else:
		return False
		
a = [10, 11, 12, 13, 14, 15, 112, 5124, 16135]

print(check_sorted(a, 0, 5))