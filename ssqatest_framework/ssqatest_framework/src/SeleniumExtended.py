from selenium.webdriver.support.wait import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
import logging as logger


class SeleniumExtended:
    def __init__(self, driver):
        self.driver = driver
        self.default_timeout = 10  # we can change it when calling the method
        logger.info("Driver Created")

    # creating a function that will handle the Explicit waits for all POM methods
    def wait_and_input_text(self, locator, text,
                            timeout=None):  # when using none, we can call the function without specify the parameter
        timeout = timeout if timeout else self.default_timeout  # Check if timeout is given once we call the method
        WebDriverWait(self.driver, timeout).until(EC.visibility_of_element_located(locator)).send_keys(text)

    def wait_and_click(self, locator, timeout=None):
        timeout = timeout if timeout else self.default_timeout
        WebDriverWait(self.driver, 10).until(EC.visibility_of_element_located(locator)).click()

    def wait_until_element_contains_text(self, locator, text, timeout=None):
        timeout = timeout if timeout else self.default_timeout
        WebDriverWait(self.driver, 10).until(EC.text_to_be_present_in_element(locator, text))

    def wait_until_LogOut_is_visible(self, locator, timeout=None):
        timeout = timeout if timeout else self.default_timeout
        WebDriverWait(self.driver, 10).until(EC.visibility_of_element_located(locator))
