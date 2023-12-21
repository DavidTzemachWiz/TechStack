import time

import pytest
from ssqatest_framework.src.pages.HomePage import HomePage
from ssqatest_framework.src.pages.Locators.HomePage_Locators import Homepagelocators
from ssqatest_framework.src.pages.Header import Header
from ssqatest_framework.src.pages.CartPage import CartPage
from ssqatest_framework.src.pages.CheckoutPage import CheckoutPage
from ssqatest_framework.src.config.GenericConfigs import GenericConfigs

@pytest.mark.usefixtures('init_driver')
class TestEndToEndCheckoutGuestUser:
    @pytest.mark.e2e
    def test_e2e_checkout_guest_user(self):
        #Create class objects
        home_page = HomePage(self.driver)
        header = Header(self.driver)
        cart_p = CartPage(self.driver)
        checkout_p = CheckoutPage(self.driver)

        # go to home page
        home_page.go_to_home_page()

        # add one item to cart
        home_page.click_first_add_to_cart_button()

        #Make sure the cart is updated before going to cart
        header.wait_until_cart_item_count(1)

        # go to cart
        header.click_on_cart_on_right_header()

        #Validate Cart contain the correct item
        product_names = cart_p.get_all_product_names_in_cart()
        assert len(product_names) == 1, f"Expected 1 item in cart but found {len(product_names)}"

        # apply free coupon
        coupon_code = GenericConfigs.FREE_COUPON
        cart_p.apply_coupon(coupon_code)

        time.sleep(5)
        # click on checkout
        cart_p.click_on_proceed_to_checkout()






