\ Color Constants for Raylib 3

require raylib3.fs


: >Color ( r g b a -- Color )
    Color allocate throw { col }
    col Color-a c!
    col Color-b c!
    col Color-g c!
    col Color-r c! col ;

200 200 200 255 >Color Constant LIGHTGRAY
130 130 130 255 >Color Constant GRAY
80 80 80 255	>Color Constant DARKGRAY
253 249 0 255	>Color Constant YELLOW
255 203 0 255	>Color Constant GOLD
255 161 0 255	>Color Constant ORANGE
255 109 194 255 >Color Constant PINK
230 41 55 255	>Color Constant RED
190 33 55 255	>Color Constant MAROON
0 228 48 255	>Color Constant GREEN
0 158 47 255	>Color Constant LIME
0 117 44 255	>Color Constant DARKGREEN
102 191 241 255 >Color Constant SKYBLUE
0 121 241 255	>Color Constant BLUE
0 82 172 255	>Color Constant DARKBLUE
200 122 255 255 >Color Constant PURPLE
135 60 190 255	>Color Constant VIOLET
112 31 126 255	>Color Constant DARKPURPLE
211 176 131 255 >Color Constant BEIGE
127 106 79 255	>Color Constant BROWN
76 63 47 255	>Color Constant DARKBROWN
255 255 255 255 >Color Constant WHITE
0 0 0 255	>Color Constant BLACK
0 0 0 0		>Color Constant BLANK
255 0 255 255	>Color Constant MAGENTA
245 245 245 255 >Color Constant RAYWHITE
