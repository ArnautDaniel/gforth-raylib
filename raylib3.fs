\ This file has been generated using SWIG and fsi,
\ and is already platform dependent, search for the corresponding
\ fsi-file to compile it where no one has compiled it before ;)
\ Forth systems have their own own dynamic loader and don't need addional C-Code.
\ That's why this file will just print normal forth-code once compiled
\ and can be used directly with include or require.
\ As all comments are stripped during the compilation, please
\ insert the copyright notice of the original file here.

\ UPDATE: File modified by hand to fix broken functions
\ Gforth does not support returning structures.
\ Functions that do that are wrapped to return a pointer instead.
\ A helper file will exist that wraps the original word into a forth word.
\ Memory management will have to be manual.
\ Helper file will be optional if you want to define your own way of doing it.


\ ---- For Raylib 3.0 -----

\ ----===< prefix >===-----
c-library raylib
s" raylib" add-lib
\c #include "raylib.h"

\ ---===< float constants >===----
\ 3.141593e0	fconstant PI \ already defined in gforth
0.017453e0	fconstant DEG2RAD
57.295776e0	fconstant RAD2DEG

\ --------===< enums >===---------
\ enum ConfigFlag
#1	constant FLAG_RESERVED
#2	constant FLAG_FULLSCREEN_MODE
#4	constant FLAG_WINDOW_RESIZABLE
#8	constant FLAG_WINDOW_UNDECORATED
#16	constant FLAG_WINDOW_TRANSPARENT
#128	constant FLAG_WINDOW_HIDDEN
#256	constant FLAG_WINDOW_ALWAYS_RUN
#32	constant FLAG_MSAA_4X_HINT
#64	constant FLAG_VSYNC_HINT
\ enum TraceLogType
#0	constant LOG_ALL
#1	constant LOG_TRACE
#2	constant LOG_DEBUG
#3	constant LOG_INFO
#4	constant LOG_WARNING
#5	constant LOG_ERROR
#6	constant LOG_FATAL
#7	constant LOG_NONE
\ enum KeyboardKey
#39	constant KEY_APOSTROPHE
#44	constant KEY_COMMA
#45	constant KEY_MINUS
#46	constant KEY_PERIOD
#47	constant KEY_SLASH
#48	constant KEY_ZERO
#49	constant KEY_ONE
#50	constant KEY_TWO
#51	constant KEY_THREE
#52	constant KEY_FOUR
#53	constant KEY_FIVE
#54	constant KEY_SIX
#55	constant KEY_SEVEN
#56	constant KEY_EIGHT
#57	constant KEY_NINE
#59	constant KEY_SEMICOLON
#61	constant KEY_EQUAL
#65	constant KEY_A
#66	constant KEY_B
#67	constant KEY_C
#68	constant KEY_D
#69	constant KEY_E
#70	constant KEY_F

#71	constant KEY_G
#72	constant KEY_H
#73	constant KEY_I
#74	constant KEY_J
#75	constant KEY_K
#76	constant KEY_L
#77	constant KEY_M
#78	constant KEY_N
#79	constant KEY_O
#80	constant KEY_P
#81	constant KEY_Q
#82	constant KEY_R
#83	constant KEY_S
#84	constant KEY_T
#85	constant KEY_U
#86	constant KEY_V
#87	constant KEY_W
#88	constant KEY_X
#89	constant KEY_Y
#90	constant KEY_Z
#32	constant KEY_SPACE
#256	constant KEY_ESCAPE
#257	constant KEY_ENTER
#258	constant KEY_TAB
#259	constant KEY_BACKSPACE
#260	constant KEY_INSERT
#261	constant KEY_DELETE
#262	constant KEY_RIGHT
#263	constant KEY_LEFT
#264	constant KEY_DOWN
#265	constant KEY_UP
#266	constant KEY_PAGE_UP
#267	constant KEY_PAGE_DOWN
#268	constant KEY_HOME
#269	constant KEY_END
#280	constant KEY_CAPS_LOCK
#281	constant KEY_SCROLL_LOCK
#282	constant KEY_NUM_LOCK
#283	constant KEY_PRINT_SCREEN
#284	constant KEY_PAUSE
#290	constant KEY_F1
#291	constant KEY_F2
#292	constant KEY_F3
#293	constant KEY_F4
#294	constant KEY_F5
#295	constant KEY_F6
#296	constant KEY_F7
#297	constant KEY_F8
#298	constant KEY_F9
#299	constant KEY_F10
#300	constant KEY_F11
#301	constant KEY_F12
#340	constant KEY_LEFT_SHIFT
#341	constant KEY_LEFT_CONTROL
#342	constant KEY_LEFT_ALT
#343	constant KEY_LEFT_SUPER
#344	constant KEY_RIGHT_SHIFT
#345	constant KEY_RIGHT_CONTROL
#346	constant KEY_RIGHT_ALT
#347	constant KEY_RIGHT_SUPER
#348	constant KEY_KB_MENU
#91	constant KEY_LEFT_BRACKET
#92	constant KEY_BACKSLASH
#93	constant KEY_RIGHT_BRACKET
#96	constant KEY_GRAVE
#320	constant KEY_KP_0
#321	constant KEY_KP_1
#322	constant KEY_KP_2
#323	constant KEY_KP_3
#324	constant KEY_KP_4
#325	constant KEY_KP_5
#326	constant KEY_KP_6
#327	constant KEY_KP_7
#328	constant KEY_KP_8
#329	constant KEY_KP_9
#330	constant KEY_KP_DECIMAL
#331	constant KEY_KP_DIVIDE
#332	constant KEY_KP_MULTIPLY
#333	constant KEY_KP_SUBTRACT
#334	constant KEY_KP_ADD
#335	constant KEY_KP_ENTER
#336	constant KEY_KP_EQUAL
\ enum AndroidButton
#4	constant KEY_BACK
#82	constant KEY_MENU
#24	constant KEY_VOLUME_UP
#25	constant KEY_VOLUME_DOWN
\ enum MouseButton
#0	constant MOUSE_LEFT_BUTTON
#1	constant MOUSE_RIGHT_BUTTON
#2	constant MOUSE_MIDDLE_BUTTON
\ enum GamepadNumber
#0	constant GAMEPAD_PLAYER1
#1	constant GAMEPAD_PLAYER2
#2	constant GAMEPAD_PLAYER3
#3	constant GAMEPAD_PLAYER4
\ enum GamepadButton
#0	constant GAMEPAD_BUTTON_UNKNOWN
#1	constant GAMEPAD_BUTTON_LEFT_FACE_UP
#2	constant GAMEPAD_BUTTON_LEFT_FACE_RIGHT
#3	constant GAMEPAD_BUTTON_LEFT_FACE_DOWN
#4	constant GAMEPAD_BUTTON_LEFT_FACE_LEFT
#5	constant GAMEPAD_BUTTON_RIGHT_FACE_UP
#6	constant GAMEPAD_BUTTON_RIGHT_FACE_RIGHT
#7	constant GAMEPAD_BUTTON_RIGHT_FACE_DOWN
#8	constant GAMEPAD_BUTTON_RIGHT_FACE_LEFT
#9	constant GAMEPAD_BUTTON_LEFT_TRIGGER_1
#10	constant GAMEPAD_BUTTON_LEFT_TRIGGER_2
#11	constant GAMEPAD_BUTTON_RIGHT_TRIGGER_1
#12	constant GAMEPAD_BUTTON_RIGHT_TRIGGER_2
#13	constant GAMEPAD_BUTTON_MIDDLE_LEFT
#14	constant GAMEPAD_BUTTON_MIDDLE
#15	constant GAMEPAD_BUTTON_MIDDLE_RIGHT
#16	constant GAMEPAD_BUTTON_LEFT_THUMB
#17	constant GAMEPAD_BUTTON_RIGHT_THUMB
\ enum GamepadAxis
#0	constant GAMEPAD_AXIS_LEFT_X
#1	constant GAMEPAD_AXIS_LEFT_Y
#2	constant GAMEPAD_AXIS_RIGHT_X
#3	constant GAMEPAD_AXIS_RIGHT_Y
#4	constant GAMEPAD_AXIS_LEFT_TRIGGER
#5	constant GAMEPAD_AXIS_RIGHT_TRIGGER
\ enum ShaderLocationIndex
#0	constant LOC_VERTEX_POSITION
#1	constant LOC_VERTEX_TEXCOORD01
#2	constant LOC_VERTEX_TEXCOORD02
#3	constant LOC_VERTEX_NORMAL
#4	constant LOC_VERTEX_TANGENT
#5	constant LOC_VERTEX_COLOR
#6	constant LOC_MATRIX_MVP
#7	constant LOC_MATRIX_MODEL
#8	constant LOC_MATRIX_VIEW
#9	constant LOC_MATRIX_PROJECTION
#10	constant LOC_VECTOR_VIEW
#11	constant LOC_COLOR_DIFFUSE
#12	constant LOC_COLOR_SPECULAR
#13	constant LOC_COLOR_AMBIENT
#14	constant LOC_MAP_ALBEDO
#15	constant LOC_MAP_METALNESS
#16	constant LOC_MAP_NORMAL
#17	constant LOC_MAP_ROUGHNESS
#18	constant LOC_MAP_OCCLUSION
#19	constant LOC_MAP_EMISSION
#20	constant LOC_MAP_HEIGHT
#21	constant LOC_MAP_CUBEMAP
#22	constant LOC_MAP_IRRADIANCE
#23	constant LOC_MAP_PREFILTER
#24	constant LOC_MAP_BRDF
\ enum ShaderUniformDataType
#0	constant UNIFORM_FLOAT
#1	constant UNIFORM_VEC2
#2	constant UNIFORM_VEC3
#3	constant UNIFORM_VEC4
#4	constant UNIFORM_INT
#5	constant UNIFORM_IVEC2
#6	constant UNIFORM_IVEC3
#7	constant UNIFORM_IVEC4
#8	constant UNIFORM_SAMPLER2D
\ enum MaterialMapType
#0	constant MAP_ALBEDO
#1	constant MAP_METALNESS
#2	constant MAP_NORMAL
#3	constant MAP_ROUGHNESS
#4	constant MAP_OCCLUSION
#5	constant MAP_EMISSION
#6	constant MAP_HEIGHT
#7	constant MAP_CUBEMAP
#8	constant MAP_IRRADIANCE
#9	constant MAP_PREFILTER
#10	constant MAP_BRDF
\ enum PixelFormat
#1	constant UNCOMPRESSED_GRAYSCALE
#2	constant UNCOMPRESSED_GRAY_ALPHA
#3	constant UNCOMPRESSED_R5G6B5
#4	constant UNCOMPRESSED_R8G8B8
#5	constant UNCOMPRESSED_R5G5B5A1
#6	constant UNCOMPRESSED_R4G4B4A4
#7	constant UNCOMPRESSED_R8G8B8A8
#8	constant UNCOMPRESSED_R32
#9	constant UNCOMPRESSED_R32G32B32
#10	constant UNCOMPRESSED_R32G32B32A32
#11	constant COMPRESSED_DXT1_RGB
#12	constant COMPRESSED_DXT1_RGBA
#13	constant COMPRESSED_DXT3_RGBA
#14	constant COMPRESSED_DXT5_RGBA
#15	constant COMPRESSED_ETC1_RGB
#16	constant COMPRESSED_ETC2_RGB
#17	constant COMPRESSED_ETC2_EAC_RGBA
#18	constant COMPRESSED_PVRT_RGB
#19	constant COMPRESSED_PVRT_RGBA
#20	constant COMPRESSED_ASTC_4x4_RGBA
#21	constant COMPRESSED_ASTC_8x8_RGBA
\ enum TextureFilterMode
#0	constant FILTER_POINT
#1	constant FILTER_BILINEAR
#2	constant FILTER_TRILINEAR
#3	constant FILTER_ANISOTROPIC_4X
#4	constant FILTER_ANISOTROPIC_8X
#5	constant FILTER_ANISOTROPIC_16X
\ enum CubemapLayoutType
#0	constant CUBEMAP_AUTO_DETECT
#1	constant CUBEMAP_LINE_VERTICAL
#2	constant CUBEMAP_LINE_HORIZONTAL
#3	constant CUBEMAP_CROSS_THREE_BY_FOUR
#4	constant CUBEMAP_CROSS_FOUR_BY_THREE
#5	constant CUBEMAP_PANORAMA
\ enum TextureWrapMode
#0	constant WRAP_REPEAT
#1	constant WRAP_CLAMP
#2	constant WRAP_MIRROR_REPEAT
#3	constant WRAP_MIRROR_CLAMP
\ enum FontType
#0	constant FONT_DEFAULT
#1	constant FONT_BITMAP
#2	constant FONT_SDF
\ enum BlendMode
#0	constant BLEND_ALPHA
#1	constant BLEND_ADDITIVE
#2	constant BLEND_MULTIPLIED
#3	constant BLEND_ADD_COLORS
#4	constant BLEND_SUBTRACT_COLORS
#5	constant BLEND_CUSTOM
\ enum GestureType
#0	constant GESTURE_NONE
#1	constant GESTURE_TAP
#2	constant GESTURE_DOUBLETAP
#4	constant GESTURE_HOLD
#8	constant GESTURE_DRAG
#16	constant GESTURE_SWIPE_RIGHT
#32	constant GESTURE_SWIPE_LEFT
#64	constant GESTURE_SWIPE_UP
#128	constant GESTURE_SWIPE_DOWN
#256	constant GESTURE_PINCH_IN
#512	constant GESTURE_PINCH_OUT
\ enum CameraMode
#0	constant CAMERA_CUSTOM
#1	constant CAMERA_FREE
#2	constant CAMERA_ORBITAL
#3	constant CAMERA_FIRST_PERSON
#4	constant CAMERA_THIRD_PERSON
\ enum CameraType
#0	constant CAMERA_PERSPECTIVE
#1	constant CAMERA_ORTHOGRAPHIC
\ enum NPatchType
#0	constant NPT_9PATCH
#1	constant NPT_3PATCH_VERTICAL
#2	constant NPT_3PATCH_HORIZONTAL

\ -------===< structs >===--------
\ Vector2
begin-structure Vector2
	drop 0 4 +field Vector2-x
	drop 4 4 +field Vector2-y
drop 8 end-structure
\ Vector3
begin-structure Vector3
	drop 0 4 +field Vector3-x
	drop 4 4 +field Vector3-y
	drop 8 4 +field Vector3-z
drop 12 end-structure
\ Vector4
begin-structure Vector4
	drop 12 4 +field Vector4-w
	drop 0 4 +field Vector4-x
	drop 4 4 +field Vector4-y
	drop 8 4 +field Vector4-z
drop 16 end-structure
\ Matrix
begin-structure Matrix
	drop 0 4 +field Matrix-m0
	drop 60 4 +field Matrix-m15
	drop 16 4 +field Matrix-m1
	drop 32 4 +field Matrix-m2
	drop 48 4 +field Matrix-m3
	drop 4 4 +field Matrix-m4
	drop 20 4 +field Matrix-m5
	drop 36 4 +field Matrix-m6
	drop 52 4 +field Matrix-m7
	drop 8 4 +field Matrix-m8
	drop 24 4 +field Matrix-m9
	drop 40 4 +field Matrix-m10
	drop 56 4 +field Matrix-m11
	drop 12 4 +field Matrix-m12
	drop 28 4 +field Matrix-m13
	drop 44 4 +field Matrix-m14
drop 64 end-structure
\ Color
begin-structure Color
	drop 2 1 +field Color-b
	drop 0 1 +field Color-r
	drop 1 1 +field Color-g
	drop 3 1 +field Color-a
drop 4 end-structure
\ Rectangle
begin-structure Rectangle
	drop 0 4 +field Rectangle-x
	drop 4 4 +field Rectangle-y
	drop 12 4 +field Rectangle-height
	drop 8 4 +field Rectangle-width
drop 16 end-structure
\ Image
begin-structure Image
	drop 0 8 +field Image-data
	drop 16 4 +field Image-mipmaps
	drop 12 4 +field Image-height
	drop 8 4 +field Image-width
	drop 20 4 +field Image-format
drop 24 end-structure
\ Texture2D
begin-structure Texture2D
	drop 0 4 +field Texture2D-id
	drop 12 4 +field Texture2D-mipmaps
	drop 8 4 +field Texture2D-height
	drop 4 4 +field Texture2D-width
	drop 16 4 +field Texture2D-format
    drop 20 end-structure

: texturecubemap texture2d ;

\ RenderTexture2D
begin-structure RenderTexture2D
	drop 0 4 +field RenderTexture2D-id
	drop 4 20 +field RenderTexture2D-texture
	drop 24 20 +field RenderTexture2D-depth
	drop 44 1 +field RenderTexture2D-depthTexture
drop 48 end-structure
\ NPatchInfo
begin-structure NPatchInfo
	drop 16 4 +field NPatchInfo-left
	drop 0 16 +field NPatchInfo-sourceRec
	drop 20 4 +field NPatchInfo-top
	drop 24 4 +field NPatchInfo-right
	drop 32 4 +field NPatchInfo-type
	drop 28 4 +field NPatchInfo-bottom
drop 36 end-structure
\ CharInfo
begin-structure CharInfo
	drop 4 4 +field CharInfo-offsetX
	drop 12 4 +field CharInfo-advanceX
	drop 8 4 +field CharInfo-offsetY
	drop 0 4 +field CharInfo-value
	drop 16 24 +field CharInfo-image
drop 40 end-structure
\ Font
begin-structure Font
	drop 0 4 +field Font-baseSize
	drop 32 8 +field Font-recs
	drop 4 4 +field Font-charsCount
	drop 8 20 +field Font-texture
	drop 40 8 +field Font-chars
drop 48 end-structure
\ Camera3D
begin-structure Camera3D
	drop 36 4 +field Camera3D-fovy
	drop 0 12 +field Camera3D-position
	drop 12 12 +field Camera3D-target
	drop 40 4 +field Camera3D-type
	drop 24 12 +field Camera3D-up
drop 44 end-structure
\ Camera2D
begin-structure Camera2D
	drop 20 4 +field Camera2D-zoom
	drop 8 8 +field Camera2D-target
	drop 0 8 +field Camera2D-offset
	drop 16 4 +field Camera2D-rotation
drop 24 end-structure
\ Mesh
begin-structure Mesh
	drop 64 8 +field Mesh-animVertices
	drop 8 8 +field Mesh-vertices
	drop 0 4 +field Mesh-vertexCount
	drop 40 8 +field Mesh-tangents
	drop 16 8 +field Mesh-texcoords
	drop 48 8 +field Mesh-colors
	drop 104 8 +field Mesh-vboId
	drop 72 8 +field Mesh-animNormals
	drop 32 8 +field Mesh-normals
	drop 88 8 +field Mesh-boneWeights
	drop 56 8 +field Mesh-indices
	drop 24 8 +field Mesh-texcoords2
	drop 4 4 +field Mesh-triangleCount
	drop 80 8 +field Mesh-boneIds
	drop 96 4 +field Mesh-vaoId
drop 112 end-structure
\ Shader
begin-structure Shader
	drop 8 8 +field Shader-locs
	drop 0 4 +field Shader-id
drop 16 end-structure
\ MaterialMap
begin-structure MaterialMap
	drop 20 4 +field MaterialMap-color
	drop 24 4 +field MaterialMap-value
	drop 0 20 +field MaterialMap-texture
drop 28 end-structure
\ Material
begin-structure Material
	drop 0 16 +field Material-shader
	drop 16 8 +field Material-maps
	drop 24 8 +field Material-params
drop 32 end-structure
\ Transform
begin-structure Transform
	drop 0 12 +field Transform-translation
	drop 28 12 +field Transform-scale
	drop 12 16 +field Transform-rotation
drop 40 end-structure
\ BoneInfo
begin-structure BoneInfo
	drop 0 32 +field BoneInfo-name
	drop 32 4 +field BoneInfo-parent
drop 36 end-structure
\ Model
begin-structure Model
	drop 64 4 +field Model-meshCount
	drop 80 4 +field Model-materialCount
	drop 112 8 +field Model-bones
	drop 120 8 +field Model-bindPose
	drop 88 8 +field Model-materials
	drop 96 8 +field Model-meshMaterial
	drop 104 4 +field Model-boneCount
	drop 0 64 +field Model-transform
	drop 72 8 +field Model-meshes
drop 128 end-structure
\ ModelAnimation
begin-structure ModelAnimation
	drop 24 8 +field ModelAnimation-framePoses
	drop 8 8 +field ModelAnimation-bones
	drop 16 4 +field ModelAnimation-frameCount
	drop 0 4 +field ModelAnimation-boneCount
drop 32 end-structure
\ Ray
begin-structure Ray
	drop 0 12 +field Ray-position
	drop 12 12 +field Ray-direction
  drop 24 end-structure

\ RayHitInfo
begin-structure RayHitInfo
	drop 4 4 +field RayHitInfo-distance
	drop 8 12 +field RayHitInfo-position
	drop 0 1 +field RayHitInfo-hit
	drop 20 12 +field RayHitInfo-normal
drop 32 end-structure
\ BoundingBox
begin-structure BoundingBox
	drop 12 12 +field BoundingBox-max
	drop 0 12 +field BoundingBox-min
drop 24 end-structure
\ Wave
begin-structure Wave
	drop 12 4 +field Wave-channels
	drop 16 8 +field Wave-data
	drop 8 4 +field Wave-sampleSize
	drop 4 4 +field Wave-sampleRate
	drop 0 4 +field Wave-sampleCount
drop 24 end-structure
\ AudioStream
begin-structure AudioStream
	drop 8 4 +field AudioStream-channels
	drop 4 4 +field AudioStream-sampleSize
	drop 16 8 +field AudioStream-buffer
	drop 0 4 +field AudioStream-sampleRate
drop 24 end-structure
\ Sound
begin-structure Sound
	drop 8 24 +field Sound-stream
	drop 0 4 +field Sound-sampleCount
drop 32 end-structure
\ Music
begin-structure Music
	drop 24 24 +field Music-stream
	drop 0 4 +field Music-ctxType
	drop 16 1 +field Music-looping
	drop 20 4 +field Music-sampleCount
	drop 8 8 +field Music-ctxData
drop 48 end-structure
\ VrDeviceInfo
begin-structure VrDeviceInfo
	drop 0 4 +field VrDeviceInfo-hResolution
	drop 4 4 +field VrDeviceInfo-vResolution
	drop 20 4 +field VrDeviceInfo-eyeToScreenDistance
	drop 24 4 +field VrDeviceInfo-lensSeparationDistance
	drop 28 4 +field VrDeviceInfo-interpupillaryDistance
	drop 8 4 +field VrDeviceInfo-hScreenSize
	drop 12 4 +field VrDeviceInfo-vScreenSize
	drop 16 4 +field VrDeviceInfo-vScreenCenter
	drop 32 16 +field VrDeviceInfo-lensDistortionValues
	drop 48 16 +field VrDeviceInfo-chromaAbCorrection
drop 64 end-structure

\ ------===< functions >===-------
c-function InitWindow InitWindow n n s -- void	( width height title -- )
c-function WindowShouldClose WindowShouldClose  -- n	( -- )
c-function CloseWindow CloseWindow  -- void	( -- )
c-function IsWindowReady IsWindowReady  -- n	( -- )
c-function IsWindowMinimized IsWindowMinimized  -- n	( -- )
c-function IsWindowMaximized IsWindowMaximized  -- n	( -- )
c-function IsWindowFocused IsWindowFocused  -- n	( -- )
c-function IsWindowResized IsWindowResized  -- n	( -- )
c-function IsWindowHidden IsWindowHidden  -- n	( -- )
c-function IsWindowFullscreen IsWindowFullscreen  -- n	( -- )
c-function ToggleFullscreen ToggleFullscreen  -- void	( -- )
c-function UnhideWindow UnhideWindow  -- void	( -- )
c-function HideWindow HideWindow  -- void	( -- )
c-function DecorateWindow DecorateWindow  -- void	( -- )
c-function UndecorateWindow UndecorateWindow  -- void	( -- )
c-function MaximizeWindow MaximizeWindow  -- void	( -- )
c-function RestoreWindow RestoreWindow  -- void	( -- )
c-function SetWindowIcon SetWindowIcon a{*(Image*)} -- void	( image -- )
c-function SetWindowTitle SetWindowTitle s -- void	( title -- )
c-function SetWindowPosition SetWindowPosition n n -- void	( x y -- )
c-function SetWindowMonitor SetWindowMonitor n -- void	( monitor -- )
c-function SetWindowMinSize SetWindowMinSize n n -- void	( width height -- )
c-function SetWindowSize SetWindowSize n n -- void	( width height -- )
c-function GetWindowHandle GetWindowHandle  -- a	( -- )
c-function GetScreenWidth GetScreenWidth  -- n	( -- )
c-function GetScreenHeight GetScreenHeight  -- n	( -- )
c-function GetMonitorCount GetMonitorCount  -- n	( -- )
c-function GetMonitorWidth GetMonitorWidth n -- n	( monitor -- )
c-function GetMonitorHeight GetMonitorHeight n -- n	( monitor -- )
c-function GetMonitorPhysicalWidth GetMonitorPhysicalWidth n -- n	( monitor -- )
c-function GetMonitorPhysicalHeight GetMonitorPhysicalHeight n -- n	( monitor -- )
c-function GetMonitorRefreshRate GetMonitorRefreshRate n -- n	( monitor -- )

\ Wrapping

\c Vector2 * iGetWindowPosition(Vector2 * p){
\c Vector2 v = GetWindowPosition();
\c *p = v; return p; }
c-function iGetWindowPosition iGetWindowPosition a -- a	( emptyVector2 -- Vector2 )

\c Vector2 * iGetWindowScaleDPI(Vector2 * p){
\c Vector2 v = GetWindowScaleDPI();
\c *p = v; return p; }
c-function iGetWindowScaleDPI iGetWindowScaleDPI a -- a ( emptyVector2 -- Vector2 )

c-function GetMonitorName GetMonitorName n -- s	( monitor -- )
c-function GetClipboardText GetClipboardText  -- s	( -- )
c-function SetClipboardText SetClipboardText s -- void	( text -- )
c-function ShowCursor ShowCursor  -- void	( -- )
c-function HideCursor HideCursor  -- void	( -- )
c-function IsCursorHidden IsCursorHidden  -- n	( -- )
c-function EnableCursor EnableCursor  -- void	( -- )
c-function DisableCursor DisableCursor  -- void	( -- )
c-function IsCursorOnScreen IsCursorOnScreen  -- n	( -- )
c-function ClearBackground ClearBackground a{*(Color*)} -- void	( color -- )
c-function BeginDrawing BeginDrawing  -- void	( -- )
c-function EndDrawing EndDrawing  -- void	( -- )
c-function BeginMode2D BeginMode2D a{*(Camera2D*)} -- void	( camera -- )
c-function EndMode2D EndMode2D  -- void	( -- )
c-function BeginMode3D BeginMode3D a{*(Camera3D*)} -- void	( camera -- )
c-function EndMode3D EndMode3D  -- void	( -- )
c-function BeginTextureMode BeginTextureMode a{*(RenderTexture2D*)} -- void	( target -- )
c-function EndTextureMode EndTextureMode  -- void	( -- )
c-function BeginScissorMode BeginScissorMode n n n n -- void	( x y width height -- )
c-function EndScissorMode EndScissorMode  -- void	( -- )

\ --------------------------------------------------------
\ ----------- Custom Defines -----------------------------

\c Ray* iGetMouseRay(Vector2 v, Camera c, Ray * r){
\c Ray ra = GetMouseRay(v, c);
\c *r = ra; return r; }

c-function iGetMouseRay iGetMouseRay a{*(Vector2*)} a{*(Camera3D*)} a -- a ( mousePosition camera -- Ray )

\c Matrix* iGetCameraMatrix(Camera c, Matrix* m){
\c Matrix ma = GetCameraMatrix(c);
\c *m = ma; return m; }

c-function iGetCameraMatrix iGetCameraMatrix a{*(Camera3D*)} a -- a	( camera matrix -- matrix )

\c Matrix* iGetCameraMatrix2D(Camera2D c, Matrix* m){
\c Matrix ma = GetCameraMatrix2D(c);
\c *m = ma; return m; }

c-function iGetCameraMatrix2D iGetCameraMatrix2D a{*(Camera2D*)} a -- a	( camera2d matrix -- matrix )

\c Vector2* iGetWorldToScreen(Vector3 position, Camera camera, Vector2* v){
\c Vector2 va = GetWorldToScreen(position, camera);
\c *v = va; return v; }

c-function iGetWorldToScreen iGetWorldToScreen a{*(Vector3*)} a{*(Camera3D*)} a -- a ( position camera vector2 -- vector2 )

\c Vector2* iGetWorldToScreenEx(Vector3 pos, Camera cam, int width, int height, Vector2* v){
\c Vector2 va = GetWorldToScreenEx(pos, cam, width, height);
\c *v = va; return v; }

c-function iGetWorldToScreenEx iGetWorldToScreenEx a{*(Vector3*)} a{*(Camera3D*)} n n a -- a	( position camera width height vector2 -- vector2 )

\c Vector2* iGetWorldToScreen2D(Vector2 pos, Camera2D camera, Vector2* v){
\c Vector2 va = GetWorldToScreen2D(pos, camera);
\c *v = va; return v; }

c-function iGetWorldToScreen2D iGetWorldToScreen2D a{*(Vector2*)} a{*(Camera2D*)} a -- a	( position camera vector2 -- vector2 )

\c Vector2* iGetScreenToWorld2D(Vector2 pos, Camera2D camera, Vector2* v){
\c Vector2 va = GetScreenToWorld2D(pos, camera);
\c *v = va; return v; }

c-function iGetScreenToWorld2D iGetScreenToWorld2D a{*(Vector2*)} a{*(Camera2D*)} a -- a	( position camera vector2 -- vector2 )

\ --------------------------------------------------------
\ ------------------End Custom Defines--------------------

c-function SetTargetFPS SetTargetFPS n -- void	( fps -- )
c-function GetFPS GetFPS  -- n	( -- )
c-function GetFrameTime GetFrameTime  -- r	( -- )
c-function GetTime GetTime  -- r	( -- )
c-function SetConfigFlags SetConfigFlags u -- void	( flags -- )
c-function SetTraceLogLevel SetTraceLogLevel n -- void	( logType -- )
c-function SetTraceLogExit SetTraceLogExit n -- void	( logType -- )
c-function SetTraceLogCallback SetTraceLogCallback a -- void	( callback -- )
c-function TraceLog TraceLog n s ... -- void	( logType text <noname> -- )
c-function TakeScreenshot TakeScreenshot s -- void	( fileName -- )
c-function GetRandomValue GetRandomValue n n -- n	( min max -- )
c-function LoadFileData LoadFileData s a -- a	( fileName bytesRead -- )
c-function SaveFileData SaveFileData s a u -- void	( fileName data bytesToWrite -- )
c-function LoadFileText LoadFileText s -- a	( fileName -- )
c-function SaveFileText SaveFileText s a -- void	( fileName text -- )
c-function FileExists FileExists s -- n	( fileName -- )
c-function IsFileExtension IsFileExtension s s -- n	( fileName ext -- )
c-function DirectoryExists DirectoryExists s -- n	( dirPath -- )
c-function GetExtension GetExtension s -- s	( fileName -- )
c-function GetFileName GetFileName s -- s	( filePath -- )
c-function GetFileNameWithoutExt GetFileNameWithoutExt s -- s	( filePath -- )
c-function GetDirectoryPath GetDirectoryPath s -- s	( filePath -- )
c-function GetPrevDirectoryPath GetPrevDirectoryPath s -- s	( dirPath -- )
c-function GetWorkingDirectory GetWorkingDirectory  -- s	( -- )
c-function GetDirectoryFiles GetDirectoryFiles s a -- a	( dirPath count -- )
c-function ClearDirectoryFiles ClearDirectoryFiles  -- void	( -- )
c-function ChangeDirectory ChangeDirectory s -- n	( dir -- )
c-function IsFileDropped IsFileDropped  -- n	( -- )
c-function GetDroppedFiles GetDroppedFiles a -- a	( count -- )
c-function ClearDroppedFiles ClearDroppedFiles  -- void	( -- )
c-function GetFileModTime GetFileModTime s -- n	( fileName -- )
c-function CompressData CompressData a n a -- a	( data dataLength compDataLength -- )
c-function DecompressData DecompressData a n a -- a	( compData compDataLength dataLength -- )
c-function SaveStorageValue SaveStorageValue u n -- void	( position value -- )
c-function LoadStorageValue LoadStorageValue u -- n	( position -- )
c-function OpenURL OpenURL s -- void	( url -- )
c-function IsKeyPressed IsKeyPressed n -- n	( key -- )
c-function IsKeyDown IsKeyDown n -- n	( key -- key )
c-function IsKeyReleased IsKeyReleased n -- n	( key -- )
c-function IsKeyUp IsKeyUp n -- n	( key -- )
c-function SetExitKey SetExitKey n -- void	( key -- )
c-function GetKeyPressed GetKeyPressed  -- n	( -- )
c-function IsGamepadAvailable IsGamepadAvailable n -- n	( gamepad -- )
c-function IsGamepadName IsGamepadName n s -- n	( gamepad name -- )
c-function GetGamepadName GetGamepadName n -- s	( gamepad -- )
c-function IsGamepadButtonPressed IsGamepadButtonPressed n n -- n	( gamepad button -- )
c-function IsGamepadButtonDown IsGamepadButtonDown n n -- n	( gamepad button -- )
c-function IsGamepadButtonReleased IsGamepadButtonReleased n n -- n	( gamepad button -- )
c-function IsGamepadButtonUp IsGamepadButtonUp n n -- n	( gamepad button -- )
c-function GetGamepadButtonPressed GetGamepadButtonPressed  -- n	( -- )
c-function GetGamepadAxisCount GetGamepadAxisCount n -- n	( gamepad -- )
c-function GetGamepadAxisMovement GetGamepadAxisMovement n n -- r	( gamepad axis -- )
c-function IsMouseButtonPressed IsMouseButtonPressed n -- n	( button -- )
c-function IsMouseButtonDown IsMouseButtonDown n -- n	( button -- )
c-function IsMouseButtonReleased IsMouseButtonReleased n -- n	( button -- )
c-function IsMouseButtonUp IsMouseButtonUp n -- n	( button -- )
c-function GetMouseX GetMouseX  -- n	( -- )
c-function GetMouseY GetMouseY  -- n	( -- )

\ ---------------- Custom ------------------
\c Vector2* iGetMousePosition(Vector2* v){
\c Vector2 va = GetMousePosition();
\c *v = va; return v; }

c-function iGetMousePosition iGetMousePosition a -- a	( -- vector2 )
\ ------------------------------------------

c-function SetMousePosition SetMousePosition n n -- void	( x y -- )
c-function SetMouseOffset SetMouseOffset n n -- void	( offsetX offsetY -- )
c-function SetMouseScale SetMouseScale r r -- void	( scaleX scaleY -- )
c-function GetMouseWheelMove GetMouseWheelMove  -- n	( -- )
c-function GetTouchX GetTouchX  -- n	( -- )
c-function GetTouchY GetTouchY  -- n	( -- )

\c Vector2* iGetTouchPosition(int index, Vector2* v){
\c Vector2 va = GetTouchPosition(index);
\c *v = va; return v; }

c-function iGetTouchPosition iGetTouchPosition n a -- a	( index vector2 --vector2 )

c-function SetGesturesEnabled SetGesturesEnabled u -- void	( gestureFlags -- )
c-function IsGestureDetected IsGestureDetected n -- n	( gesture -- )
c-function GetGestureDetected GetGestureDetected  -- n	( -- )
c-function GetTouchPointsCount GetTouchPointsCount  -- n	( -- )
c-function GetGestureHoldDuration GetGestureHoldDuration  -- r	( -- )

\c Vector2* iGetGestureDragVector(Vector2* v){
\c Vector2 va = GetGestureDragVector();
\c *v = va; return v; }

c-function iGetGestureDragVector iGetGestureDragVector a -- a	( vector2 -- vector2 )
c-function GetGestureDragAngle GetGestureDragAngle  -- r	( -- )

\c Vector2* iGetGesturePinchVector(Vector2* v){
\c Vector2 va = GetGesturePinchVector();
\c *v = va; return v; }

c-function iGetGesturePinchVector iGetGesturePinchVector a -- a	( vector2  -- vector2 )
c-function GetGesturePinchAngle GetGesturePinchAngle  -- r	( -- )
c-function SetCameraMode SetCameraMode a{*(Camera3D*)} n -- void	( camera mode -- )
c-function UpdateCamera UpdateCamera a -- void	( camera -- )
c-function SetCameraPanControl SetCameraPanControl n -- void	( panKey -- )
c-function SetCameraAltControl SetCameraAltControl n -- void	( altKey -- )
c-function SetCameraSmoothZoomControl SetCameraSmoothZoomControl n -- void	( szKey -- )
c-function SetCameraMoveControls SetCameraMoveControls n n n n n n -- void	( frontKey backKey rightKey leftKey upKey downKey -- )
c-function DrawPixel DrawPixel n n a{*(Color*)} -- void	( posX posY color -- )
c-function DrawPixelV DrawPixelV a{*(Vector2*)} a{*(Color*)} -- void	( position color -- )
c-function DrawLine DrawLine n n n n a{*(Color*)} -- void	( startPosX startPosY endPosX endPosY color -- )
c-function DrawLineV DrawLineV a{*(Vector2*)} a{*(Vector2*)} a{*(Color*)} -- void	( startPos endPos color -- )
c-function DrawLineEx DrawLineEx a{*(Vector2*)} a{*(Vector2*)} r a{*(Color*)} -- void	( startPos endPos thick color -- )
c-function DrawLineBezier DrawLineBezier a{*(Vector2*)} a{*(Vector2*)} r a{*(Color*)} -- void	( startPos endPos thick color -- )
c-function DrawLineStrip DrawLineStrip a n a{*(Color*)} -- void	( points numPoints color -- )
c-function DrawCircle DrawCircle n n r a{*(Color*)} -- void	( centerX centerY radius color -- )
c-function DrawCircleSector DrawCircleSector a{*(Vector2*)} r n n n a{*(Color*)} -- void	( center radius startAngle endAngle segments color -- )
c-function DrawCircleSectorLines DrawCircleSectorLines a{*(Vector2*)} r n n n a{*(Color*)} -- void	( center radius startAngle endAngle segments color -- )
c-function DrawCircleGradient DrawCircleGradient n n r a{*(Color*)} a{*(Color*)} -- void	( centerX centerY radius color1 color2 -- )
c-function DrawCircleV DrawCircleV a{*(Vector2*)} r a{*(Color*)} -- void	( center radius color -- )
c-function DrawCircleLines DrawCircleLines n n r a{*(Color*)} -- void	( centerX centerY radius color -- )
c-function DrawEllipse DrawEllipse n n r r a{*(Color*)} -- void	( centerX centerY radiusH radiusV color -- )
c-function DrawEllipseLines DrawEllipseLines n n r r a{*(Color*)} -- void	( centerX centerY radiusH radiusV color -- )
c-function DrawRing DrawRing a{*(Vector2*)} r r n n n a{*(Color*)} -- void	( center innerRadius outerRadius startAngle endAngle segments color -- )
c-function DrawRingLines DrawRingLines a{*(Vector2*)} r r n n n a{*(Color*)} -- void	( center innerRadius outerRadius startAngle endAngle segments color -- )
c-function DrawRectangle DrawRectangle n n n n a{*(Color*)} -- void	( posX posY width height color -- )
c-function DrawRectangleV DrawRectangleV a{*(Vector2*)} a{*(Vector2*)} a{*(Color*)} -- void	( position size color -- )
c-function DrawRectangleRec DrawRectangleRec a{*(Rectangle*)} a{*(Color*)} -- void	( rec color -- )
c-function DrawRectanglePro DrawRectanglePro a{*(Rectangle*)} a{*(Vector2*)} r a{*(Color*)} -- void	( rec origin rotation color -- )
c-function DrawRectangleGradientV DrawRectangleGradientV n n n n a{*(Color*)} a{*(Color*)} -- void	( posX posY width height color1 color2 -- )
c-function DrawRectangleGradientH DrawRectangleGradientH n n n n a{*(Color*)} a{*(Color*)} -- void	( posX posY width height color1 color2 -- )
c-function DrawRectangleGradientEx DrawRectangleGradientEx a{*(Rectangle*)} a{*(Color*)} a{*(Color*)} a{*(Color*)} a{*(Color*)} -- void	( rec col1 col2 col3 col4 -- )
c-function DrawRectangleLines DrawRectangleLines n n n n a{*(Color*)} -- void	( posX posY width height color -- )
c-function DrawRectangleLinesEx DrawRectangleLinesEx a{*(Rectangle*)} n a{*(Color*)} -- void	( rec lineThick color -- )
c-function DrawRectangleRounded DrawRectangleRounded a{*(Rectangle*)} r n a{*(Color*)} -- void	( rec roundness segments color -- )
c-function DrawRectangleRoundedLines DrawRectangleRoundedLines a{*(Rectangle*)} r n n a{*(Color*)} -- void	( rec roundness segments lineThick color -- )
c-function DrawTriangle DrawTriangle a{*(Vector2*)} a{*(Vector2*)} a{*(Vector2*)} a{*(Color*)} -- void	( v1 v2 v3 color -- )
c-function DrawTriangleLines DrawTriangleLines a{*(Vector2*)} a{*(Vector2*)} a{*(Vector2*)} a{*(Color*)} -- void	( v1 v2 v3 color -- )
c-function DrawTriangleFan DrawTriangleFan a n a{*(Color*)} -- void	( points numPoints color -- )
c-function DrawTriangleStrip DrawTriangleStrip a n a{*(Color*)} -- void	( points pointsCount color -- )
c-function DrawPoly DrawPoly a{*(Vector2*)} n r r a{*(Color*)} -- void	( center sides radius rotation color -- )
c-function DrawPolyLines DrawPolyLines a{*(Vector2*)} n r r a{*(Color*)} -- void	( center sides radius rotation color -- )
c-function CheckCollisionRecs CheckCollisionRecs a{*(Rectangle*)} a{*(Rectangle*)} -- n	( rec1 rec2 -- )
c-function CheckCollisionCircles CheckCollisionCircles a{*(Vector2*)} r a{*(Vector2*)} r -- n	( center1 radius1 center2 radius2 -- )
c-function CheckCollisionCircleRec CheckCollisionCircleRec a{*(Vector2*)} r a{*(Rectangle*)} -- n	( center radius rec -- )

\c Rectangle* iGetCollisionRec(Rectangle rec1, Rectangle rec2, Rectangle* rec3){
\c Rectangle rec4 = GetCollisionRec(rec1, rec2);
\c *rec3 = rec4; return rec3; }

c-function iGetCollisionRec iGetCollisionRec a{*(Rectangle*)} a{*(Rectangle*)} a -- a ( rec1 rec2 rec3 -- rec3 )
c-function CheckCollisionPointRec CheckCollisionPointRec a{*(Vector2*)} a{*(Rectangle*)} -- n	( point rec -- )
c-function CheckCollisionPointCircle CheckCollisionPointCircle a{*(Vector2*)} a{*(Vector2*)} r -- n	( point center radius -- )
c-function CheckCollisionPointTriangle CheckCollisionPointTriangle a{*(Vector2*)} a{*(Vector2*)} a{*(Vector2*)} a{*(Vector2*)} -- n	( point p1 p2 p3 -- )

\c Image* iLoadImage(const char* fileName, Image* img){
\c Image imga = LoadImage(fileName);
\c *img = imga; return img; }

c-function iLoadImage iLoadImage s a -- a	( fileName image -- image )

\c Image* iLoadImageRaw(const char* fileName, int width, int height, int format, int headerSize, Image* img){
\c Image imga = LoadImageRaw(fileName, width, height, format, headerSize);
\c *img = imga; return img; }

c-function iLoadImageRaw iLoadImageRaw s n n n n a -- a	( fileName width height format headerSize image -- image )

\c Image* iLoadImageAnim(const char* fileName, int* frames, Image* img){
\c Image imga = LoadImageAnim(fileName, frames);
\c *img = imga; return img; }

c-function iLoadImageAnim iLoadImageAnim s a a -- a	( fileName frames image -- image )
c-function UnloadImage UnloadImage a{*(Image*)} -- void	( image -- )
c-function ExportImage ExportImage a{*(Image*)} s -- void	( image fileName -- )
c-function ExportImageAsCode ExportImageAsCode a{*(Image*)} s -- void	( image fileName -- )

\c Image* iGenImageColor(int width, int height, Color color, Image* img){
\c Image imga = GenImageColor(width, height, color);
\c *img = imga; return img; }

c-function iGenImageColor iGenImageColor n n a{*(Color*)} a -- a	( width height colorimage -- image )

\c Image* iGenImageGradientV(int width, int height, Color top, Color bottom, Image* img){
\c Image imga = GenImageGradientV(width, height, top, bottom);
\c *img = imga; return img; }

c-function iGenImageGradientV iGenImageGradientV n n a{*(Color*)} a{*(Color*)} a -- a ( width height top bottom image -- image )

\c Image* iGenImageGradientH(int width, int height, Color top, Color bottom, Image* img){
\c Image imga = GenImageGradientH(width, height, top, bottom);
\c *img = imga; return img; }

c-function iGenImageGradientH iGenImageGradientH n n a{*(Color*)} a{*(Color*)} a -- a	( width height left right image -- image )

\c Image* iGenImageGradientRadial(int width, int height, float density, Color inner, Color outer, Image* img){
\c Image imga = GenImageGradientRadial(width, height, density, inner, outer);
\c *img = imga; return img; }

c-function iGenImageGradientRadial iGenImageGradientRadial n n r a{*(Color*)} a{*(Color*)} a -- a	( width height density inner outer image -- image )

\c Image* iGenImageChecked(int width, int height, int checksX, int checksY, Color col1, Color col2, Image* img){
\c Image imga = GenImageChecked(width, height, checksX, checksY, col1, col2);
\c *img = imga; return img; }

c-function iGenImageChecked iGenImageChecked n n n n a{*(Color*)} a{*(Color*)} a -- a	( width height checksX checksY col1 col2 image -- image )

\c Image* iGenImageWhiteNoise(int width, int height, float factor, Image* img){
\c Image imga = GenImageWhiteNoise(width, height, factor);
\c *img = imga; return img; }

c-function iGenImageWhiteNoise iGenImageWhiteNoise n n r a -- a	( width height factor image -- image )

\c Image* iGenImagePerlinNoise(int width, int height, int offsetX, int offsetY, float scale, Image* img){
\c Image imga = GenImagePerlinNoise(width, height, offsetX, offsetY, scale);
\c *img = imga; return img; }

c-function iGenImagePerlinNoise iGenImagePerlinNoise n n n n r a -- a	( width height offsetX offsetY scale image -- image )

\c Image* iGenImageCellular(int width, int height, int tileSize, Image* img){
\c Image imga = GenImageCellular(width, height, tileSize);
\c *img = imga; return img; }

c-function iGenImageCellular iGenImageCellular n n n a -- a	( width height tileSize image -- image )

\c Image* iImageCopy(Image image, Image* img){
\c Image imga = ImageCopy(image);
\c *img = imga; return img; }

c-function iImageCopy iImageCopy a{*(Image*)} a -- a	( image -- )

\c Image* iImageFromImage(Image image, Rectangle rec, Image* img){
\c Image imga = ImageFromImage(image, rec);
\c *img = imga; return img; }

c-function iImageFromImage iImageFromImage a{*(Image*)} a{*(Rectangle*)} a -- a	( image rec image -- image )

\c Image* iImageText(const char* text, int fontSize, Color color, Image* img){
\c Image imga = ImageText(text, fontSize, color);
\c *img = imga; return img; }

c-function iImageText iImageText s n a{*(Color*)} a -- a ( text fontSize color image -- image )

\c Image* iImageTextEx(Font font, const char* text, float fontSize, float spacing, Color tint, Image* img){
\c Image imga = ImageTextEx(font, text, fontSize, spacing, tint);
\c *img = imga; return img; }

c-function iImageTextEx iImageTextEx a{*(Font*)} s r r a{*(Color*)} a -- a ( font text fontSize spacing tint image -- image )

c-function ImageFormat ImageFormat a n -- void	( image newFormat -- )
c-function ImageToPOT ImageToPOT a a{*(Color*)} -- void	( image fill -- )
c-function ImageCrop ImageCrop a a{*(Rectangle*)} -- void	( image crop -- )
c-function ImageAlphaCrop ImageAlphaCrop a r -- void	( image threshold -- )
c-function ImageAlphaClear ImageAlphaClear a a{*(Color*)} r -- void	( image color threshold -- )
c-function ImageAlphaMask ImageAlphaMask a a{*(Image*)} -- void	( image alphaMask -- )
c-function ImageAlphaPremultiply ImageAlphaPremultiply a -- void	( image -- )
c-function ImageResize ImageResize a n n -- void	( image newWidth newHeight -- )
c-function ImageResizeNN ImageResizeNN a n n -- void	( image newWidth newHeight -- )
c-function ImageResizeCanvas ImageResizeCanvas a n n n n a{*(Color*)} -- void	( image newWidth newHeight offsetX offsetY fill -- )
c-function ImageMipmaps ImageMipmaps a -- void	( image -- )
c-function ImageDither ImageDither a n n n n -- void	( image rBpp gBpp bBpp aBpp -- )
c-function ImageFlipVertical ImageFlipVertical a -- void	( image -- )
c-function ImageFlipHorizontal ImageFlipHorizontal a -- void	( image -- )
c-function ImageRotateCW ImageRotateCW a -- void	( image -- )
c-function ImageRotateCCW ImageRotateCCW a -- void	( image -- )
c-function ImageColorTint ImageColorTint a a{*(Color*)} -- void	( image color -- )
c-function ImageColorInvert ImageColorInvert a -- void	( image -- )
c-function ImageColorGrayscale ImageColorGrayscale a -- void	( image -- )
c-function ImageColorContrast ImageColorContrast a r -- void	( image contrast -- )
c-function ImageColorBrightness ImageColorBrightness a n -- void	( image brightness -- )
c-function ImageColorReplace ImageColorReplace a a{*(Color*)} a{*(Color*)} -- void	( image color replace -- )
c-function GetImageData GetImageData a{*(Image*)} -- a	( image -- )
c-function GetImagePalette GetImagePalette a{*(Image*)} n a -- a	( image maxPaletteSize extractCount -- )
c-function GetImageDataNormalized GetImageDataNormalized a{*(Image*)} -- a	( image -- )

\c Rectangle* iGetImageAlphaBorder(Image image, float threshold, Rectangle* rec){
\c Rectangle reca = GetImageAlphaBorder(image, threshold);
\c *rec = reca; return rec; }

c-function iGetImageAlphaBorder iGetImageAlphaBorder a{*(Image*)} r a -- a	( image threshold image -- image )

c-function ImageClearBackground ImageClearBackground a a{*(Color*)} -- void	( dst color -- )
c-function ImageDrawPixel ImageDrawPixel a n n a{*(Color*)} -- void	( dst posX posY color -- )
c-function ImageDrawPixelV ImageDrawPixelV a a{*(Vector2*)} a{*(Color*)} -- void	( dst position color -- )
c-function ImageDrawLine ImageDrawLine a n n n n a{*(Color*)} -- void	( dst startPosX startPosY endPosX endPosY color -- )
c-function ImageDrawLineV ImageDrawLineV a a{*(Vector2*)} a{*(Vector2*)} a{*(Color*)} -- void	( dst start end color -- )
c-function ImageDrawCircle ImageDrawCircle a n n n a{*(Color*)} -- void	( dst centerX centerY radius color -- )
c-function ImageDrawCircleV ImageDrawCircleV a a{*(Vector2*)} n a{*(Color*)} -- void	( dst center radius color -- )
c-function ImageDrawRectangle ImageDrawRectangle a n n n n a{*(Color*)} -- void	( dst posX posY width height color -- )
c-function ImageDrawRectangleV ImageDrawRectangleV a a{*(Vector2*)} a{*(Vector2*)} a{*(Color*)} -- void	( dst position size color -- )
c-function ImageDrawRectangleRec ImageDrawRectangleRec a a{*(Rectangle*)} a{*(Color*)} -- void	( dst rec color -- )
c-function ImageDrawRectangleLines ImageDrawRectangleLines a a{*(Rectangle*)} n a{*(Color*)} -- void	( dst rec thick color -- )
c-function ImageDraw ImageDraw a a{*(Image*)} a{*(Rectangle*)} a{*(Rectangle*)} a{*(Color*)} -- void	( dst src srcRec dstRec tint -- )
c-function ImageDrawText ImageDrawText a s n n n a{*(Color*)} -- void	( dst text posX posY fontSize color -- )
c-function ImageDrawTextEx ImageDrawTextEx a a{*(Font*)} s a{*(Vector2*)} r r a{*(Color*)} -- void	( dst font text position fontSize spacing tint -- )

\c Texture2D* iLoadTexture(const char* fileName, Texture2D* tex){
\c Texture2D text = LoadTexture(fileName);
\c *tex = text; return tex; }

c-function iLoadTexture iLoadTexture s a -- a	( fileName texture2D -- texture2D )

\c Texture2D* iLoadTextureFromImage(Image image, Texture2D* tex){
\c Texture2D text = LoadTextureFromImage(image);
\c *tex = text; return tex; }

c-function iLoadTextureFromImage iLoadTextureFromImage a{*(Image*)} a -- a ( image texture2D -- texture2D )

\c TextureCubemap* iLoadTextureCubemap(Image image, int layoutType, TextureCubemap* tex){
\c TextureCubemap text = LoadTextureCubemap(image, layoutType);
\c *tex = text; return tex; }

c-function iLoadTextureCubemap iLoadTextureCubemap a{*(Image*)} n a -- a	( image layoutType -- )

\c RenderTexture2D* iLoadRenderTexture(int width, int height, RenderTexture2D* ren){
\c RenderTexture2D rend = LoadRenderTexture(width, height);
\c *ren = rend; return ren; }

c-function iLoadRenderTexture iLoadRenderTexture n n a -- a ( width height rendertexture -- rendertexture )

c-function UnloadTexture UnloadTexture a{*(Texture2D*)} -- void	( texture -- )
c-function UnloadRenderTexture UnloadRenderTexture a{*(RenderTexture2D*)} -- void	( target -- )
c-function UpdateTexture UpdateTexture a{*(Texture2D*)} a -- void	( texture pixels -- )
c-function UpdateTextureRec UpdateTextureRec a{*(Texture2D*)} a{*(Rectangle*)} a -- void	( texture rec pixels -- )

\c Image* iGetTextureData(Texture2D texture, Image* img){
\c Image imga = GetTextureData(texture);
\c *img = imga; return img; }

c-function iGetTextureData iGetTextureData a{*(Texture2D*)} a -- a ( texture image -- image )

\c Image* iGetScreenData(Image* img){
\c Image imga = GetScreenData();
\c *img = imga; return img; }

c-function iGetScreenData iGetScreenData a -- a	( image -- image )
c-function GenTextureMipmaps GenTextureMipmaps a -- void	( texture -- )
c-function SetTextureFilter SetTextureFilter a{*(Texture2D*)} n -- void	( texture filterMode -- )
c-function SetTextureWrap SetTextureWrap a{*(Texture2D*)} n -- void	( texture wrapMode -- )
c-function DrawTexture DrawTexture a{*(Texture2D*)} n n a{*(Color*)} -- void	( texture posX posY tint -- )
c-function DrawTextureV DrawTextureV a{*(Texture2D*)} a{*(Vector2*)} a{*(Color*)} -- void	( texture position tint -- )
c-function DrawTextureEx DrawTextureEx a{*(Texture2D*)} a{*(Vector2*)} r r a{*(Color*)} -- void	( texture position rotation scale tint -- )
c-function DrawTextureRec DrawTextureRec a{*(Texture2D*)} a{*(Rectangle*)} a{*(Vector2*)} a{*(Color*)} -- void	( texture sourceRec position tint -- )
c-function DrawTextureQuad DrawTextureQuad a{*(Texture2D*)} a{*(Vector2*)} a{*(Vector2*)} a{*(Rectangle*)} a{*(Color*)} -- void	( texture tiling offset quad tint -- )
c-function DrawTextureTiled DrawTextureTiled a{*(Texture2D*)} a{*(Rectangle*)} a{*(Rectangle*)} a{*(Vector2*)} r r a{*(Color*)} -- void	( texture sourceRec destRec origin rotation scale tint -- )
c-function DrawTexturePro DrawTexturePro a{*(Texture2D*)} a{*(Rectangle*)} a{*(Rectangle*)} a{*(Vector2*)} r a{*(Color*)} -- void	( texture sourceRec destRec origin rotation tint -- )
c-function DrawTextureNPatch DrawTextureNPatch a{*(Texture2D*)} a{*(NPatchInfo*)} a{*(Rectangle*)} a{*(Vector2*)} r a{*(Color*)} -- void	( texture nPatchInfo destRec origin rotation tint -- )

\c Color* iFade(Color color, float alpha, Color* col){
\c Color cola = Fade(color, alpha);
\c *col = cola; return col; }

c-function iFade iFade a{*(Color*)} r a -- a	( color alpha color -- color )

\c Color* iGetColor(int hex, Color* col){
\c Color c = GetColor(hex);
\c *col = c; return col; }

c-function iGetColor iGetColor n a -- a	( hexValue color -- color )

c-function ColorToInt ColorToInt a{*(Color*)} -- n	( color -- )

\c Vector4* iColorNormalize(Color color, Vector4* vec){
\c Vector4 veca = ColorNormalize(color);
\c *vec = veca; return vec; }

c-function iColorNormalize iColorNormalize a{*(Color*)} a -- a ( color vec4 -- vec4 )

\c Color* iColorFromNormalized(Vector4 normalized, Color* col){
\c Color cola = ColorFromNormalized(normalized);
\c *col = cola; return col; }

c-function iColorFromNormalized iColorFromNormalized a{*(Vector4*)} a -- a ( normalized color -- color )

\c Vector3* iColorToHSV(Color color, Vector3* vec){
\c Vector3 veca = ColorToHSV(color);
\c *vec = veca; return vec; }

c-function iColorToHSV iColorToHSV a{*(Color*)} a -- a	( color vec3 -- vec3 )

\c Color* iColorFromHSV(float hue, float saturation, float value, Color* col){
\c Color cola = ColorFromHSV(hue, saturation, value);
\c *col = cola; return col; }

c-function iColorFromHSV iColorFromHSV r r r a -- a ( hue saturation value color -- color )

\c Color* iColorAlpha(Color color, float alpha, Color* col){
\c Color cola = ColorAlpha(color, alpha);
\c *col = cola; return col; }

c-function iColorAlpha iColorAlpha a{*(Color*)} r a -- a ( color alpha color -- color )

\c Color* iColorAlphaBlend(Color dst, Color src, Color tint, Color* col){
\c Color cola = ColorAlphaBlend(dst, src, tint);
\c *col = cola; return col; }

c-function iColorAlphaBlend iColorAlphaBlend a{*(Color*)} a{*(Color*)} a{*(Color*)} a -- a ( dst src tint color -- color )

\c Color* iGetPixelColor(void *srcPtr, int format, Color* col){
\c Color cola = GetPixelColor(srcPtr, format);
\c *col = cola; return col; }

c-function iGetPixelColor iGetPixelColor a n a -- a  ( srcPtr format color -- color )
c-function SetPixelColor SetPixelColor a a{*(Color*)} n -- void	( dstPtr color format -- )
c-function GetPixelDataSize GetPixelDataSize n n n -- n	( width height format -- )

\c Font* iGetFontDefault(Font* fon){
\c Font fona = GetFontDefault();
\c *fon = fona; return fon; }

c-function iGetFontDefault iGetFontDefault a -- a ( font -- font )

\c Font* iLoadFont(const char* fileName, Font* fon){
\c Font fona = LoadFont(fileName);
\c *fon = fona; return fon; }

c-function iLoadFont iLoadFont s a -- a	( fileName font -- font )

\c Font* iLoadFontEx(const char* fileName, int fontSize, int* fontChars, int charsCount, Font* fon){
\c Font fona = LoadFontEx(fileName, fontSize, fontChars, charsCount);
\c *fon = fona; return fon; }

c-function iLoadFontEx iLoadFontEx s n a n a -- a ( fileName fontSize fontChars charsCount font -- font )

\c Font* iLoadFontFromImage(Image image, Color key, int firstChar, Font* fon){
\c Font fona = LoadFontFromImage(image, key, firstChar);
\c *fon = fona; return fon; }

c-function iLoadFontFromImage iLoadFontFromImage a{*(Image*)} a{*(Color*)} n a -- a ( image key firstChar font -- font )
c-function LoadFontData LoadFontData s n a n n -- a	( fileName fontSize fontChars charsCount type -- )

\c Image* iGenImageFontAtlas(const CharInfo* chars, Rectangle** recs, int charsCount, int fontSize, int padding, int packMethod, Image* img){
\c Image imga = GenImageFontAtlas(chars, recs, charsCount, fontSize, padding, packMethod);
\c *img = imga; return img; }

c-function iGenImageFontAtlas iGenImageFontAtlas a a n n n n a -- a ( chars recs charsCount fontSize padding packMethod image -- image )
c-function UnloadFont UnloadFont a{*(Font*)} -- void	( font -- )
c-function DrawFPS DrawFPS n n -- void	( posX posY -- )
c-function DrawText DrawText s n n n a{*(Color*)} -- void	( text posX posY fontSize color -- )
c-function DrawTextEx DrawTextEx a{*(Font*)} s a{*(Vector2*)} r r a{*(Color*)} -- void	( font text position fontSize spacing tint -- )
c-function DrawTextRec DrawTextRec a{*(Font*)} s a{*(Rectangle*)} r r n a{*(Color*)} -- void	( font text rec fontSize spacing wordWrap tint -- )
c-function DrawTextRecEx DrawTextRecEx a{*(Font*)} s a{*(Rectangle*)} r r n a{*(Color*)} n n a{*(Color*)} a{*(Color*)} -- void	( font text rec fontSize spacing wordWrap tint selectStart selectLength selectTint selectBackTint -- )
c-function DrawTextCodepoint DrawTextCodepoint a{*(Font*)} n a{*(Vector2*)} r a{*(Color*)} -- void	( font codepoint position scale tint -- )
c-function MeasureText MeasureText s n -- n	( text fontSize -- )

\c Vector2* iMeasureTextEx(Font font, const char* text, float fontSize, float spacing, Vector2* vec){
\c Vector2 veca = MeasureTextEx(font, text, fontSize, spacing);
\c *vec = veca; return vec; }

c-function iMeasureTextEx iMeasureTextEx a{*(Font*)} s r r a -- a ( font text fontSize spacing vector2 -- vector2 )
c-function GetGlyphIndex GetGlyphIndex a{*(Font*)} n -- n	( font codepoint -- )
c-function TextCopy TextCopy a s -- n	( dst src -- )
c-function TextIsEqual TextIsEqual s s -- n	( text1 text2 -- )
c-function TextLength TextLength s -- u	( text -- )
c-function TextFormat TextFormat s ... -- s	( text <noname> -- )
c-function TextSubtext TextSubtext s n n -- s	( text position length -- )
c-function TextReplace TextReplace a s s -- a	( text replace by -- )
c-function TextInsert TextInsert s s n -- a	( text insert position -- )
c-function TextJoin TextJoin a n s -- s	( textList count delimiter -- )
c-function TextSplit TextSplit s u a -- a	( text delimiter count -- )
c-function TextAppend TextAppend a s a -- void	( text append position -- )
c-function TextFindIndex TextFindIndex s s -- n	( text find -- )
c-function TextToUpper TextToUpper s -- s	( text -- )
c-function TextToLower TextToLower s -- s	( text -- )
c-function TextToPascal TextToPascal s -- s	( text -- )
c-function TextToInteger TextToInteger s -- n	( text -- )
c-function TextToUtf8 TextToUtf8 a n -- a	( codepoints length -- )
c-function GetCodepoints GetCodepoints s a -- a	( text count -- )
c-function GetCodepointsCount GetCodepointsCount s -- n	( text -- )
c-function GetNextCodepoint GetNextCodepoint s a -- n	( text bytesProcessed -- )
c-function CodepointToUtf8 CodepointToUtf8 n a -- s	( codepoint byteLength -- )
c-function DrawLine3D DrawLine3D a{*(Vector3*)} a{*(Vector3*)} a{*(Color*)} -- void	( startPos endPos color -- )
c-function DrawPoint3D DrawPoint3D a{*(Vector3*)} a{*(Color*)} -- void	( position color -- )
c-function DrawCircle3D DrawCircle3D a{*(Vector3*)} r a{*(Vector3*)} r a{*(Color*)} -- void	( center radius rotationAxis rotationAngle color -- )
c-function DrawTriangle3D DrawTriangle3D a{*(Vector3*)} a{*(Vector3*)} a{*(Vector3*)} a{*(Color*)} -- void	( v1 v2 v3 color -- )
c-function DrawTriangleStrip3D DrawTriangleStrip3D a n a{*(Color*)} -- void	( points pointsCount color -- )
c-function DrawCube DrawCube a{*(Vector3*)} r r r a{*(Color*)} -- void	( position width height length color -- )
c-function DrawCubeV DrawCubeV a{*(Vector3*)} a{*(Vector3*)} a{*(Color*)} -- void	( position size color -- )
c-function DrawCubeWires DrawCubeWires a{*(Vector3*)} r r r a{*(Color*)} -- void	( position width height length color -- )
c-function DrawCubeWiresV DrawCubeWiresV a{*(Vector3*)} a{*(Vector3*)} a{*(Color*)} -- void	( position size color -- )
c-function DrawCubeTexture DrawCubeTexture a{*(Texture2D*)} a{*(Vector3*)} r r r a{*(Color*)} -- void	( texture position width height length color -- )
c-function DrawSphere DrawSphere a{*(Vector3*)} r a{*(Color*)} -- void	( centerPos radius color -- )
c-function DrawSphereEx DrawSphereEx a{*(Vector3*)} r n n a{*(Color*)} -- void	( centerPos radius rings slices color -- )
c-function DrawSphereWires DrawSphereWires a{*(Vector3*)} r n n a{*(Color*)} -- void	( centerPos radius rings slices color -- )
c-function DrawCylinder DrawCylinder a{*(Vector3*)} r r r n a{*(Color*)} -- void	( position radiusTop radiusBottom height slices color -- )
c-function DrawCylinderWires DrawCylinderWires a{*(Vector3*)} r r r n a{*(Color*)} -- void	( position radiusTop radiusBottom height slices color -- )
c-function DrawPlane DrawPlane a{*(Vector3*)} a{*(Vector2*)} a{*(Color*)} -- void	( centerPos size color -- )
c-function DrawRay DrawRay a{*(Ray*)} a{*(Color*)} -- void	( ray color -- )
c-function DrawGrid DrawGrid n r -- void	( slices spacing -- )
c-function DrawGizmo DrawGizmo a{*(Vector3*)} -- void	( position -- )

\c Model* iLoadModel(const char* fileName, Model* mod){
\c Model moda = LoadModel(fileName);
\c *mod = moda; return mod; }

c-function iLoadModel iLoadModel s a -- a ( fileName model -- model )

\c Model* iLoadModelFromMesh(Mesh mesh, Model* mod){
\c Model moda = LoadModelFromMesh(mesh);
\c *mod = moda; return mod; }

c-function iLoadModelFromMesh iLoadModelFromMesh a{*(Mesh*)} a -- a ( mesh model -- model )
c-function UnloadModel UnloadModel a{*(Model*)} -- void	( model -- )
c-function LoadMeshes LoadMeshes s a -- a	( fileName meshCount -- )
c-function ExportMesh ExportMesh a{*(Mesh*)} s -- void	( mesh fileName -- )
c-function UnloadMesh UnloadMesh a{*(Mesh*)} -- void	( mesh -- )
c-function LoadMaterials LoadMaterials s a -- a	( fileName materialCount -- )

\c Material* iLoadMaterialDefault(Material* mat){
\c Material mata = LoadMaterialDefault();
\c *mat = mata; return mat; }

c-function iLoadMaterialDefault iLoadMaterialDefault a -- a ( material -- material )
c-function UnloadMaterial UnloadMaterial a{*(Material*)} -- void	( material -- )
c-function SetMaterialTexture SetMaterialTexture a n a{*(Texture2D*)} -- void	( material mapType texture -- )
c-function SetModelMeshMaterial SetModelMeshMaterial a n n -- void	( model meshId materialId -- )
c-function LoadModelAnimations LoadModelAnimations s a -- a	( fileName animsCount -- )
c-function UpdateModelAnimation UpdateModelAnimation a{*(Model*)} a{*(ModelAnimation*)} n -- void	( model anim frame -- )
c-function UnloadModelAnimation UnloadModelAnimation a{*(ModelAnimation*)} -- void	( anim -- )
c-function IsModelAnimationValid IsModelAnimationValid a{*(Model*)} a{*(ModelAnimation*)} -- n	( model anim -- )

\c Mesh* iGenMeshPoly(int sides, float radius, Mesh* mes){
\c Mesh mesa = GenMeshPoly(sides, radius);
\c *mes = mesa; return mes; }

c-function iGenMeshPoly iGenMeshPoly n r a -- a	( sides radius mesh -- mesh )

\c Mesh* iGenMeshPlane(float width, float length, int resX, int resZ, Mesh* mes){
\c Mesh mesa = GenMeshPlane(width, length, resX, resZ);
\c *mes = mesa; return mes; }

c-function iGenMeshPlane iGenMeshPlane r r n n a -- a ( width length resX resZ mesh -- mesh )

\c Mesh* iGenMeshCube(float width, float height, float length, Mesh* mes){
\c Mesh mesa = GenMeshCube(width, height, length);
\c *mes = mesa; return mes; }

c-function iGenMeshCube iGenMeshCube r r r a -- a ( width height length mesh -- mesh )

\c Mesh* iGenMeshSphere(float radius, int rings, int slices, Mesh* mes){
\c Mesh mesa = GenMeshSphere(radius, rings, slices);
\c *mes = mesa; return mes; }

c-function iGenMeshSphere iGenMeshSphere r n n a -- a ( radius rings slices mesh -- mesh )

\c Mesh* iGenMeshHemiSphere(float radius, int rings, int slices, Mesh* mes){
\c Mesh mesa = GenMeshHemiSphere(radius, rings, slices);
\c *mes = mesa; return mes; }

c-function iGenMeshHemiSphere iGenMeshHemiSphere r n n a -- a ( radius rings slices mesh -- mesh )

\c Mesh* iGenMeshCylinder(float radius, float height, int slices, Mesh* mes){
\c Mesh mesa = GenMeshCylinder(radius, height, slices);
\c *mes = mesa; return mes; }

c-function iGenMeshCylinder iGenMeshCylinder r r n a -- a ( radius height slices mesh -- mesh )

\c Mesh* iGenMeshTorus(float radius, float size, int radSeg, int sides, Mesh* mes){
\c Mesh mesa = GenMeshTorus(radius, size, radSeg, sides);
\c *mes = mesa; return mes; }

c-function iGenMeshTorus iGenMeshTorus r r n n a -- a ( radius size radSeg sides mesh -- mesh )

\c Mesh* iGenMeshKnot(float radius, float size, int radSeg, int sides, Mesh* mes){
\c Mesh mesa = GenMeshKnot(radius, size, radSeg, sides);
\c *mes = mesa; return mes; }

c-function iGenMeshKnot iGenMeshKnot r r n n a -- a ( radius size radSeg sides mesh -- mesh )

\c Mesh* iGenMeshHeightmap(Image heightmap, Vector3 size, Mesh* mes){
\c Mesh mesa = GenMeshHeightmap(heightmap, size);
\c *mes = mesa; return mes; }

c-function iGenMeshHeightmap iGenMeshHeightmap a{*(Image*)} a{*(Vector3*)} a -- a ( heightmap size mesh -- mesh )

\c Mesh* iGenMeshCubicmap(Image cubicmap, Vector3 cubeSize, Mesh* mes){
\c Mesh mesa = GenMeshCubicmap(cubicmap, cubeSize);
\c *mes = mesa; return mes; }

c-function iGenMeshCubicmap iGenMeshCubicmap a{*(Image*)} a{*(Vector3*)} a -- a ( cubicmap cubeSize mesh -- mesh )

\c BoundingBox* iMeshBoundingBox(Mesh mesh, BoundingBox* box){
\c BoundingBox boxa = MeshBoundingBox(mesh);
\c *box = boxa; return box; }

c-function iMeshBoundingBox iMeshBoundingBox a{*(Mesh*)} a -- a ( mesh mesh -- mesh )
c-function MeshTangents MeshTangents a -- void	( mesh -- )
c-function MeshBinormals MeshBinormals a -- void	( mesh -- )
c-function MeshNormalsSmooth MeshNormalsSmooth a -- void	( mesh -- )
c-function DrawModel DrawModel a{*(Model*)} a{*(Vector3*)} r a{*(Color*)} -- void	( model position scale tint -- )
c-function DrawModelEx DrawModelEx a{*(Model*)} a{*(Vector3*)} a{*(Vector3*)} r a{*(Vector3*)} a{*(Color*)} -- void	( model position rotationAxis rotationAngle scale tint -- )
c-function DrawModelWires DrawModelWires a{*(Model*)} a{*(Vector3*)} r a{*(Color*)} -- void	( model position scale tint -- )
c-function DrawModelWiresEx DrawModelWiresEx a{*(Model*)} a{*(Vector3*)} a{*(Vector3*)} r a{*(Vector3*)} a{*(Color*)} -- void	( model position rotationAxis rotationAngle scale tint -- )
c-function DrawBoundingBox DrawBoundingBox a{*(BoundingBox*)} a{*(Color*)} -- void	( box color -- )
c-function DrawBillboard DrawBillboard a{*(Camera3D*)} a{*(Texture2D*)} a{*(Vector3*)} r a{*(Color*)} -- void	( camera texture center size tint -- )
c-function DrawBillboardRec DrawBillboardRec a{*(Camera3D*)} a{*(Texture2D*)} a{*(Rectangle*)} a{*(Vector3*)} r a{*(Color*)} -- void	( camera texture sourceRec center size tint -- )
c-function CheckCollisionSpheres CheckCollisionSpheres a{*(Vector3*)} r a{*(Vector3*)} r -- n	( centerA radiusA centerB radiusB -- )
c-function CheckCollisionBoxes CheckCollisionBoxes a{*(BoundingBox*)} a{*(BoundingBox*)} -- n	( box1 box2 -- )
c-function CheckCollisionBoxSphere CheckCollisionBoxSphere a{*(BoundingBox*)} a{*(Vector3*)} r -- n	( box center radius -- )
c-function CheckCollisionRaySphere CheckCollisionRaySphere a{*(Ray*)} a{*(Vector3*)} r -- n	( ray center radius -- )
c-function CheckCollisionRaySphereEx CheckCollisionRaySphereEx a{*(Ray*)} a{*(Vector3*)} r a -- n	( ray center radius collisionPoint -- )
c-function CheckCollisionRayBox CheckCollisionRayBox a{*(Ray*)} a{*(BoundingBox*)} -- n	( ray box -- )

\c RayHitInfo* iGetCollisionRayModel(Ray ray, Model model, RayHitInfo* rayinfo){
\c RayHitInfo rayinfoa = GetCollisionRayModel(ray, model);
\c *rayinfo = rayinfoa; return rayinfo; }

c-function iGetCollisionRayModel iGetCollisionRayModel a{*(Ray*)} a{*(Model*)} a -- a ( ray model rayhitinfo -- rayhitinfo )

\c RayHitInfo* iGetCollisionRayTriangle(Ray ray, Vector3 p1, Vector3 p2, Vector3 p3, RayHitInfo* rayinfo){
\c RayHitInfo rayinfoa = GetCollisionRayTriangle(ray, p1, p2, p3);
\c *rayinfo = rayinfoa; return rayinfo; }

c-function iGetCollisionRayTriangle iGetCollisionRayTriangle a{*(Ray*)} a{*(Vector3*)} a{*(Vector3*)} a{*(Vector3*)} a -- a ( ray p1 p2 p3 rhi -- rhi )

\c RayHitInfo* iGetCollisionRayGround(Ray ray, float groundHeight, RayHitInfo* rayinfo){
\c RayHitInfo rayinfoa = GetCollisionRayGround(ray, groundHeight);
\c *rayinfo = rayinfoa; return rayinfo; }

c-function iGetCollisionRayGround iGetCollisionRayGround a{*(Ray*)} r a -- a ( ray groundHeight rhi  -- rhi )

\c Shader* iLoadShader(const char* vsFileName, const char* fsFileName, Shader* shd){
\c Shader shda = LoadShader(vsFileName, fsFileName);
\c *shd = shda; return shd; }

c-function iLoadShader iLoadShader s s a -- a ( vsFileName fsFileName shader -- shader )

\c Shader* iLoadShaderCode(const char* vsCode, const char* fsCode, Shader* shd){
\c Shader shda = LoadShaderCode(vsCode, fsCode);
\c *shd = shda; return shd; }

c-function iLoadShaderCode iLoadShaderCode s s a -- a ( vsCode fsCode shader -- shader )
c-function UnloadShader UnloadShader a{*(Shader*)} -- void	( shader -- )

\c Shader* iGetShaderDefault(Shader* shd){
\c Shader shda = GetShaderDefault();
\c *shd = shda; return shd; }

c-function iGetShaderDefault iGetShaderDefault  a -- a ( shader -- shader )

\c Texture2D* iGetTextureDefault(Texture2D* tex){
\c Texture2D texa = GetTextureDefault();
\c *tex = texa; return tex; }

c-function iGetTextureDefault iGetTextureDefault  a -- a ( texture2d -- texture2d )

\c Texture2D* iGetShapesTexture(Texture2D* tex){
\c Texture2D texa = GetShapesTexture();
\c *tex = texa; return tex; }

c-function iGetShapesTexture iGetShapesTexture  a -- a ( texture2d -- texture2d )

\c Rectangle* iGetShapesTextureRec(Rectangle* rec){
\c Rectangle reca = GetShapesTextureRec();
\c *rec = reca; return rec; }

c-function iGetShapesTextureRec iGetShapesTextureRec a -- a ( rectangle -- rectangle )
c-function SetShapesTexture SetShapesTexture a{*(Texture2D*)} a{*(Rectangle*)} -- void	( texture source -- )
c-function GetShaderLocation GetShaderLocation a{*(Shader*)} s -- n	( shader uniformName -- )
c-function SetShaderValue SetShaderValue a{*(Shader*)} n a n -- void	( shader uniformLoc value uniformType -- )
c-function SetShaderValueV SetShaderValueV a{*(Shader*)} n a n n -- void	( shader uniformLoc value uniformType count -- )
c-function SetShaderValueMatrix SetShaderValueMatrix a{*(Shader*)} n a{*(Matrix*)} -- void	( shader uniformLoc mat -- )
c-function SetShaderValueTexture SetShaderValueTexture a{*(Shader*)} n a{*(Texture2D*)} -- void	( shader uniformLoc texture -- )
c-function SetMatrixProjection SetMatrixProjection a{*(Matrix*)} -- void	( proj -- )
c-function SetMatrixModelview SetMatrixModelview a{*(Matrix*)} -- void	( view -- )

\c Matrix* iGetMatrixModelview(Matrix* mat){
\c Matrix mata = GetMatrixModelview();
\c *mat = mata; return mat; }

c-function iGetMatrixModelview iGetMatrixModelview  a -- a ( matrix -- matrix )

\c Matrix* iGetMatrixProjection(Matrix* mat){
\c Matrix mata = GetMatrixProjection();
\c *mat = mata; return mat; }

c-function iGetMatrixProjection iGetMatrixProjection  a -- a ( matrix -- matrix )

\c Texture2D* iGenTextureCubemap(Shader shader, Texture2D map, int size, Texture2D* tex){
\c Texture2D texa = GenTextureCubemap(shader, map, size);
\c *tex = texa; return tex; }

c-function iGenTextureCubemap iGenTextureCubemap a{*(Shader*)} a{*(Texture2D*)} n a -- a ( shader map size texture -- texture )

\c Texture2D* iGenTextureIrradiance(Shader shader, Texture2D cubemap, int size, Texture2D* tex){
\c Texture2D texa = GenTextureIrradiance(shader, cubemap, size);
\c *tex = texa; return tex; }

c-function iGenTextureIrradiance iGenTextureIrradiance a{*(Shader*)} a{*(Texture2D*)} n a -- a ( shader cubemap size texture -- texture )

\c Texture2D* iGenTexturePrefilter(Shader shader, Texture2D cubemap, int size, Texture2D* tex){
\c Texture2D texa = GenTexturePrefilter(shader, cubemap, size);
\c *tex = texa; return tex; }

c-function iGenTexturePrefilter iGenTexturePrefilter a{*(Shader*)} a{*(Texture2D*)} n a -- a ( shader cubemap size texture -- texture )

\c Texture2D* iGenTextureBRDF(Shader shader, int size, Texture2D* tex){
\c Texture2D texa = GenTextureBRDF(shader, size);
\c *tex = texa; return tex; }

c-function iGenTextureBRDF iGenTextureBRDF a{*(Shader*)} n a -- a ( shader size texture -- texture )
c-function BeginShaderMode BeginShaderMode a{*(Shader*)} -- void	( shader -- )
c-function EndShaderMode EndShaderMode  -- void	( -- )
c-function BeginBlendMode BeginBlendMode n -- void	( mode -- )
c-function EndBlendMode EndBlendMode  -- void	( -- )
c-function InitVrSimulator InitVrSimulator  -- void	( -- )
c-function CloseVrSimulator CloseVrSimulator  -- void	( -- )
c-function UpdateVrTracking UpdateVrTracking a -- void	( camera -- )
c-function SetVrConfiguration SetVrConfiguration a{*(VrDeviceInfo*)} a{*(Shader*)} -- void	( info distortion -- )
c-function IsVrSimulatorReady IsVrSimulatorReady  -- n	( -- )
c-function ToggleVrMode ToggleVrMode  -- void	( -- )
c-function BeginVrDrawing BeginVrDrawing  -- void	( -- )
c-function EndVrDrawing EndVrDrawing  -- void	( -- )
c-function InitAudioDevice InitAudioDevice  -- void	( -- )
c-function CloseAudioDevice CloseAudioDevice  -- void	( -- )
c-function IsAudioDeviceReady IsAudioDeviceReady  -- n	( -- )
c-function SetMasterVolume SetMasterVolume r -- void	( volume -- )

\c Wave* iLoadWave(const char* fileName, Wave* wav){
\c Wave wava = LoadWave(fileName);
\c *wav = wava; return wav; }

c-function iLoadWave iLoadWave s a -- a ( fileName wave -- wave )

\c Sound* iLoadSound (const char* fileName, Sound* son){
\c Sound sona = LoadSound(fileName);
\c *son = sona; return son; }

c-function iLoadSound iLoadSound s a -- a ( fileName sound -- sound )

\c Sound* iLoadSoundFromWave(Wave wave, Sound* son){
\c Sound sona = LoadSoundFromWave(wave);
\c *son = sona; return son; }

c-function iLoadSoundFromWave iLoadSoundFromWave a{*(Wave*)} a -- a ( wave sound -- sound )
c-function UpdateSound UpdateSound a{*(Sound*)} a n -- void	( sound data samplesCount -- )
c-function UnloadWave UnloadWave a{*(Wave*)} -- void	( wave -- )
c-function UnloadSound UnloadSound a{*(Sound*)} -- void	( sound -- )
c-function ExportWave ExportWave a{*(Wave*)} s -- void	( wave fileName -- )
c-function ExportWaveAsCode ExportWaveAsCode a{*(Wave*)} s -- void	( wave fileName -- )
c-function PlaySound PlaySound a{*(Sound*)} -- void	( sound -- )
c-function StopSound StopSound a{*(Sound*)} -- void	( sound -- )
c-function PauseSound PauseSound a{*(Sound*)} -- void	( sound -- )
c-function ResumeSound ResumeSound a{*(Sound*)} -- void	( sound -- )
c-function PlaySoundMulti PlaySoundMulti a{*(Sound*)} -- void	( sound -- )
c-function StopSoundMulti StopSoundMulti  -- void	( -- )
c-function GetSoundsPlaying GetSoundsPlaying  -- n	( -- )
c-function IsSoundPlaying IsSoundPlaying a{*(Sound*)} -- n	( sound -- )
c-function SetSoundVolume SetSoundVolume a{*(Sound*)} r -- void	( sound volume -- )
c-function SetSoundPitch SetSoundPitch a{*(Sound*)} r -- void	( sound pitch -- )
c-function WaveFormat WaveFormat a n n n -- void	( wave sampleRate sampleSize channels -- )

\c Wave* iWaveCopy(Wave wave, Wave* wav){
\c Wave wava = WaveCopy(wave);
\c *wav = wava; return wav; }

c-function iWaveCopy iWaveCopy a{*(Wave*)} a -- a ( wave wave -- wave )
c-function WaveCrop WaveCrop a n n -- void	( wave initSample finalSample -- )
c-function GetWaveData GetWaveData a{*(Wave*)} -- a	( wave -- )

\c Music* iLoadMusicStream(const char* fileName, Music* mus){
\c Music musa = LoadMusicStream(fileName);
\c *mus = musa; return mus; }

c-function iLoadMusicStream iLoadMusicStream s a -- a ( fileName music -- music )
c-function UnloadMusicStream UnloadMusicStream a{*(Music*)} -- void	( music -- )
c-function PlayMusicStream PlayMusicStream a{*(Music*)} -- void	( music -- )
c-function UpdateMusicStream UpdateMusicStream a{*(Music*)} -- void	( music -- )
c-function StopMusicStream StopMusicStream a{*(Music*)} -- void	( music -- )
c-function PauseMusicStream PauseMusicStream a{*(Music*)} -- void	( music -- )
c-function ResumeMusicStream ResumeMusicStream a{*(Music*)} -- void	( music -- )
c-function IsMusicPlaying IsMusicPlaying a{*(Music*)} -- n	( music -- )
c-function SetMusicVolume SetMusicVolume a{*(Music*)} r -- void	( music volume -- )
c-function SetMusicPitch SetMusicPitch a{*(Music*)} r -- void	( music pitch -- )
c-function GetMusicTimeLength GetMusicTimeLength a{*(Music*)} -- r	( music -- )
c-function GetMusicTimePlayed GetMusicTimePlayed a{*(Music*)} -- r	( music -- )

\c AudioStream* iInitAudioStream(unsigned int sampleRate, unsigned int sampleSize, unsigned int channels, AudioStream* aud){
\c AudioStream auda = InitAudioStream(sampleRate, sampleSize, channels);
\c *aud = auda; return aud; }

c-function iInitAudioStream iInitAudioStream u u u a -- a ( sampleRate sampleSize channels audiostream -- audiostream )
c-function UpdateAudioStream UpdateAudioStream a{*(AudioStream*)} a n -- void	( stream data samplesCount -- )
c-function CloseAudioStream CloseAudioStream a{*(AudioStream*)} -- void	( stream -- )
c-function IsAudioStreamProcessed IsAudioStreamProcessed a{*(AudioStream*)} -- n	( stream -- )
c-function PlayAudioStream PlayAudioStream a{*(AudioStream*)} -- void	( stream -- )
c-function PauseAudioStream PauseAudioStream a{*(AudioStream*)} -- void	( stream -- )
c-function ResumeAudioStream ResumeAudioStream a{*(AudioStream*)} -- void	( stream -- )
c-function IsAudioStreamPlaying IsAudioStreamPlaying a{*(AudioStream*)} -- n	( stream -- )
c-function StopAudioStream StopAudioStream a{*(AudioStream*)} -- void	( stream -- )
c-function SetAudioStreamVolume SetAudioStreamVolume a{*(AudioStream*)} r -- void	( stream volume -- )
c-function SetAudioStreamPitch SetAudioStreamPitch a{*(AudioStream*)} r -- void	( stream pitch -- )
c-function SetAudioStreamBufferSizeDefault SetAudioStreamBufferSizeDefault n -- void	( size -- )

\ ----===< postfix >===-----
end-c-library

\ Color constants
require raylib3-colors.fs
\ Forth words for i* functions
require raylib3-helpers.fs

