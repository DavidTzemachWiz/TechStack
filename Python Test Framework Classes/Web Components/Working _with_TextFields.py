import time
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import Select
from selenium.common.exceptions import StaleElementReferenceException


class Component_DropDown:

# Initialize the WebDriver
    driver = webdriver.Chrome()

# Navigate to the URL
    url = 'https://automationteststore.com/index.php?rt=account/create'
    driver.get(url)
    
    
    