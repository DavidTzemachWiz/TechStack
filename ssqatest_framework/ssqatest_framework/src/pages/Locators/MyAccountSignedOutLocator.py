from selenium.webdriver.common.by import By


class MyAccountSignedOutLocators:
    LOGIN_USER_NAME = (By.ID, 'username')
    LOGIN_PASSWORD = (By.ID, 'password')
    LOGIN_BTN = (By.CSS_SELECTOR, 'button[value="Log in"]')
    FIND_ELEMENT_ERROR_FOR_INVALID_REGISTRATION = (By.CSS_SELECTOR, 'ul.woocommerce-error')
