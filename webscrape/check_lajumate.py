import requests
import os.path
from bs4 import BeautifulSoup as soup


class Product:
    def __init__(self, name, price, location, img, link):
        self.name = name
        self.price = price
        self.location = location
        self.img = img
        self.link = link
    def __str__(self):
        return "name : " + self.name + "\n" + "price : " + str(self.price) + "\n" + "location : " + str(self.location) + "\n" + "img : " + str(self.img) + "\n" + "link : " + str(self.link) + "\n"

products = []
url = "https://lajumate.ro/anunturi_produse-alimentare.html"

try:
    page_html = requests.get(url)
    page_soup = soup(page_html.text, "html.parser")
    containers = page_soup.findAll("a",{"class":["main_items item_cart",
                                        "main_items item_cart first_item_cart",
                                        "main_items item_cart no_right",
                                        "main_items item_cart  ",
                                        "main_items item_cart first_item_cart  ",
                                        "main_items item_cart no_right  "]})
except TypeError:
    print("Not possible" + url)
except:
    pass

print(len(containers))

for contain in containers:
    try:
        name = contain.find("span",{"class":"title"}).text
        img = contain.img["src"]
        print(img)
        # link = items[1].div.h3.a["href"]
        # price = items[2].div.p.strong.text
        # location = items[3].div.p.small.span.text
        # product = Product(name,price,location,img,link)
        # products.append(product)
    except TypeError:
        print("Not possible")
    except:
        pass

for product in products:
    print(product)
