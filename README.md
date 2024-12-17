# Spinning Donut in C#

A simple ASCII-art spinning 3D donut rendered in the console using trigonometric math and basic 3D-to-2D projection.

When I saw this video, I wanted to make it in C#

https://www.youtube.com/watch?v=zn4Yvxww58g&ab_channel=GiovanniCode

---

## Description

This program generates a 3D spinning donut using ASCII characters in the console window. It updates the frame repeatedly to create the illusion of a rotating torus. The brightness of the surface is calculated based on the light source direction and rendered using different ASCII symbols.

---

## How It Works

- **Trigonometry**: Uses `sin()` and `cos()` to simulate the rotation of a 3D torus around the X and Y axes.
- **Projection**: Projects 3D points into 2D space to display them on the console screen.
- **Depth Buffer**: Ensures that closer points of the torus are rendered on top of farther ones.
- **ASCII Mapping**: Maps light intensity (brightness) to characters:  
  `.,-~:;=!*#$@`.


---

## Running the Program

1. **Clone or Download** this repository
2. Open the Code in a IDE of yours, I used Visual Studio
3. Run the Code and see the result in the console

--- 
If you like this project feel free to give a star 🌟
