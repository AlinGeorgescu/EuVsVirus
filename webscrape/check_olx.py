import requests
from bs4 import BeautifulSoup as soup


filename = "products.csv"
f = open(filename, "w")

headers = "Name, Price, Location, Image, Link\n"

f.write(headers)

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
urls = []

fruits = ['capsuni', 'capsune', 'cirese', 'mere', 'pere', 'gutui', 'prune', 'nuci', 'struguri',
			'caise', 'pepene', 'zmeura', 'mure', 'afine', 'piersici', 'nectarine', 'visine',
			'catina']
vegetables = ['cartofi', 'ardei', 'gulie', 'conopida', 'brocoli', 'rosii', 'ciuperci', 'telina',
			'vinete', 'salata', 'morcov', 'fasole', 'usturoi', 'ceapa', 'mazare', 'castravete',
			'ridiche', 'varza', 'pastarnac', 'patrunjel', 'marar', 'leustean', 'loboda', 'urzici',
			'stevie', 'sfecla', 'dovleac']
pages = ['?page=1', '?page=2', '?page=3']

for vegetable in vegetables:
	for page in pages:
		url = 'https://www.olx.ro/anunturi-agricole/alimentatie-produse-bio/legume-fructe/q-' + str(vegetable) + '/' + str(page)
		urls.append(url)

for fruit in fruits:
	for page in pages:
		url = 'https://www.olx.ro/anunturi-agricole/alimentatie-produse-bio/legume-fructe/q-' + str(fruit) + '/' + str(page)
		urls.append(url)

for url in urls:
	try:
		page_html = requests.get(url)
		page_soup = soup(page_html.text, "html.parser")
		containers = page_soup.findAll("div",{"class":"offer-wrapper"})
	except TypeError:
		print("Not possible" + url)
	except:
		pass

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
		f.write(product.name.replace(",","|") + "," + str(product.price).replace(",","|") + "," + product.location.replace(",","|") + "," + product.img.replace(",","|") + "," + product.link.replace(",","|") + "\n")

