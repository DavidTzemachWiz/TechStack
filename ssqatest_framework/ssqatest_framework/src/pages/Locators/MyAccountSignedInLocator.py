from selenium.webdriver.common.by import By


class MyAccountSignedInLocators:
    Email_ADRESS = (By.ID, 'reg_email')
    REG_PASSWORD = (By.ID, 'reg_password')
    REGISTER_BTN = (By.CSS_SELECTOR, "button[value='Register']")
    FIND_ELEMENT_LOG_OUT_VALID_REGISTRATION = (By.LINK_TEXT, 'Log out')
