from selenium.webdriver.support.wait import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC


class SeleniumExtended:
    def __init__(self, driver):
        self.driver = driver
        self.default_timeout = 10 # we can change it whem calling the method 

    # creating a function that will handle the Explicit waits for all POM methods
    def wait_and_input_text(self, wait_time, text, locator=None):
        WebDriverWait(self.driver, self.default_timeout).until(EC.visibility_of_element_located(locator)).send_keys(text)
