from selenium.webdriver.common.by import By
from ssqatest_framework.src.SeleniumExtended import SeleniumExtended
class HeaderLocators:
    CART_RIGHT_HEADER = (By.ID, 'site-header-cart')
    CART_ITEM_COUNT = (By.CSS_SELECTOR, 'ul#site-header-cart span.count')
    MENU_ITEMS = (By.CSS_SELECTOR, 'div.menu ul.nav-menu li')


