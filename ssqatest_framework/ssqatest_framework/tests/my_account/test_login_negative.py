from ssqatest_framework.src.pages.MyAccountSignedOut import Invalid_Registration
import pytest

@pytest.mark.usefixtures("init_driver")  # Will initiate a driver from conftest
class TestLoginNegative:
    @pytest.mark.tcid12
    def test_login_none_existing_user(self):
        my_account = Invalid_Registration(self.driver)
        my_account.go_to_my_account()
        my_account.input_user_name('dddsad')
        my_account.input_user_pass('asdssadad')
        my_account.click_Log_In_Buttong()

        #verify error message
        expected_error = "Error: The username dddsad is not registered on this site. If you are unsure of your username, try your email address instead."
        my_account.wait_until_error_is_displayed(expected_error)
