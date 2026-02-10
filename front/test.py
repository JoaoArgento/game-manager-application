def res(n):
    result = [0] * (n + 1)

    result[0] = 0
    result[1] = 1

    for i in range(2, n + 1):
        result[i] = result[i - 2] + result[i - 1]
        
    return result[n]
    


print(res(10))


def fib(n):
    if n == 0:
        return n
    if n == 1:
        return n
    
    return fib(n - 2) + fib(n - 1) 




