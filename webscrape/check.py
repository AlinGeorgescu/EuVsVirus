import requests
from bs4 import BeautifulSoup as soup

url = 'https://www.olx.ro/anunturi-agricole/alimentatie-produse-bio/legume-fructe/q-rosii/'
page_html = requests.get(url)
#print(page_html.text)

page_soup = soup(page_html.text, "html.parser")

#print(page_soup.body)

containers = page_soup.findAll("tr",{"class":"wrap"})

print(containers)
