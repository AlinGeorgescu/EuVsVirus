from urllib.request import urlopen as uReq
from bs4 import BeautifulSoup as soup

my_url='https://www.olx.ro/anunturi-agricole/alimentatie-produse-bio/legume-fructe/q-rosii/'

uClient = uReq(my_url);
page_html = uClient.read()
uClient.close()

page_soup = soup(page_html, "html.parser")

