# Stryfe RPG

## What is it?
This is a study project I started since I'm stuck at home because of a disease I'm treating. I always wanted to start developing a game but didn't have the time. Now I do. :)

## Which frameworks/libraries do you use?
I'm using **Monogame/XNA** for the game engine, an adapted version of **TiledSharp** (https://github.com/marshallward/TiledSharp) for map reading and **JSON.Net** (http://www.newtonsoft.com/json) for JSON operations. I'm not using any database for now, so everything is pure JSON for ease. I've been also taking a look at MonoGame.Extended (https://github.com/craftworkgames/MonoGame.Extended), as I may use some of it's stuff

## I want to build it and run!
Well, first you need Visual Studio (at least I do). I'm sure you can build it in another IDE or Sublime or Notepad or whatever, but gosh, Visual Studio Community is right there. Then:

1. Install Monogame (http://www.monogame.net/)
2. Build the TiledSharp project (in this repository)
3. Put the dll inside a "lib" folder in the project's root (not the solution's) - i.e: StryfeRPG/StryfeRPG/lib/TiledSharp.dll
4. Install JSON.Net via NuGet if needed (http://www.newtonsoft.com/json if you need help);
5. Install MonoGame.Extended via NuGet (https://github.com/craftworkgames/MonoGame.Extended)
5. Build and run!

I hope that's all it takes for you to run it!

## Are these RPG Maker sprites?
Yes, I'm not an artist and I needed something to test with.
