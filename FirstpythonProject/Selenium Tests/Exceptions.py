import pytest
from selenium import webdriver

# In this section we will review the most common Test Exceptions
# https://practicetestautomation.com/practice-test-exceptions/

# Test case 1: NoSuchElementException
import time
from selenium import webdriver
from selenium.common import NoSuchElementException, StaleElementReferenceException
from selenium.webdriver.common.by import By
import pytest
from selenium.webdriver.support import expected_conditions as ec, expected_conditions
from selenium.webdriver.support.wait import WebDriverWait
from webdriver_manager.core import driver


class TestErrorsScenarios:
    @pytest.mark.exceptiontests
    def test_no_such_element_exception(self, driver):
        driver.get("https://practicetestautomation.com/practice-test-exceptions/")
        add_button = driver.find_element(by=By.ID, value="add_btn")
        add_button.click()

        # Explicit Wait condition
        wait = WebDriverWait(driver, timeout=2)
        raw_2 = wait.until(ec.presence_of_element_located((By.XPATH, "//div[@id='row2']//input[@type='text']")))
        assert raw_2.is_displayed()

    # Testcase2:test_element_not_interactable_exception

    @pytest.mark.exceptiontests
    def test_element_not_interact_exception(self, driver):
        driver.get("https://practicetestautomation.com/practice-test-exceptions/")

        # Click Add Button
        add_button = driver.find_element(by=By.ID, value="add_btn")
        add_button.click()

        # Wait for the second raw to load and add text
        wait = WebDriverWait(driver, timeout=10)
        raw_2 = wait.until(ec.presence_of_element_located((By.XPATH, "//div[@id='row2']//input[@type='text']")))
        raw_2.send_keys("Sushi")

        save_button = driver.find_element(By.XPATH, value="(//button[@id='save_btn'])[2]")
        save_button.click()

        # Verify text
        confirmation = driver.find_element(By.ID, "confirmation")
        confirmation_text = confirmation.text

        # Assert with comment
        assert confirmation_text == "Row 2 was saved", "Confirmation is not expected"

    @pytest.mark.exceptiontests
    def test_invalid_element_state_exception(self, driver):
        driver.get("https://practicetestautomation.com/practice-test-exceptions/")

        # Click Edit button
        row_1_edit_button = driver.find_element(By.ID, "edit_btn")
        row_1_edit_button.click()

        # Clear input field
        raw_1_input_element = driver.find_element(By.XPATH, "//div[@id='row1']//input")

        # Wait for the raw to be available
        wait = WebDriverWait(driver, 10)
        wait.until(ec.element_to_be_clickable(raw_1_input_element))
        raw_1_input_element.clear()

        # Type text
        raw_1_input_element.send_keys("pastrama")

        # Verify Text was changed
        text = raw_1_input_element.get_attribute("value")
        assert text == "pastrama", "Expected pastrama but got " + text

    @pytest.mark.exceptiontests
    def test_stale_element_reference_exception(self, driver):
        driver.get("https://practicetestautomation.com/practice-test-exceptions/")

        # Click Add Button
        add_button = driver.find_element(by=By.ID, value="add_btn")
        add_button.click()

        # Verify instruction test element is no longer displayed
        wait = WebDriverWait(driver, 20)
        # This return boolean of IsDisplayed that in this case is true as the element not available
        assert wait.until(ec.invisibility_of_element_located(
            (By.ID, "instructions"))), "Instruction text element should not be displayed"

    @pytest.mark.exceptiontests
    def test_timeout_exception(self, driver):
        driver.get("https://practicetestautomation.com/practice-test-exceptions/")

        # Click Add Button
        add_button = driver.find_element(by=By.ID, value="add_btn")
        add_button.click()

        #wait 3 for the raw to be displayed
        wait = WebDriverWait(driver, timeout=3)
        raw_2 = wait.until(ec.visibility_of_element_located((By.XPATH, "//div[@id='row2']//input[@type='text']")))

        #Verify second raw is displyed
        assert raw_2.is_displayed()
