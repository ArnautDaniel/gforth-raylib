\ Not the best example of Gforth-raylib code yet.
\ Yet it's still a working example.

include raylib3.fs

800 Constant screenWidth
450 Constant screenHeight
Camera3D allocate drop Value exCamera

: example-init ( -- )
  screenWidth screenHeight
  s" raylib [core] example - 3d camera free"
  InitWindow ;

: toCamera ( Vector3 Camera -- )
    { Vec3 Cam }
    Vec3 Vector3>
    Cam Vector3-z sf!
    Cam Vector3-y sf!
    Cam Vector3-x sf! ;

10.0e 10.0e 10.0e >Vector3 Value position
0.0e 0.0e 0.0e >Vector3 Value target
0.0e 1.0e 0.0e >Vector3 Value up
45.0e fvalue fovy

: example-init-camera ( -- )
    position exCamera toCamera
    target exCamera Camera3D-target toCamera
    up exCamera Camera3D-up toCamera
    fovy exCamera Camera3D-fovy sf!
    CAMERA_PERSPECTIVE exCamera Camera3D-type ! ;

0.0e 0.0e 0.0e >Vector3 Value cubePosition

: example-text ( -- )
    10 10 320 133 SKYBLUE DrawRectangle
    10 10 320 133 BLUE DrawRectangleLines
    s" Free camera default controls:" 20 20 10 BLACK DrawText
    s" - Mouse Wheel to Zoom in-out" 40 40 10 DARKGRAY DrawText
    s" - Mouse Wheel PRessed to Pan" 40 60 10 DARKGRAY DrawText
    s" - Alt + Mouse Wheel Pressed to Pan" 40 80 10 DARKGRAY DrawText
    s" - Alt + Ctrl + Mouse Wheel Pressed for Smooth Zoom" 40 100 10 DARKGRAY DrawText
    s" - Z to zoom to (0, 0, 0)" 40 120 10 DARKGRAY DrawText ;

: example-cube ( -- )
    cubePosition 2.0e 2.0e 2.0e RED DrawCube
    cubePosition 2.0e 2.0e 2.0e MAROON DrawCubeWires
    10 1.0e DrawGrid ;

: example-reset ( -- )
    KEY_Z IsKeyDown if
	0.0e 0.0e 0.0e >Vector3 exCamera
	Camera3D-target toCamera
    then ;

: example-loop ( -- )
    begin
	exCamera UpdateCamera
	example-reset
	BeginDrawing
	RAYWHITE ClearBackground 
	exCamera BeginMode3D
	example-cube
	EndMode3D
	example-text
	EndDrawing
    WindowShouldClose until ;

: start ( -- )
    example-init
    example-init-camera
    exCamera CAMERA_FREE SetCameraMode
    60 SetTargetFPS
    example-loop
    CloseWindow ;
