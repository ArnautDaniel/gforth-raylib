require raylib3.fs


\ Example helpers for moving data from the stack to structures
\ or back.  Will add more as I need them.

: Vector2> ( Vector2 -- f: -- x y )
    dup dup sf@ Vector2-y sf@
    free throw ;

: >Vector2 ( f: -- x y -- Vector2 )
    Vector2 allocate throw
    dup dup sf! Vector2-y sf! ;

: >Vector3 ( f: -- x y z -- Vector3 )
    Vector3 allocate throw { Vec3 }
    Vec3 Vector3-z sf!
    Vec3 Vector3-y sf!
    Vec3 sf! Vec3 ;

: Vector3> ( Vector3 -- f: -- x y z )
    { Vec3 }
    Vec3 sf@
    Vec3 Vector3-y sf@
    Vec3 Vector3-z sf@ ;

\ -----------------------------------------------------------

\ raycall will allocate a structure of the type it is sent
\ and sends this empty structure along with the function call
\ the function will "fill up" the structure and return a pointer
\ instead of the structure as it does in the original raylib.
\ This is because Gforth can't return structures.

\ Notice I do NOT call free at any point in these.
\ You have to handle the memory management on the Forth side
\ with this method.  (Which is fine because you have the addr
\ to free.)

\ This is trying to be an unopinionated as possible
\ so you can implement your own way of doing things.

\ if you need to see the what the return type of the word is
\ simply call "see" on it.  The word before "raycall" is the
\ structure type being returned as an address.

\ Any parameters prefixed with f- indicated a float value.
\ Everything else is either  an int or the name of a structure
\ like color, vector2/vec2, etc

: raycall ( xt type -- addr )
    allocate throw swap execute ;

: GetWindowPosition ( -- vec2  )
    ['] iGetWindowPosition Vector2 raycall ;

: GetWindowScaleDPI ( -- vec2  )
    ['] iGetWindowScaleDPI Vector2 raycall ;

: GetMouseRay ( Vector2 Camera3d -- Ray )
    ['] iGetMouseRay Ray raycall ;

: GetCameraMatrix ( Camera3d -- Matrix )
    ['] iGetCameraMatrix Matrix raycall ;

: GetCameraMatrix2D ( Camera2d -- Matrix )
    ['] iGetCameraMatrix2D Matrix raycall ;

: GetWorldToScreen ( position camera -- vector2 )
    ['] iGetWorldToScreen Vector2 raycall ;

: GetWorldToScreenEx ( pos cam width height -- vector )
    ['] iGetWorldToScreenEx Vector2 raycall ;

: GetWorldToScreen2D ( pos camera2d -- vector2 )
    ['] iGetWorldToScreen2D Vector2 raycall ;

\ I'm not capitalizing anymore.  Gforth is case insensitive anyway

: getscreentoworld2d ( pos camera2d -- vec2 )
    ['] igetscreentoworld2d vector2 raycall ;

: getmouseposition ( -- vec2 )
    ['] igetmouseposition vector2 raycall ;

: gettouchposition ( index -- vec2 )
    ['] igettouchposition vector2 raycall ;

: getgesturedragvector ( -- vec2 )
    ['] igetgesturedragvector vector2 raycall ;

: getgesturepinchvector ( -- vec2 )
    ['] igetgesturepinchvector vector2 raycall ;

: getcollisionrec ( rec1 rec2 -- rec3 )
    ['] igetcollisionrec rectangle raycall ;

: loadimage ( filename -- image )
    ['] iloadimage image raycall ;

: loadimageraw ( filename width height format headersize -- image )
    ['] iloadimageraw image raycall ;

: loadimageanim ( filename frames -- image )
    ['] iloadimageanim image raycall ;

: genimagecolor ( width height color -- image )
    ['] igenimagecolor image raycall ;

: genimagegradientv ( width height color-top color-bottom -- image )
    ['] igenimagegradientv image raycall ;

: genimagegradienth ( width height color-top color-bottom -- image )
    ['] igenimagegradienth image raycall ;

: genimagegradientradial ( width height f-density color-inner color-outer -- image )
    ['] igenimagegradientradial image raycall ;

: genimagechecked ( width height cheksX checksY color-1 color-2 -- image )
    ['] igenimagechecked image raycall ;

: genimagewhitenoise ( width height f-factor -- image )
    ['] igenimagewhitenoise image raycall ;

: genimageperlinnoise ( width height offsetX offsetY f-scale -- image )
    ['] igenimageperlinnoise image raycall ;

: genimagecellular ( width height tilesize -- image )
    ['] igenimagecellular image raycall ;

: imagecopy ( image -- image )
    ['] iimagecopy image raycall ;

: imagefromimage ( image rectangle -- image )
    ['] iimagefromimage image raycall ;

: imagetext ( text fontsize color -- image )
    ['] iimagetext image raycall ;

: imagetextex ( Font text f-fontsize f-spacing color-tint -- image )
    ['] iimagetextex image raycall ;

: getimagealphaborder ( image f-threshold -- rectangle )
    ['] igetimagealphaborder rectangle raycall ;

: loadtexture ( filename -- texture2d  )
    ['] iloadtexture texture2d raycall ;

: loadtexturefromimage ( image -- texture2d )
    ['] iloadtexturefromimage texture2d raycall ;

: loadtexturecubemap ( image layoutType -- texturecubemap )
    ['] iloadtexturecubemap texturecubemap raycall ;

: loadrendertexture ( width height -- rendertexture2d )
    ['] iloadrendertexture rendertexture2d raycall ;

: gettexturedata ( texture2d -- image )
    ['] igettexturedata image raycall ;

: getscreendata ( -- image )
    ['] igetscreendata image raycall ;

: fade ( color f-alpha -- color )
    ['] ifade color raycall ;

: getcolor ( hex -- color )
    ['] igetcolor color raycall ;

: colornormalize ( color -- vector4 )
    ['] icolornormalize vector4 raycall ;

: colorfromnormalized ( vector4 -- color )
    ['] icolorfromnormalized color raycall ;

: colortohsv ( color -- vec3 )
    ['] icolortohsv vector3 raycall ;

: colorfromhsv ( f-hue f-saturation f-value -- color )
    ['] icolorfromhsv color raycall ;

: coloralpha ( color f-alpha -- color )
    ['] icoloralpha color raycall ;

: coloralphablend ( color-dst color-src color-tint -- color )
    ['] icoloralphablend color raycall ;

: getpixelcolor ( scrPtr format -- color )
    ['] igetpixelcolor color raycall ;

: getfontdefault ( -- Font )
    ['] igetfontdefault font raycall ;

: loadfont ( filename -- font )
    ['] iloadfont font raycall ;

: loadfontex ( filename fontsize *fontchars charscount -- font )
    ['] iloadfontex font raycall ;

: loadfontfromimage ( image color-key firstchar -- font )
    ['] iloadfontfromimage font raycall ;

: genimagefontatlas ( CharInfo*chars Rectangle**recs charscount fontsize padding packmethod -- image )
    ['] igenimagefontatlas image raycall ;

: mesauretextex ( font text f-fontsize f-spacing -- vec2 )
    ['] imeasuretextex vector2 raycall ;

: loadmodel ( filename -- model )
    ['] iloadmodel model raycall ;

: loadmodelfrommesh ( mesh -- model )
    ['] iloadmodelfrommesh model raycall ;

: loadmaterialdefault ( -- material )
    ['] iloadmaterialdefault material raycall ;

: genmeshpoly ( sides f-radius -- mesh )
    ['] igenmeshpoly mesh raycall ;

: genmeshplane ( f-width f-length resx resz -- mesh )
    ['] igenmeshplane mesh raycall ;

: genmeshcube ( f-width f-height f-length -- mesh )
    ['] igenmeshcube mesh raycall ;

: genmeshsphere ( f-radius rings slices -- mesh )
    ['] igenmeshsphere mesh raycall ;

: genmeshhemisphere ( f-radius rings slices -- mesh )
    ['] igenmeshhemisphere mesh raycall ;

: genmeshcylinder ( f-radius f-height slices -- mesh )
    ['] igenmeshcylinder mesh raycall ;

: genmeshtorus ( f-radius f-size radSeg sides -- mesh )
    ['] igenmeshtorus mesh raycall ;

: genmeshknot ( f-radius f-size radSeg sides -- mesh )
    ['] igenmeshknot mesh raycall ;

: genmeshheightmap ( image-heightmap vector3-size -- mesh )
    ['] igenmeshheightmap mesh raycall ;

: genmeshcubicmap ( image-cubicmap vector3-cubesize -- mesh )
    ['] igenmeshcubicmap mesh raycall ;

: meshboundingbox ( mesh -- boundingbox )
    ['] imeshboundingbox boundingbox raycall ;

: getcollisionraymodel ( ray model -- rayinfo )
    ['] igetcollisionraymodel rayhitinfo raycall ;

: getcollisionraytriangle ( ray vec3-p1 vec3-p2 vec3-p3 -- rayinfo )
    ['] igetcollisionraytriangle rayhitinfo raycall ;

: getcollisionrayground ( ray f-groundheight -- rayinfo )
    ['] igetcollisionrayground rayhitinfo raycall ;

: loadshader ( vsfilename fsfilename -- shader )
    ['] iloadshader shader raycall ;

: loadshadercode ( vscode fscode -- shader )
    ['] iloadshadercode shader raycall ;

: getshaderdefault ( -- shader )
    ['] igetshaderdefault shader raycall ;

: gettexturedefault ( -- texture2d )
    ['] igettexturedefault texture2d raycall ;

: getshapestexture ( -- texture2d )
    ['] igetshapestexture texture2d raycall ;

: getshapestexturerec ( -- rectangle )
    ['] igetshapestexturerec rectangle raycall ;

: getmatrixmodelview ( -- matrix )
    ['] igetmatrixmodelview matrix raycall ;

: getmatrixprojection ( -- matrix )
    ['] igetmatrixprojection matrix raycall ;

: gentexturecubemap ( shader texture2d-map size -- texture2d )
    ['] igentexturecubemap texture2d raycall ;

: gentextureirradiance ( shader texture2d-cubemap size -- texture2d )
    ['] igentextureirradiance texture2d raycall ;

: gentextureprefilter ( shader texture2d-cubemap size -- texture2d )
    ['] igentextureprefilter texture2d raycall ;

: gentexturebrdf ( shader size -- texture2d )
    ['] igentexturebrdf texture2d raycall ;

: loadwave ( filename -- wave )
    ['] iloadwave wave raycall ;

: loadsound ( filename -- sound )
    ['] iloadsound sound raycall ;

: loadsoundfromwave ( wave -- sound )
    ['] iloadsoundfromwave sound raycall ;

: wavecopy ( wave -- wave )
    ['] iwavecopy wave raycall ;

: loadmusicstream ( filename -- music )
    ['] iloadmusicstream music raycall ;

: initaudiostream ( u-samplerate u-samplesize u-channels -- audiostream )
    ['] iinitaudiostream audiostream raycall ;