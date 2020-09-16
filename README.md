# gforth-raylib
Raylib 3.0 bindings for Gforth.  
![gforth-raylib logo](https://github.com/ArnautDaniel/gforth-raylib/raw/master/logo.png "Gforth-Raylib Logo")

More (and better) examples coming soon. (Update: Working on it.  Got hit in the head and had to take a day or two.)

Simply `include raylib3.fs` and you're good to go.

You will need to install raylib.  Some distributions include a package but it'll be easiest to just use this process.

```
git clone https://github.com/raysan5/raylib
cd raylib/src
make PLATFORM=PLATFORM_DESKTOP RAYLIB_LIBTYPE=SHARED
sudo make install RAYLIB_LIBTYPE=SHARED
```

Check https://github.com/raysan5/raylib/wiki/Working-on-GNU-Linux for more details.

# Todo

Add more examples.

Implement a minimal interface and more helper words to eliminate the boilerplate.

Eventually write a small book or some tutorials to help introduce people to Forth.  I'm of the mind that graphical examples invoke a greater response in beginners compared to just messing with the terminal. (Although the terminal is cool!)
