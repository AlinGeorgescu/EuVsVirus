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

url = 'https://www.olx.ro/anunturi-agricole/alimentatie-produse-bio/legume-fructe/q-rosii/'
page_html = requests.get(url)
#print(page_html.text)

page_soup = soup(page_html.text, "html.parser")

#print(page_soup.body)

containers = page_soup.findAll("div",{"class":"offer-wrapper"})

#print(containers)

contain = containers[0]

for contain in containers:
	items = contain.findAll("td")
	try:
		name = items[0].a.img["alt"]
		img = items[0].a.img["src"]
		link = items[1].div.h3.a["href"]
		price = items[2].div.p.strong.text
		location = items[3].div.p.small.span.text 
		product = Product(name,price,location,img,link)
		products.append(product)
	except TypeError:
		print("Not possible")
	except:
		pass

for product in products:
	print(product)
