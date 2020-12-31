# gforth-raylib
Raylib 3.5 bindings for Gforth.  
![gforth-raylib logo](https://github.com/ArnautDaniel/gforth-raylib/raw/master/logo.png "Gforth-Raylib Logo")

Simply `include raylib3.fs` and you're good to go.

You will need to install raylib.  Some distributions include a package but it'll be easiest to just use this process.

```
git clone https://github.com/raysan5/raylib
cd raylib/src
make PLATFORM=PLATFORM_DESKTOP RAYLIB_LIBTYPE=SHARED
sudo make install RAYLIB_LIBTYPE=SHARED
```

Check https://github.com/raysan5/raylib/wiki/Working-on-GNU-Linux for more details.

