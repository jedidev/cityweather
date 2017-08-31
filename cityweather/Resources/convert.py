import json
import sqlite3

JSON_FILE = "city.list.json"
DB_FILE = "cities.sqlite"

cities = json.load(open(JSON_FILE))
conn = sqlite3.connect(DB_FILE)

c = conn.cursor()

c.execute('create table cities (id, name, country)')

for city in cities:
	data = [city["id"], city["name"], city["country"]]
	c.execute('insert into cities values (?,?,?)', data)

conn.commit()
c.close()
