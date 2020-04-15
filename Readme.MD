# Olx Notifier

## what
A scraper of the marketplace OLX that uses a Telegram Bot to notify you of new 
advertisements.

## why
I was looking for a Nintendo Switch but the prices skyrocketed after the 
coronavirus event. And I just want to play Animal Crossing. Tired of pressing 
F5 all day, I decided it was time to experiment with scrapers and Telegram bots.

## who
I just a cheap Switch.

## how
The project is based on hexagonal architecture but it may be flawed and I'm 
happy to make changes if you find something to improve. The entrypoints folder 
has a pretty obvious name and it's where the bot is. Together with the bot I'm
puttings some important endpoints of Telegram Bots API to easily call from a 
Swagger page.

I had to make a middleware just to handle the webhook from the API because 
Telegram doesn't use any kind of authentication. This way I can hide the route 
from the repository inside a configs file. If you plan to host yourself you 
need a way to set the properties from TelegramApiConfiguration class.

There's also a console entrypoint to return the entries but it's just for test 
purposes.

The scraper project does the hard work and has retry capabilities by using 
Polly.

## small blog
Taking advantage of git I can use this file to write and overwrite small 
annotations without ever losing content! So here we go:

- The next step is going to be to remove duplicates from the notifications and 
also send the product link. Without this the notification is pretty much 
useless because you have to keep the page open to check for more info. That's 
it!