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
url = "https://www.okazii.ro/alimente/"

try:
	page_html = requests.get(url)
	page_soup = soup(page_html.text, "html.parser")
	containers = page_soup.findAll("div",{"class":"carousel-item"})
except TypeError:
	print("Not possible" + url)
except:
	pass

for contain in containers:
	try:
		name = contain.a.div.span.text
		img = contain.a.figure.img["data-lazy"]
		link = contain.a["href"]
		price = contain.find("div",{"class":"item-price"}).text.lstrip()
		# location = contain.div.p.small.span.text
		location = ''
		product = Product(name,price,location,img,link)
		products.append(product)
	except TypeError:
		print("Not possible")
	except:
		pass

for product in products:
	print(product)
