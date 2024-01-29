import time
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC

def validate_text(driver, strategy, element_locator, validation_text, timeout=10):
    try:
        # Wait for the element to be present
        element = WebDriverWait(driver, timeout).until(
            EC.presence_of_element_located((strategy, element_locator))
        )

        # Get the element text
        actual_text = element.text
        print(f'Actual Text: {actual_text}')

        # Validate the text
        assert actual_text == validation_text, f"Validation failed! Expected: {validation_text}, Actual: {actual_text}"
        return True

    except Exception as e:
        print(f"An error occurred: {e}")
        return False

# Initialize the WebDriver
driver = webdriver.Chrome()

# Navigate to the URL
url = 'https://automationteststore.com/index.php?rt=account/create'
driver.get(url)

# Example usage of the validate_text function
validation_result = validate_text(
    driver=driver,
    strategy=By.CSS_SELECTOR,
    element_locator='div:nth-of-type(1) > fieldset > div:nth-of-type(1) > .col-sm-4.control-label',
    validation_text="First Name:"
)

print(validation_result)

# Adding a small delay for demonstration purposes (consider using WebDriverWait instead)
time.sleep(2)

# Close the browser window
driver.quit()
