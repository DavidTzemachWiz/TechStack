import time

from ssqatest_framework.src.pages.MyAccountSignedOut import Invalid_Registration
from ssqatest_framework.src.helpers.Random_email_Generaitor import generate_email
import pytest

@pytest.mark.usefixtures("init_driver")  # Will initiate a driver from conftest
class TestRegistarNewUser():
    @pytest.mark.tcid13
    def test_register_valid_new_user(self):

        #Go to my account
        my_account = Invalid_Registration(self.driver)
        my_account.go_to_my_account()

        #add Email and password  DaviP@ssw0r
        my_account.input_register_email(generate_email())
        my_account.input_register_pass('DaviP@ssw0r')
        #Click Register
        my_account.click_register_Buttong()

        #Verify user is verified
        my_account.verify_user_is_signed_in()

