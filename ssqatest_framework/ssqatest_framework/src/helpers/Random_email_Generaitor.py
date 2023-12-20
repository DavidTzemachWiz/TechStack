import random
import string

def generate_email():
    username = ''.join(random.choice(string.ascii_lowercase) for _ in range(8))
    domain = ''.join(random.choice(string.ascii_lowercase) for _ in range(6))
    extension = random.choice(['com', 'net', 'org'])
    email = f"{username}@{domain}.{extension}"
    return email

