
class calculation:
    def __init__(self):
        print('This is a calculator class')

    #Sum of thwo numbers
    def sum (self, num_1, num_2):
        return  num_1 + num_2

    #method to take two numbers and subtract the second number from the first number and return the diff
    def subtract(num_1, num_2):
        return num_1 - num_2

    #method to take two numbers and return the multiplication of the two
    def subtract(num_1, num_2):
        return num_1 * num_2


calc = calculation()
print(calc.sum(1,1))
