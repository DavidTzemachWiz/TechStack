import time
from telnetlib import EC
from selenium import webdriver
from selenium.common.exceptions import StaleElementReferenceException
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import Select, WebDriverWait
from selenium.webdriver.support import expected_conditions as EC


class Component_TextFields:

# Initialize the WebDriver
    driver = webdriver.Chrome()

# Navigate to the URL
url = 'https://automationteststore.com/index.php?rt=account/create'
driver.get(url)

def submit_text(driver, strategy, element_locator, text, timeout=10):
    try:
        # Wait for the element to be present
        element = WebDriverWait(driver, timeout).until(
            EC.presence_of_element_located((strategy, element_locator))
        )

        # Wait for the element to be clickable
        WebDriverWait(driver, timeout).until(
            EC.element_to_be_clickable((strategy, element_locator))
        )

        # Clear the existing text (optional, remove if not needed)
        element.clear()

        # Send the keys to the element
        element.send_keys(text)

    except Exception as e:
        print(f"An error occurred: {e}")

submit_text(driver=driver,strategy=By.ID,element_locator='AccountFrm_firstname',text= "TEST")
time.sleep(2)