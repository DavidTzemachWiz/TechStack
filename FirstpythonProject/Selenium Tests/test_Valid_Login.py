import pytest

from POM.LoggedInSuccessfuly import LoggedInSuccessfullyPage
from POM.LoginPage import LoginPage


class TestPositiveScenario:

    @pytest.mark.positive
    def test_valid_login(self, driver):
        # Step 1: initialize Log-In class instance
        Login_page = LoginPage(driver)

        # Step 2: Open A web page
        Login_page.open()

        # Step 3: Add credentials and Submit
        Login_page.execute_login("student", "Password123")

        # Verify URL with assertion
        logged_in_page = LoggedInSuccessfullyPage(driver)
        assert logged_in_page.expected_url == logged_in_page.current_url, "Actual URL is not the same as expected"
        assert logged_in_page.header == "Logged In Successfully", "Header is not expected"
        assert logged_in_page.is_logout_button_displayed(), "Logout button should be visible"
