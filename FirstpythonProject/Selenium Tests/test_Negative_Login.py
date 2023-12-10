import time
import pytest
from selenium import webdriver
from selenium.webdriver.common.by import By


# Creating fixture

class TestNegativeScenario:
    def test_negative_login(self, driver):
        driver.get("https://practicetestautomation.com/practice-test-login/")
        username = driver.find_element(by=By.ID, value="username")
        username.send_keys("incorrectUser")
        password = driver.find_element(by=By.ID, value="password")
        password.send_keys("Password123 ")
        driver.find_element(by=By.ID, value="submit").click()
        time.sleep(5)  # Sleep for 3 second
        Error = driver.find_element(by=By.ID, value="error")
        # Validate Error is displayed
        assert Error.is_displayed()
        # Verify URL with assertion
        assert Error.text == "Your username is invalid!"

    def test_negative_scenario_2(self, driver):
        driver.get("https://practicetestautomation.com/practice-test-login/")
        username = driver.find_element(by=By.ID, value="username")
        username.send_keys("student")
        password = driver.find_element(by=By.ID, value="password")
        password.send_keys("IncorrectPassword ")
        driver.find_element(by=By.ID, value="submit").click()
        Error_2 = driver.find_element(by=By.ID, value="error")
        assert Error_2.text == "Your password is invalid!"
