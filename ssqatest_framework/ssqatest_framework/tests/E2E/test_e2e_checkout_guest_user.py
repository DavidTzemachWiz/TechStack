import time

import pytest
from ssqatest_framework.src.pages.HomePage import HomePage
from ssqatest_framework.src.pages.Locators.HomePage_Locators import Homepagelocators

@pytest.mark.usefixtures('init_driver')
class TestEndToEndCheckoutGuestUser:
    @pytest.mark.e2e
    def test_e2e_checkout_guest_user(self):
        home_page = HomePage(self.driver)
        # go to home page
        home_page.go_to_home_page()

        # add one item to cart
        home_page.click_first_add_to_cart_button()
        time.sleep(3)

        # go to cart

        # Apply a coupon ssqa100

        # change to Free Shipping

        #Click on checkout

        #fill in form

        #Click on place order

        #Verify order confirmation
        pass

        # Verify order is recorded in DB (Beckend and Frontend automation!)