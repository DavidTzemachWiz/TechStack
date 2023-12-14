
products = [
    {'id': 1, 'name': 't-shirt', 'price': 12.99, 'created_date': '2022-01-01', 'is_on_sale': False, 'sale_price': None},
    {'id': 2, 'name': 'shoes', 'price': 22.45, 'created_date': '2022-01-01', 'is_on_sale': True, 'sale_price': None},
    {'id': 3, 'name': 'dress-shirt', 'price': 43.00, 'created_date': '2022-01-01', 'is_on_sale': False, 'sale_price': None},
    {'id': 4, 'name': 'socks', 'price': 14.99, 'created_date': '2022-01-01', 'is_on_sale': True, 'sale_price': 7.99},
    {'id': 5, 'name': 'trousers', 'price': 32.50, 'created_date': '2022-01-01', 'is_on_sale': True, 'sale_price': None},
    {'id': 6, 'name': 'jacket', 'price': 150.00, 'created_date': '2022-01-01', 'is_on_sale': False, 'sale_price': None},
]
# List of problematic products:
Defected_products = []
count = 0
for product in products:
    if (products[count]['is_on_sale'] == True and products[count]['sale_price'] == None) :
        #print(f"The product price is {float(products[count]['price'])} and the name is {products[count]['name']}")
       #print(products[count]['is_on_sale'])
        Defected_products.append(products[count])
    count = count+1

for X in Defected_products:
    print(X)
