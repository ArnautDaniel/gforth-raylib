# gforth-raylib

### 4.5 Bindings in Progress using the new parser.

Yeah I'm gonna try eventually to update these...3.5 is still really good for gforth.

Raylib 3.5 bindings for Gforth.  
![gforth-raylib logo](https://github.com/ArnautDaniel/gforth-raylib/raw/master/logo.png "Gforth-Raylib Logo")

Simply `include raylib3.fs` and you're good to go.

You will need to install raylib.  Some distributions include a package but it'll be easiest to just use this process.
Because of further dev branch updates I have yet to add, I would not recommend the process below right now.  Download the Raylib 3.5 release zip and you should be good. 

```
git clone https://github.com/raysan5/raylib
cd raylib/src
make PLATFORM=PLATFORM_DESKTOP RAYLIB_LIBTYPE=SHARED
sudo make install RAYLIB_LIBTYPE=SHARED
```


Check https://github.com/raysan5/raylib/wiki/Working-on-GNU-Linux for more details.

# projects

BearBit:  An overlay for Gforth-Raylib that gives a simple fantasy console for making old 8-bit esque style games.
