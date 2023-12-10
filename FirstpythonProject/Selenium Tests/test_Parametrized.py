import time
from selenium import webdriver
from selenium.webdriver.common.by import By
import pytest


class TestPositiveScenario:

    @pytest.mark.positive
    @pytest.mark.parametrize(
        "input_username, input_password, input_expected_error_message",
        [("incorrectUser", "Password123 ", "Your username is invalid!"),
         ("incorrectUser_2", "Password123 ", "Your username is invalid!")])
    def test_negative_login(self, driver, input_username, input_password, input_expected_error_message):
        driver.get("https://practicetestautomation.com/practice-test-login/")
        username = driver.find_element(by=By.ID, value="username")
        username.send_keys(input_username)
        password = driver.find_element(by=By.ID, value="password")
        password.send_keys(input_password)
        driver.find_element(by=By.ID, value="submit").click()
        time.sleep(5)  # Sleep for 3 second
        Error = driver.find_element(by=By.ID, value="error")
        # Validate Error is displayed
        assert Error.is_displayed()
        # Verify URL with assertion
        assert Error.text == input_expected_error_message
